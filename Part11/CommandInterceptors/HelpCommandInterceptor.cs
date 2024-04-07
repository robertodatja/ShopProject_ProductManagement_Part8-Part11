namespace Part11.CommandInterceptors
{
    public class HelpCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Help";

        public void Execute(Command command)
        {
            //1.Nqs marrim nje parameter te quuajtur command
            if(command.Parameters.TryGetValue("command", out var cmd))
            {
                //2.Nqs vendosim te kalojme nje komande si parameter,
                //atehere do te krijojme nje metode tjeter me te njejtin emer, ndaj klikoj me maus Generate method ShowDoc
                ShowDoc(cmd);
            }
            else { ShowDoc(); }
        }

        private void ShowDoc(string cmd)
        {
            //4. shfaq doc vetem per interceptorin/komanden qe kemi kaluar si parameter cmd
            Console.WriteLine("Documentation:");
            foreach (var interceptor in InterceptorStore.interceptors)
            {
                if (interceptor.Operation == cmd)
                { 
                    interceptor.ShowDoc();
                    Console.WriteLine("-------------------------------------------------------------");
                    return;
                }
            }
            //Nqs interceptori me komanden perkatese nuk eshte gjendur ne foreach ne fund ne duam te bejme throw
            //Fillimisht shkruajm return brenda if pastaj throw brenda else
            throw new Exception($"Command {cmd} not found."); //nqs komanda gjendet nuk ekzekutohet ky rresht
        }

        public void ShowDoc()
        {
            //3. 
            Console.WriteLine("Documentation:");
            foreach (var interceptor in InterceptorStore.interceptors)
            {
                interceptor.ShowDoc();//shfaq doc per cdo interceptor qe kemi ne Store
                Console.WriteLine("---------------------------------");
            }
        }
    }
}
