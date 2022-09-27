using Finansist.Domain.Interfaces.Infrastructure;

namespace Finansist.Infrastructure.Errors
{
    public class ErrorManager : IErrorManager
    {
        private String CatalogedError = ErrorCatalog.NaoEspecificado;

        public void setCatalogedError(string errorCatalog)
        {
            this.CatalogedError = errorCatalog;
        }

        public String getCatalogError()
        {
            return this.CatalogedError;
        }
    }
}