using System.Data.Common;
using Dapper;
using Finansist.Database.Contexts;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Helpers
{
    public class ControleSequenciaHelper : IControleSequenciaHelper
    {
        private FinansistContext _context;

        protected DbConnection _connection;

        public ControleSequenciaHelper(FinansistContext context)
        {
            this._context = context;
            this._connection = this._context.Database.GetDbConnection();
        }

        public int ProcessoNumeroSequencial(string tableName)
        {
            var transacao = _connection.BeginTransaction();
            ControleSequencia controleSequencia = _connection.QueryFirstOrDefault("Select * From ControleSequencia Where Nome = @Nome", new { Nome = tableName.ToUpper() });
            try
            {
                if (controleSequencia == null)
                {
                    controleSequencia = new ControleSequencia(tableName);
                    _connection.Execute("Insert Into ControleSequencia (`Id`, `Nome`, `Numero`, `CriadoEm`, `AlteradoEm`) VALUES(@Id, @Nome, @Numero, @CriadoEm, @AlteradoEm); ", controleSequencia);
                    transacao.Commit();
                }
                else
                {
                    controleSequencia.setProximoNumero();
                    controleSequencia.setAlteradoEm();
                    _connection.Execute("Update ControleSequencia set AlteradoEm = @AlteradoEm, Numero = @Numero Where Id = @Id;", controleSequencia);
                }
            }
            catch (System.Exception)
            {
                transacao.Rollback();
                throw;
            }
            return controleSequencia.Numero;
        }
    }
}