using System.Text.RegularExpressions;
using TheBus.Models;
using TheBus.UI;

namespace TheBus.PassengerOperations;

// Class responsible for creating a new passenger
public class PassengerCreator
{
    private const int MinAge = 1;
    private const int MaxAge = 140;
    private readonly List<Passenger> _passengers;

    public PassengerCreator(List<Passenger> passengers)
    {
        _passengers = passengers;
    }

    // Creates a new passenger with valid name, age, gender, and seating
    public Passenger CreatePassenger()
    {
        var person = new Passenger();

        var name = GetValidName(); // Get a valid name from the user
        var age = GetValidAge(); // Get a valid age from the user
        var gender = GetValidGender(); // Get a valid gender from the user

        var seating = FindFirstAvailableSeat(); // Find the first available seat

        person.Seating = seating;
        person.Name = name;
        person.Age = age;
        person.Gender = gender;

        return person;
    }

    // Get a valid name from the user
    private static string GetValidName()
    {
        while (true)
        {
            UserInterface.DisplayMessageInput("Enter the name");
            var input = Console.ReadLine();

            try
            {
                var name = string.Join(" ",
                    input?.Split(' ').Select(word => char.ToUpper(word[0]) + word[1..].ToLower()) ??
                    Enumerable.Empty<string>());

                if (!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z]+(?: [a-zA-Z]+)*$"))
                    return name;
            }
            catch (IndexOutOfRangeException)
            {
                // Invalid name input
            }

            UserInterface.DisplayMessageNewLine(
                "Error: Invalid name! Please enter at least two letters (symbols and numbers are not allowed).");
        }
    }

    // Get a valid age from the user
    private static int GetValidAge()
    {
        while (true)
        {
            UserInterface.DisplayMessageInput("Enter the age");
            var input = Console.ReadLine();

            if (input == "0") return GetRandomAge();

            if (int.TryParse(input, out var age) && age is >= MinAge and <= MaxAge) return age;
            UserInterface.DisplayMessageNewLine("Error: Invalid age! Please enter an age between 1 and 140.");
        }
    }

    // Get a valid gender from the user
    private static GenderType GetValidGender()
    {
        while (true)
        {
            UserInterface.DisplayMessageInput("Enter the gender (Male/Female)");
            var input = Console.ReadLine();

            if (Enum.TryParse(input, true, out GenderType gender) && Enum.IsDefined(typeof(GenderType), gender))
                return gender;

            UserInterface.DisplayMessageNewLine("Error: Invalid gender! Please enter either 'Male' or 'Female'.");
        }
    }

    // Generate a random age between MinAge and MaxAge
    private static int GetRandomAge()
    {
        var random = new Random();
        return random.Next(MinAge, MaxAge + 1);
    }

    // Find the first available seat for the new passenger
    private int FindFirstAvailableSeat()
    {
        if (_passengers.Count == 0)
            // If the list is empty, return 1 as the initial seating value
            return 1;

        // Create a set to store the occupied seat numbers
        var occupiedSeats = new HashSet<int>(_passengers.Select(p => p.Seating));

        // Find the first available seat
        var nextSeat = 1;
        while (occupiedSeats.Contains(nextSeat)) nextSeat++;

        return nextSeat;
    }
}