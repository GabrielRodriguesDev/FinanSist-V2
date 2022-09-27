using System.Text.RegularExpressions;

namespace Finansist.Domain.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidCEP(string strIn)
        {
            return Regex.IsMatch(strIn, @"[0-9]{8}");
        }

        public static bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            if (strIn.Contains("\n"))
            {
                return false;
            }

            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidTelefone(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            return Regex.IsMatch(strIn, @"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$");
        }
    }
}