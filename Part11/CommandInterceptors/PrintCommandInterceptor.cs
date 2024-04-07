namespace Part11.CommandInterceptors
{
    public class PrintCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Print";

        public void Execute(Command command)
        {
            //Na duhet locationi/pathi ku do t'i printojme
            //if (command.Parameters.TryGetValue("location", out var location))
            //{
            var location = FolderBrowserManager.SelectFolderLocation();
            var products = StoreManager.GetProducts(); //kontrollojme a kemi podukte ne shporte
            if (products.Count > 0)
            {
                var printer = new Printer();
                printer.PrintToTextFile(location, products);
                //Kjo metode PrintToTextFile() nuk ekziston, ndaj e shtojme tek klasa Printer.cs
                //Per kete Visual Studio na e tregon: klikojme generate PrintToTextFile()
                Console.WriteLine("Invoice printed successfully.");
            }
            else { Console.WriteLine("No item found in the basket."); }
            //else { throw new Exception("Please provide location parameter."); }
        }

        public void ShowDoc()
        {
            Console.WriteLine("Print: - used to print the summary in a text file.");
            //Console.WriteLine("--location: - used to indicate where to print the file.");//parameter qe tregon se ku do ta printojme kete fajl
        }
    }
}
