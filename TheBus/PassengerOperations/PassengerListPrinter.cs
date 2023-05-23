using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class responsible for printing all passenger entries
public class PassengerListPrinter
{
    private readonly List<Passenger> _passengers;

    public PassengerListPrinter(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Print all passenger entries
    public void PrintAllPassengerEntries()
    {
        var validator = new PassengerListValidator(_passengers);

        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage(); // Display a message when there are no entries
            UserInterface.WaitForKeyPress();
            return;
        }

        var sortedPassengers = SortPassengersBySeating(); // Sort passengers by seating number

        UserInterface.DisplayMessageNewLine("These are all the entries:");
        PrintPassengerEntries(sortedPassengers); // Print the passengers entries

        UserInterface.WaitForKeyPress();
    }

    // Sort passengers by seating number
    private List<Passenger> SortPassengersBySeating()
    {
        return _passengers.OrderBy(p => p.Seating).ToList();
    }

    // Print the passengers entries
    private static void PrintPassengerEntries(List<Passenger> passengers)
    {
        foreach (var passenger in passengers)
            UserInterface.DisplayMessageNewLine(
                $"Seating: {passenger.Seating}, Name: {passenger.Name}, Age: {passenger.Age}, Gender: {passenger.Gender}");
    }
}