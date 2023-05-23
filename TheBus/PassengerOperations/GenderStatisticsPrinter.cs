using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class for printing gender statistics of passenger entries
public class GenderStatisticsPrinter
{
    private readonly List<Passenger> _passengers;

    public GenderStatisticsPrinter(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Prints the gender statistics
    public void PrintGenderStatistics()
    {
        var validator = new PassengerListValidator(_passengers);

        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        UserInterface.DisplayMessageNewLine("Seats occupied by each gender:");

        UserInterface.DisplayMessage("Male: ");
        DisplaySeatingNumbersByGender(GenderType.Male); // Display seating numbers for males

        UserInterface.DisplayMessage("Female: ");
        DisplaySeatingNumbersByGender(GenderType.Female); // Display seating numbers for females

        UserInterface.WaitForKeyPress();
    }

    // Displays seating numbers for a specific gender
    private void DisplaySeatingNumbersByGender(GenderType gender)
    {
        var seatingNumbers = _passengers
            .Where(p => p.Gender == gender)
            .Select(p => p.Seating.ToString())
            .ToList();

        if (seatingNumbers.Count != 0)
        {
            var seatingNumbersString = string.Join(", ", seatingNumbers);
            UserInterface.DisplayMessageNewLine(seatingNumbersString);
        }
        else
        {
            UserInterface.DisplayMessageNewLine($"No {gender.ToString().ToLower()}s found.");
        }
    }
}