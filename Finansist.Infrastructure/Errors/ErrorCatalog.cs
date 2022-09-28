using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansist.Infrastructure.Errors
{
    public class ErrorCatalog
    {
        public static String NaoEspecificado = "(E0001)";

        #region Usuario
        public static String AutenticaLogin = "(E0002)";
        #endregion

        #region Autentica
        public static String UsuarioCreate = "(E0003)";
        #endregion

        #region  Entidade
        public static String EntidadeCreate = "(E0004)";
        #endregion
    }
}