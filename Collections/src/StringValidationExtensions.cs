using System.Text.RegularExpressions;

namespace StringValidation
{
    public static class StringValidationExtensions
    {
        private static readonly Regex PhoneRegex =
            new(@"^(?:\+20|0)1[0125][0-9]{8}\z", RegexOptions.Compiled);

        private static readonly Regex NationalIdRegex =
            new(@"^[23][0-9]{13}\z", RegexOptions.Compiled);

        public static bool IsValidEgyptianPhone(this string? value)
            => !string.IsNullOrWhiteSpace(value) && PhoneRegex.IsMatch(value);

        public static bool IsValidEgyptianNationalId(this string? value)
            => !string.IsNullOrWhiteSpace(value) && NationalIdRegex.IsMatch(value);
    }
}