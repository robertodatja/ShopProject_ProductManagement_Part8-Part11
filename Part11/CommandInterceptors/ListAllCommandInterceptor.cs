namespace Part11.CommandInterceptors
{
    public class ListAllCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "List-All"; //listo te gjithe produktet qe ndodhen ne dyqan

        public void Execute(Command command)
        {
            var productsMetadata = StoreManager.GetAvailableProducts();
            //Kete klase e kemi gati nga PART4, thjesht shtojme nje metode tjeter por per productsMetaData
            //bile vete VS-Studio na sugjeron ta gjenerojme ate
            //Tani e perdorim kete metode te kesaj klase:
            if (productsMetadata.Count > 0) { var printer = new Printer(); printer.PrintToConsole(productsMetadata); }
            else { Console.WriteLine("There is not product available in the shop."); }
        }

        public void ShowDoc()
        {
            Console.WriteLine("List-All: - used to print all available products in the console.");//produktet e dyqanit 
        }
    }
}
