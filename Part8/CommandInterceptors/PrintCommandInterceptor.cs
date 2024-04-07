namespace Part8.CommandInterceptors
{
    public class PrintCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Print";

        public void Execute(Command command)
        {
            //Na duhet locationi/pathi ku do t'i printojme
            if (command.Parameters.TryGetValue("location", out var location))
            {
                var products = StoreManager.GetProducts(); //kontrollojme a kemi podukte ne shporte
                if(products.Count > 0) 
                { 
                    var printer = new Printer(); 
                    printer.PrintToTextFile(location,products);
                    //Kjo metode PrintToTextFile() nuk ekziston, ndaj e shtojme tek klasa Printer.cs
                    //Per kete Visual Studio na e tregon: klikojme generate PrintToTextFile()
                    Console.WriteLine("Invoice printed successfully.");
                }
                else { Console.WriteLine("No item found in the basket."); }
            }
            else { throw new Exception("Please provide location parameter."); }
        }

        public void ShowDoc()
        {
            throw new NotImplementedException();
        }
    }
}
