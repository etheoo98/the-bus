using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class responsible for calculating the total age of passengers
public class TotalAgeCalculator
{
    private readonly List<Passenger> _passengers;

    public TotalAgeCalculator(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Method to calculate the total age of all passengers
    public void GetTotalAge()
    {
        var validator = new PassengerListValidator(_passengers);

        // Check if the passenger list has entries
        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        // Calculate the total age
        var totalAge = CalculateTotalAge();

        // Display the total age
        UserInterface.DisplayMessageNewLine($"Total age of all passengers: {totalAge}");
        UserInterface.WaitForKeyPress();
    }

    // Helper method to calculate the total age
    private int CalculateTotalAge()
    {
        // Sum the ages of all passengers, using 0 as the default value for null ages
        return _passengers.Sum(person => person.Age ?? 0);
    }
}