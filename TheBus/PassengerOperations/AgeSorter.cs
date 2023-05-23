using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class for sorting passenger entries by age
public class AgeSorter
{
    private readonly List<Passenger> _passengers;

    public AgeSorter(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Sorts the passenger entries by age and prints the sorted list
    public void SortEntriesByAge()
    {
        var validator = new PassengerListValidator(_passengers);

        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        var sortedPassengers = SortPassengersByAge(); // Sort the passengers list by age

        PrintSortedPassengers(sortedPassengers); // Print the sorted passengers list
        UserInterface.WaitForKeyPress();
    }

    // Sorts the list of passengers by age in ascending order
    private List<Passenger> SortPassengersByAge()
    {
        return _passengers.OrderBy(p => p.Age).ToList();
    }

    // Prints the sorted list of passengers with their name and age
    private static void PrintSortedPassengers(List<Passenger> passengers)
    {
        UserInterface.DisplayMessageNewLine("Passengers sorted by age in ascending order:");
        foreach (var person in passengers)
            UserInterface.DisplayMessageNewLine($"Name: {person.Name}, Age: {person.Age}");
    }
}