using System.Text.RegularExpressions;

namespace Finansist.Domain.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidCEP(string strIn)
        {

            if (strIn.Contains("\n"))
            {
                return false;
            }
            return Regex.IsMatch(strIn, @"[0-9]{8}");
        }
    }
}