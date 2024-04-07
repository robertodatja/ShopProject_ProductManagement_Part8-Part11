namespace Part11.CommandInterceptors
{
    public class CheckCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Check";

        public void Execute(Command command)
        {
            if (command.Parameters.TryGetValue("product", out var productName))
            {
                if (StoreManager.TryGetProduct(productName, out var product))
                {
                    //Fusim si argument nje liste vetem me nje produkt pikeriht produktin product
                    //Nqs produkti do te printohet ne Console dmth qe ekziston ne shporte
                    var printer = new Printer(); printer.PrintToConsole(new List<Product> { product }); 
                }
                else { throw new Exception($"No item with such name: {productName} exist in the basket."); }
            }
            else { throw new Exception("Product parameter is misssing"); }
        }


        public void ShowDoc()
        {
            Console.WriteLine("Check - used to check if a product is in the basket. ");
            Console.WriteLine("--product: - used to identify the product.");//parameter
        }
    }
}
