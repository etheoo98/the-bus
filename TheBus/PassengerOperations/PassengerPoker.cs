using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class responsible for poking selected passengers
public class PassengerPoker
{
    private readonly List<Passenger> _passengers;

    public PassengerPoker(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Method to poke selected passengers
    public void PokeSelectedPassenger()
    {
        var validator = new PassengerListValidator(_passengers);

        // Check if the passenger list has entries
        if (!validator.HasEntries())
        {
            PassengerListValidator.DisplayNoEntriesMessage();
            UserInterface.WaitForKeyPress();
            return;
        }

        // Loop to poke passengers
        do
        {
            UserInterface.ClearConsole();
            UserInterface.DisplayMessageInput("Enter the seating number to poke");
            if (int.TryParse(Console.ReadLine(), out var seatingNumber))
            {
                // Find the person with the specified seating number
                var person = _passengers.Find(p => p.Seating == seatingNumber);
                if (person != null)
                {
                    // Get the response to the poke and display it
                    var response = Passenger.GetPokeResponse(person.Name, person);
                    UserInterface.DisplayMessageNewLine(response);
                }
                else
                {
                    UserInterface.DisplayMessageNewLine("No person found occupying the specified seating.");
                }
            }
            else
            {
                UserInterface.DisplayMessageNewLine("Error: Invalid seating number entered.");
            }

            // Ask the user if they want to poke another seat
            UserInterface.DisplayMessageNewLine("Do you want to poke another seat? [Y/n]");
        } while (char.ToLower(Console.ReadKey().KeyChar) != 'n');
    }
}