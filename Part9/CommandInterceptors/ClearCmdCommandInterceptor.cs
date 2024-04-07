namespace Part9.CommandInterceptors
{
    public class ClearCmdCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Clear";

        public void Execute(Command command)
        {
            Console.Clear(); //perdorim metoden Clear() qe vjen nga Console
        }

        public void ShowDoc()
        {
            throw new NotImplementedException();
        }
    }
}
