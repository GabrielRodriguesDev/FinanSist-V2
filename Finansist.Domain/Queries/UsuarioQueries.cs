

namespace Finansist.Domain.Queries
{
    public class UsuarioQueries
    {
        public static string GetPorEmail()
        {
            return "Select * From Usuario Where Email =  @Email";
        }
    }
}