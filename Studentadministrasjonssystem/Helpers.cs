using System.Numerics;

namespace Studentadministrasjonssystem;

public class Helpers
{
    public static void ContinuePrompt()
    {
        Console.Write("\nTrykk enter for å fortsette...");
        Console.ReadLine();
    }

    public static int? AskForInt(string label, bool required, int? min = null, int? max = null)
    {
        Console.Write(label);
        var inputString = Console.ReadLine();
        if (string.IsNullOrEmpty(inputString) && !required) return null;
        try
        {
            if (inputString == null) throw new FormatException();
            var input = int.Parse(inputString);
            if ((max == null || input <= max) && (min == null || input >= min)) return input;
            throw new IndexOutOfRangeException();
        }
        catch (FormatException)
        {
            Console.WriteLine("Not a number, try again.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine($"Tallet må være mellom {min}-{max}. Prøv igjen.");
        }
        return AskForInt(label, required, min, max);
    }

    public static string AskForString(string label, bool required)
    {
        Console.Write(label);
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            return input;
        }

        if (!required) return string.Empty;

        Console.WriteLine("This field is required, please enter a valid input.");
        return AskForString(label, required);
    }

    public static bool AskForBool(string label)
    {
        Console.Write(label + "(Y/n)");
        var input = Console.ReadLine();
        return string.IsNullOrEmpty(input) || input.ToLower() == "y";
    }

    public static char AskForChar(string label)
    {
        Console.Write(label);
        var input = Char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
        if (input != '\0') return input;
        Console.WriteLine("Ugyldig input, prøv igjen.");
        AskForChar(label);
        return input;
    }
}