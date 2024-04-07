namespace Part8.CommandInterceptors
{
    public class RemoveCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Remove";

        public void Execute(Command command)
        {
            //Nqs parametri product ndodhet ne command, atehere kaloje vleren e tij tek name
            if (command.Parameters.TryGetValue("product", out var name))
            {
                StoreManager.RemoveProduct(name);
                Console.WriteLine($"Product with name: {name} removed from basket.");
            }
            else { Console.WriteLine("Product parameter is missing."); }
        }

        public void ShowDoc()
        {
            throw new NotImplementedException();
        }
    }
}
