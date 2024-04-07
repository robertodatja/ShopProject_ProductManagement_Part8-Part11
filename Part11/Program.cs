using Part11.CommandInterceptors;

namespace Part11
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string command = string.Empty;

            Console.WriteLine("Type 'Help' to see all commands.");
            Console.WriteLine("Type 'help--command x' where x is the command name, to see documentation only for command x.");

            while (string.Compare(command, "exit", StringComparison.OrdinalIgnoreCase) != 0)
            {
                Console.Write("-> "); command = Console.ReadLine();
                try
                {
                    var lcommands = CommandInterpreter.InterpretCommandTest(command);
                    foreach (var commandObject in lcommands) { CommandExecuterManager.Execute(commandObject); }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

            }
        }
    }
}
