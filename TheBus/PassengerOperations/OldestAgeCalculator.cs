using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class for calculating the oldest age among passenger entries
public class OldestAgeCalculator
{
    private readonly List<Passenger> _passengers;

    public OldestAgeCalculator(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Calculates the oldest age and displays the passengers with that age
    public void CalculateOldestAge()
    {
        var validator = new PassengerListValidator(_passengers);

        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        var oldestAge = FindOldestAge(); // Calculate the oldest age
        var oldestPassengers = FindPassengersWithOldestAge(oldestAge); // Find passengers with the oldest age

        if (oldestPassengers.Count > 0)
        {
            UserInterface.DisplayMessageNewLine($"Oldest age of all entries: {oldestAge}");
            UserInterface.DisplayMessageNewLine("Passengers with the oldest age:");

            foreach (var oldestPerson in oldestPassengers)
                UserInterface.DisplayMessageNewLine($"Name: {oldestPerson.Name}, Age: {oldestPerson.Age}");
        }
        else
        {
            UserInterface.DisplayMessageNewLine("No entries with valid ages found.");
        }

        UserInterface.WaitForKeyPress();
    }

    // Finds the oldest age among all entries
    private int FindOldestAge()
    {
        var maxAge = int.MinValue;

        foreach (var person in _passengers.Where(person => person.Age.HasValue && person.Age.Value > maxAge))
            if (person.Age != null)
                maxAge = person.Age.Value;

        return maxAge;
    }

    // Finds the passengers with the oldest age
    private List<Passenger> FindPassengersWithOldestAge(int oldestAge)
    {
        return _passengers.Where(person => person.Age.HasValue && person.Age.Value == oldestAge).ToList();
    }
}