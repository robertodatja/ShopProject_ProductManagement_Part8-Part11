namespace Part11.CommandInterceptors
{
    public static class CommandExecuterManager
    {
        private static readonly Dictionary<string,ICommandInterceptor> Interceptors 
            = new Dictionary<string,ICommandInterceptor>();
        static CommandExecuterManager()
        {
            var helpInterceptor = new HelpCommandInterceptor(); //XIII. at Part10
            Interceptors.Add(helpInterceptor.Operation, helpInterceptor);

            foreach (var interceptor in InterceptorStore.interceptors) { Interceptors.Add(interceptor.Operation, interceptor); }
        }

        public static void Execute(Command command)
        {
            if (Interceptors.TryGetValue(command.Name, out var interceptor)) { interceptor.Execute(command); }
            else { throw new Exception($"Interceptor for command: {command.Name} could not be found."); }
        }
    }
}
