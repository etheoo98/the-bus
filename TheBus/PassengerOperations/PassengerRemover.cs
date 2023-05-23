using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class responsible for removing passengers
public class PassengerRemover
{
    private readonly List<Passenger> _passengers;

    public PassengerRemover(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Method to remove a passenger
    public void RemovePassenger()
    {
        var validator = new PassengerListValidator(_passengers);

        // Check if the passenger list has entries
        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        // Loop to remove passengers
        do
        {
            UserInterface.ClearConsole();
            DisplayAllEntries();

            UserInterface.DisplayMessageInput("Enter the seating number to remove");
            if (int.TryParse(Console.ReadLine(), out var seatingNumber))
            {
                // Find the person with the specified seating number
                var personToRemove = _passengers.Find(p => p.Seating == seatingNumber);
                if (personToRemove != null)
                {
                    // Remove the person from the list
                    _passengers.Remove(personToRemove);
                    UserInterface.DisplayMessageNewLine("Person removed successfully.");
                }
                else
                {
                    UserInterface.DisplayMessageNewLine(
                        "Error: Invalid seating number. No person found with that seating number.");
                }
            }
            else
            {
                UserInterface.DisplayMessageNewLine("Error: Invalid input. Please enter a valid seating number.");
            }

            // Ask the user if they want to remove another passenger
            UserInterface.DisplayMessageNewLine("Do you want to remove another passenger? [y/N]");
        } while (char.ToLower(Console.ReadKey().KeyChar) == 'y');
    }

    private void DisplayAllEntries()
    {
        var sortedPassengers = _passengers.OrderBy(p => p.Seating).ToList();

        // Display all the entries in the passenger list
        UserInterface.DisplayMessageNewLine("These are all the entries:");
        foreach (var passenger in sortedPassengers)
            UserInterface.DisplayMessageNewLine(
                $"Seating: {passenger.Seating}, Name: {passenger.Name}, Age: {passenger.Age}, Gender: {passenger.Gender}");
    }
}