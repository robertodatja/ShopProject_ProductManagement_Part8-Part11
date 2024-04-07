namespace Part11.CommandInterceptors
{
    public class BuyCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Buy";

        public void Execute(Command command)
        {
            var products = StoreManager.GetProducts(); //marrim produktet qe kemi ne shporte
            if (products.Count > 0)
            {
                //1.Printojme faturen e produkteve
                var printer = new Printer();
                //printer.PrintToTextFile(@"C:\Users\user\Desktop", products);
                var location = FolderBrowserManager.SelectFolderLocation();
                printer.PrintToTextFile(location, products);
                //2.Fshijme produktet nga shporta
                StoreManager.ClearProducts();
                /*3.Gjithashtu fshijme produktet nga memorja ku i kemi ruajtur
                Pra nqs e hapim programin heren tjeter
                dmth sdo kemi asnje produkt te ruajtur ne fajlin .json qe te ngarkohet ne hapin e rradhes.
                Per kete vndosim nje liste boshe si argument
                Pra ruajme nje liste boshe ne JsonFile ne menyre qe kur ta hapim programin heren tjeter(hapin e rradhes)
                te mos ngarkohen produktet e vjetra por te ngarkohet nje liste boshe.*/
                printer.PrintToJsonFile(new List<Product>());
                Console.WriteLine("Purchase completed. Basket is empty.");
            }
            else { Console.WriteLine("No product in the basket."); }
        }
        public void ShowDoc()
        {
            Console.WriteLine("Buy: - used to finish the purchase."); //per blerjen/perfundimin e blerjes
        }
    }
}


