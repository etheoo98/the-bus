namespace TheBus.Models;

public class Passenger
{
    // Seating number of the person
    public int Seating { get; set; }

    // Name of the person
    public string? Name { get; set; }

    // Age of the person (nullable)
    public int? Age { get; set; }

    // Gender of the person
    public GenderType Gender { get; set; }

    // Get a response based on the person's gender and age
    public static string GetPokeResponse(string? name, Passenger passenger)
    {
        return passenger switch
        {
            // If the person is male and between 18 and 50 years old
            { Gender: GenderType.Male, Age: >= 18, Age: <= 50 } => $"{name}: You looking for a fight?",
            // If the person is female and between 60 and 80 years old
            { Gender: GenderType.Female, Age: >= 60, Age: <= 80 } => $"{name}: You little whippersnapper!",
            // If the person is female and between 20 and 40 years old
            { Gender: GenderType.Female, Age: >= 20, Age: <= 40 } => $"{name}: What's wrong with you?",
            // If the person is over 80 years old
            { Age: >= 80 } => $"{name}: Respect your elders!",
            // If the person is below 3 years old
            { Age: <= 3 } => $"{name}: Waaaaah!",
            // For all other cases
            _ => $"{name}: Hi there!"
        };
    }
}

// Enumeration for gender types
public enum GenderType
{
    Male,
    Female
}