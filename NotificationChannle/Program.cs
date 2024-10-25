using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = string.Empty;

        HashSet<string> validChannels = new HashSet<string> { "[BE]", "[FE]", "[QA]", "[Urgent]" };

        Console.WriteLine($"Available channels: {string.Join(",", validChannels)}");
        Console.WriteLine($"============================================");
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write("Please write your message: ");
            input = Console.ReadLine();

            if (input.ToLower() == "exit()" || input.ToLower() == "exit")
            {
                Environment.Exit(0);
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid message or type exit() for Quit.");
            }
        }
        ProcessNotification(input);
    }

    static void ProcessNotification(string input)
    {
        // Define valid notification channels
        HashSet<string> validChannels = new HashSet<string> { "BE", "FE", "QA", "QA", "Urgent" };

        // Extract tags using Regex
        MatchCollection matches = Regex.Matches(input, @"\[(.*?)\]");

        List<string> channels = new List<string>();

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            if (validChannels.Contains(tag))
            {
                channels.Add(tag);
            }
        }

        // Output the result
        Console.WriteLine($"Receive channels: {string.Join(", ", channels)}");
    }
}
