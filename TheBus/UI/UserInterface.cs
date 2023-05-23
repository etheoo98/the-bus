using System.Text.RegularExpressions;

namespace TheBus.UI;

// A class that provides user interface functionalities
internal static partial class UserInterface
{
    // Gets the user's selection from the available options and returns it as an integer
    internal static int GetSelection()
    {
        // Display the available options
        DisplayMenuItem("1. Add Passenger");
        DisplayMenuItem("2. Print All Passengers");
        DisplayMenuItem("3. Remove Passenger");
        DisplayMenuItem("4. Get Total Passenger Age");
        DisplayMenuItem("5. Get Average Passenger Age");
        DisplayMenuItem("6. Get Oldest Age");
        DisplayMenuItem("7. Search By Age");
        DisplayMenuItem("8. Sort By Age");
        DisplayMenuItem("9. Sort Seats By Gender");
        DisplayMenuItem("10. Poke Passenger");
        DisplayMenuItem("11. Exit Program");

        // Read the user's input
        var input = Console.ReadLine();

        // Parse the input as an integer and return the selection
        if (int.TryParse(input, out var selection)) return selection;

        return -1; // Return -1 if the input is not a valid integer
    }

    private static void DisplayMenuItem(string message)
    {
        // Check if the line starts with a number followed by a period
        var match = MyRegex().Match(message);

        if (match.Success)
        {
            var number = match.Groups[1].Value;
            var text = match.Groups[2].Value;

            // Set the foreground color to yellow for the number part
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(number + ".");
            Console.ResetColor();

            // Write the rest of the text
            Console.WriteLine(" " + text);
        }
        else
        {
            // If the line format doesn't match, write the message as is
            Console.WriteLine(message);
        }
    }

    // Displays a message followed by a new line
    internal static void DisplayMessageNewLine(string message)
    {
        Console.WriteLine(message);
    }

    // Displays a message without a new line
    internal static void DisplayMessage(string message)
    {
        Console.Write(message);
    }

    // Displays a message followed by a colon and space (used for input prompts)
    internal static void DisplayMessageInput(string message)
    {
        Console.Write(message + ": ");
    }

    // Clears the console screen
    internal static void ClearConsole()
    {
        Console.Clear();
    }

    // Waits for a key press from the user
    internal static void WaitForKeyPress()
    {
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    [GeneratedRegex(@"^(\d+)\.\s(.*)$")]
    private static partial Regex MyRegex();
}