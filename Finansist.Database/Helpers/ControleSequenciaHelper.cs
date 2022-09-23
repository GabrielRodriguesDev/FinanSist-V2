using System.Data.Common;
using Dapper;
using Finansist.Database.Contexts;
using Finansist.Domain.Entities;
using Finansist.Domain.Interfaces.Database;
using Finansist.Domain.Interfaces.Database.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Finansist.Database.Helpers
{
    public class ControleSequenciaHelper : IControleSequenciaHelper
    {
        private FinansistContext _context;

        protected DbConnection _connection;

        private IUnitOfWork _uow;

        public ControleSequenciaHelper(
            FinansistContext context,
            IUnitOfWork uow
            )
        {
            this._context = context;
            this._connection = _context.Database.GetDbConnection();
            _uow = uow;
        }

        public int ProcessoNumeroSequencial(string tableName)
        {
            _uow.BeginTransaction();
            ControleSequencia controleSequencia = _connection.QueryFirstOrDefault<ControleSequencia>("Select * From ControleSequencia Where Nome = @Nome", new { Nome = tableName.ToUpper() }, _uow.CurrentTransaction());
            try
            {
                if (controleSequencia == null)
                {
                    controleSequencia = new ControleSequencia(tableName);
                    _connection.Execute("Insert Into ControleSequencia (`Id`, `Nome`, `Numero`, `CriadoEm`, `AlteradoEm`) VALUES(@Id, @Nome, @Numero, @CriadoEm, @AlteradoEm); ", controleSequencia, _uow.CurrentTransaction());
                }
                else
                {
                    controleSequencia.setProximoNumero();
                    controleSequencia.setAlteradoEm();
                    _connection.Execute("Update ControleSequencia set AlteradoEm = @AlteradoEm, Numero = @Numero Where Id = @Id;", controleSequencia, _uow.CurrentTransaction());
                }
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return controleSequencia.Numero;
        }
    }
}