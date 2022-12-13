namespace EverestAPI.Models
{
    public static class StringExtensions
    {
        public static string CpfFormatter(this string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "");
        }

        public static string CellphoneFormatter(this string cellphone)
        {
            return cellphone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(".","").Replace(",", "").Replace(" ", "");

        }

        public static string PostalCodeFormatter(this string postalCode)
        {
            return postalCode.Trim().Replace("-", "").Replace(".", "").Replace(",", "").Replace(" ", "");
        }
    }
}
