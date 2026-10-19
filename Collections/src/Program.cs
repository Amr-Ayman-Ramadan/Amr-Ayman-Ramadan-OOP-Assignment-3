using StringValidation;

Console.WriteLine("=== IsValidEgyptianPhone ===");
Check("01012345678", "01012345678".IsValidEgyptianPhone(), true);
Check("+201512345678", "+201512345678".IsValidEgyptianPhone(), true);
Check("01312345678", "01312345678".IsValidEgyptianPhone(), false);
Check("0101234567", "0101234567".IsValidEgyptianPhone(), false);
Check("0101234567a", "0101234567a".IsValidEgyptianPhone(), false);

Console.WriteLine();
Console.WriteLine("=== IsValidEgyptianNationalId ===");
Check("29901011234567", "29901011234567".IsValidEgyptianNationalId(), true);
Check("19901011234567", "19901011234567".IsValidEgyptianNationalId(), false);
Check("2990101123456", "2990101123456".IsValidEgyptianNationalId(), false);

Console.WriteLine();
Console.WriteLine("=== null / empty / spaces (must not throw) ===");
string? nothing = null;
Check("null", nothing.IsValidEgyptianPhone(), false);
Check("\"\"", "".IsValidEgyptianPhone(), false);
Check("\"   \"", "   ".IsValidEgyptianNationalId(), false);

static void Check(string input, bool actual, bool expected)
{
    var status = actual == expected ? "PASS" : "FAIL";
    Console.WriteLine($"{status}  {input,-16} -> {actual} (expected {expected})");
}