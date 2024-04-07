namespace Part9.CommandInterceptors
{
    public class CalculateCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Calculate";

        public void Execute(Command command)
        {
            var products = StoreManager.GetProducts();
            if (products.Count > 0) 
            {
                //shfaqim listen e produkteve
                var printer = new Printer(); printer.PrintToConsole(products);
                //llogarisim finalprice
                double finalPrice = 0;
                foreach (var product in products) { finalPrice += product.Price * product.Amount; }
                Console.WriteLine($"Total price to pay: {finalPrice:C}");
                Console.WriteLine("=====================================");
            }
        }

        public void ShowDoc()
        {
            throw new NotImplementedException();
        }
    }
}
