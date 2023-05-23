// Import the services namespace which contains the Bus class

using TheBus.UI;

// TheBus namespace for the application
namespace TheBus;

// Main entry point of the program
internal static class Program
{
    // Main method, the starting point of the program
    private static void Main()
    {
        // Call the Run method of the Bus class to start the program
        Bus.Run();
    }
}