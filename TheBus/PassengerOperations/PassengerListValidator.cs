using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class responsible for validating passenger lists
public class PassengerListValidator
{
    private readonly List<Passenger> _passengers;

    public PassengerListValidator(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Check if the passenger list has entries
    public bool HasEntries()
    {
        return _passengers.Count > 0;
    }

    // Display a message when no entries are found
    public static void DisplayNoEntriesMessage()
    {
        UserInterface.DisplayMessageNewLine("No entries found.");
    }
}