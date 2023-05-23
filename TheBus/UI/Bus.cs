using TheBus.Models;
using TheBus.PassengerOperations;

namespace TheBus.UI;

public static class Bus
{
    // Initialize the necessary instances and objects related to passenger operations
    private static readonly List<Passenger> Passengers = new();
    private static readonly PassengerCreator PassengerCreator = new(Passengers);
    private static readonly PassengerListPrinter PassengerListPrinter = new(Passengers);
    private static readonly PassengerRemover PassengerRemover = new(Passengers);
    private static readonly TotalAgeCalculator TotalAgeCalculator = new(Passengers);
    private static readonly AverageAgeCalculator AverageAgeCalculator = new(Passengers);
    private static readonly OldestAgeCalculator OldestAgeCalculator = new(Passengers);
    private static readonly AgeSearcher AgeSearcher = new(Passengers);
    private static readonly AgeSorter AgeSorter = new(Passengers);
    private static readonly GenderStatisticsPrinter GenderStatisticsPrinter = new(Passengers);
    private static readonly PassengerPoker PassengerPoker = new(Passengers);

    public static void Run()
    {
        while (true)
        {
            UserInterface.ClearConsole();
            try
            {
                var selection = UserInterface.GetSelection();
                switch (selection)
                {
                    case 1:
                        AddPassenger();
                        break;
                    case 2:
                        PrintAllPassengerEntries();
                        break;
                    case 3:
                        RemovePassenger();
                        break;
                    case 4:
                        GetTotalPassengerAge();
                        break;
                    case 5:
                        GetAveragePassengerAge();
                        break;
                    case 6:
                        GetOldestAge();
                        break;
                    case 7:
                        SearchByAge();
                        break;
                    case 8:
                        SortByAge();
                        break;
                    case 9:
                        PrintGender();
                        break;
                    case 10:
                        PokePassenger();
                        break;
                    case 11:
                        Environment.Exit(0);
                        break;
                    default:
                        UserInterface.DisplayMessageNewLine("Invalid selection. Please try again.");
                        return;
                }
            }
            catch (Exception ex)
            {
                UserInterface.DisplayMessageNewLine($"An error occurred: {ex.Message}");
            }
        }
    }

    // Method for adding a passenger to the list
    private static void AddPassenger()
    {
        UserInterface.ClearConsole();
        var passengerEntry = PassengerCreator.CreatePassenger();
        Passengers.Add(passengerEntry);
    }

    // Method for printing all passenger entries
    private static void PrintAllPassengerEntries()
    {
        UserInterface.ClearConsole();
        PassengerListPrinter.PrintAllPassengerEntries();
    }

    // Method for removing a passenger from the list
    private static void RemovePassenger()
    {
        UserInterface.ClearConsole();
        PassengerRemover.RemovePassenger();
    }

    // Method for calculating the total age of all passengers
    private static void GetTotalPassengerAge()
    {
        UserInterface.ClearConsole();
        TotalAgeCalculator.GetTotalAge();
    }

    // Method for calculating the average age of all passengers
    private static void GetAveragePassengerAge()
    {
        UserInterface.ClearConsole();
        AverageAgeCalculator.CalculateAverageAge();
    }

    // Method for calculating the oldest age among the passengers
    private static void GetOldestAge()
    {
        UserInterface.ClearConsole();
        OldestAgeCalculator.CalculateOldestAge();
    }

    // Method for searching passengers by age
    private static void SearchByAge()
    {
        UserInterface.ClearConsole();
        AgeSearcher.PerformAgeSearch();
    }

    // Method for sorting passenger entries by age
    private static void SortByAge()
    {
        UserInterface.ClearConsole();
        AgeSorter.SortEntriesByAge();
    }

    // Method for printing gender statistics of passengers
    private static void PrintGender()
    {
        UserInterface.ClearConsole();
        GenderStatisticsPrinter.PrintGenderStatistics();
    }

    // Method for poking a selected passenger
    private static void PokePassenger()
    {
        UserInterface.ClearConsole();
        PassengerPoker.PokeSelectedPassenger();
    }
}