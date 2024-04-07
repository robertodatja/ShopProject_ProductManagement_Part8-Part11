namespace Part11
{
    public static class CommandInterpreter //E bejme statike sepse s'kemi nevoj ta inicializojme shume here
    {    
        public static List<Command> InterpretCommandTest(string Command) //Do kthen nje liste me commanda
        {
            if (string.IsNullOrEmpty(Command)) throw new Exception("Please add at least one command to execute.");

            var commandResult = new List<Command>(); //kjo list do t'i mban te gjithe commandat qe do te interpretojme
            var allCommmands = Command.Split('&'); //1.merr nje string dhe e ndan sipas &
            foreach (var commmandWithParams in allCommmands)
            {
                var parts = commmandWithParams.Trim().Split(' '); //2.per cdo komande e ben split ' '
                if (parts.Length % 2 != 1) { throw new Exception("Bad command format."); } //3.numri i fjaleve duhet tek
                                                                                           //sepse kemi emriKomandes, param1, valuesi, param2, value2 ,...

                var singleExecutionCommand = parts[0]; //4.emriKomandes
                var parameters = new Dictionary<string, string>();//5.parametrat dhe vlerat e tyre
                for (int i = 1; i < parts.Length; i += 2) //6.extractojme parametrat dhe vlerat e tyre
                {
                    //insertojme parametrat dhe vlerat e tyre
                    if (parts[i].StartsWith("--")) { parameters.Add(parts[i].Substring(2), parts[i + 1]); }
                    else { throw new Exception($"Bad parameter format for: {parts[i]}"); }
                }

                commandResult.Add(new Command() { Name = singleExecutionCommand, Parameters = parameters });
            }
            return commandResult;//6.kthejme kete list me commandat qe i kemi perpunuar
        }
    }
}

