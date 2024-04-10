using System;
using System.Text.RegularExpressions;

public class EmailValidator
{
    public static void Main(string[] args)
    {
        string text = "Este es mi correo electrónico: juan_perez.23@gmail.com. Por favor, envíeme un correo con sus comentarios.";
        string[] emails = ExtractEmails(text);
        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }
        Console.WriteLine("Envíame un correo con sus comentarios");
    }

    public static string[] ExtractEmails(string text)
    {
        string pattern = @"\b[\w\.-]+@[\w\.-]+\.\w+\b";
        MatchCollection matches = Regex.Matches(text, pattern);
        string[] validEmails = new string[matches.Count];
        int validCount = 0;
        foreach (Match match in matches)
        {
            string email = match.Value;
            if (IsValidEmail(email))
            {
                validEmails[validCount] = email;
                validCount++;
            }
        }
        Array.Resize(ref validEmails, validCount);
        return validEmails;
    }

    public static bool IsValidEmail(string email)
    {
        string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
        return Regex.IsMatch(email, pattern);
    }
}
