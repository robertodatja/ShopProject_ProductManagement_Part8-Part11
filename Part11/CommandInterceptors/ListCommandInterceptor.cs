namespace Part11.CommandInterceptors
{
    public class ListCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "List"; //emri i komandes
        //pra ne cdo moment kur useri vendos List, do shfaqen elementet qe ndodhen ne shporte/basket.

        public void Execute(Command command)
        {
            var products = StoreManager.GetProducts();//i marrim
            //Duam t'i printojme ndaj na duhet nje klase qe po e quajme Printer.cs
            //Tani e perdorim kete klase:
            if(products.Count > 0) { var printer = new Printer(); printer.PrintToConsole(products); }
            else { Console.WriteLine("There is not product in the basket."); }
        }

        public void ShowDoc()
        {
            Console.WriteLine("List: - used to print all products from basket in the console.");
        }
    }
}
