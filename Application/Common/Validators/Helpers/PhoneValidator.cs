namespace Application.Common.Validators.Helpers
{
    public static class PhoneValidator
    {
        public static bool IsPhoneValid(string phone)
        {
            return phone.StartsWith("+")
            || phone.Substring(1).All(c => char.IsDigit(c))
            || phone.Length <= 15;
        }
    }
}
