using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class for performing age searches on a list of passengers
public class AgeSearcher
{
    private readonly List<Passenger> _passengers;

    internal AgeSearcher(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Performs the age search operation
    public void PerformAgeSearch()
    {
        var validator = new PassengerListValidator(_passengers);

        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        do
        {
            UserInterface.ClearConsole();
            UserInterface.DisplayMessage("Enter the age or age range to search for (e.g., 55 or 55-69): ");
            var input = Console.ReadLine();
            SearchByAgeInput(input); // Perform the search based on user input
            UserInterface.DisplayMessageNewLine("Do you want to make another search? [Y/n]");
        } while (char.ToLower(Console.ReadKey().KeyChar) != 'n');
    }

    // Performs the search based on the user input
    private void SearchByAgeInput(string? input)
    {
        if (input == null) return;

        var ageValues = input.Split('-');

        switch (ageValues.Length)
        {
            case 1 when int.TryParse(ageValues[0], out var singleAge):
            {
                // Search for passengers with a specific age
                var matchingPassengers = _passengers.FindAll(p => p.Age.HasValue && p.Age.Value == singleAge);
                PrintMatchingPassengers(matchingPassengers, singleAge.ToString());
                break;
            }
            case 1:
                UserInterface.DisplayMessageNewLine("Error: Invalid age input.");
                break;
            case 2 when int.TryParse(ageValues[0], out var minAge) && int.TryParse(ageValues[1], out var maxAge):
            {
                // Search for passengers within an age range
                var matchingPassengers =
                    _passengers.FindAll(p => p.Age.HasValue && p.Age.Value >= minAge && p.Age.Value <= maxAge);
                PrintMatchingPassengers(matchingPassengers, $"{minAge}-{maxAge}");
                break;
            }
            case 2:
                UserInterface.DisplayMessageNewLine("Error: Invalid age range input.");
                break;
            default:
                UserInterface.DisplayMessageNewLine("Error: Invalid input format.");
                break;
        }
    }

    // Prints the matching passengers based on the search criteria
    private static void PrintMatchingPassengers(List<Passenger> matchingPassengers, string searchCriteria)
    {
        UserInterface.DisplayMessageNewLine($"Search results for age {searchCriteria}:");
        if (matchingPassengers.Count > 0)
            foreach (var person in matchingPassengers)
                UserInterface.DisplayMessageNewLine($"Name: {person.Name}, Age: {person.Age}");
        else
            UserInterface.DisplayMessageNewLine("No matching passengers found.");
    }
}