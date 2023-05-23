using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class for calculating the average age of passenger entries
public class AverageAgeCalculator
{
    private readonly List<Passenger> _passengers;

    public AverageAgeCalculator(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Calculates and prints the average age of the passenger entries
    public void CalculateAverageAge()
    {
        var validator = new PassengerListValidator(_passengers);

        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        var totalAge = CalculateTotalAge(); // Calculate the sum of ages
        var count = CalculateEntryCount(); // Count the number of entries with valid ages

        if (count > 0)
        {
            var averageAge = (double)totalAge / count; // Calculate the average age
            UserInterface.DisplayMessageNewLine(
                $"Average age of all entries: {averageAge}"); // Print the average age
        }
        else
        {
            UserInterface.DisplayMessageNewLine("No entries with valid ages found.");
        }

        UserInterface.WaitForKeyPress();
    }

    // Calculates the sum of ages for entries with valid ages
    private int CalculateTotalAge()
    {
        return _passengers.Where(person => person.Age.HasValue).Sum(person => person.Age ?? 0);
    }

    // Counts the number of entries with valid ages
    private int CalculateEntryCount()
    {
        return _passengers.Count(person => person.Age.HasValue);
    }
}