namespace Studentadministrasjonssystem;

public class Helpers
{
    public static void ContinuePrompt()
    {
        Console.Write("\nTrykk enter for å fortsette...");
        Console.ReadLine();
    }
    public static int AskForInt(string label)
    {
        Console.Write(label);
        var input = Console.ReadLine();
        var result = 0;
        try
        {
            result = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Not a number, try again.");
            AskForInt(label);
        }

        return result;
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
}