namespace Finansist.Domain.Interfaces.Infrastructure
{
    public interface IErrorManager
    {
        void setCatalogedError(string errorCatalog);

        String getCatalogError();
    }
}