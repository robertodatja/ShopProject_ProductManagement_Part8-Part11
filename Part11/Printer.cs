using Newtonsoft.Json;
using System.Text;

namespace Part11
{
    public class Printer
    {
        //Kjo klase do t ekete disa metoda
        //Fillimisht do kete nje metode te thjeshte, ecila printon propertyt e cdo produkti dhe i formatojme si te duam.
        public void PrintToConsole(List<Product> products) 
        {
            for (int index = 0; index < products.Count; index++)
            {
                var product = products[index];
                Console.WriteLine("Product number {0}", index+1);
                Console.WriteLine("Name:          {0}", product.Name);
                //Console.WriteLine("Ordered:     {0}", product.OrderDate.ToString("F"));
                Console.WriteLine("Ordered:       {0:F}", product.OrderDate);
                Console.WriteLine("Amount:        {0}", product.Amount + (product.IsCountable ? "P" : "KG")); //P-Piece KG-Kilogram
                Console.WriteLine("Unit price:    {0:C}", product.Price); //c-dollar sign
                Console.WriteLine("Line total:    {0:C}", product.Price * product.Amount);
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public void PrintToConsole(List<ProductMetadata> productsMetadata)
        {
            for (int index = 0; index < productsMetadata.Count; index++)
            {
                var productMetadata = productsMetadata[index];
                Console.WriteLine("Product number {0}", index + 1);
                Console.WriteLine("Name:          {0}", productMetadata.Name);
                Console.WriteLine("Unit price:    {0:C}", productMetadata.Price); 
                Console.WriteLine("Is countable:    {0}", productMetadata.IsCountable ? "Yes" : "No");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public void PrintToTextFile(string location, List<Product> products)
        {
            //ketu do te vendosim logjiken sesi do te printojme te gjitha keto produktet ne file
            //1.Ne fillim ne duam te pergatisim textin se cfare duam te printojme ne file
            var stringBuilder = new StringBuilder(); //si nje string por ne mund te shtojme tekst mbi te
            double finalPrice = 0;
            for(int index = 0; index < products.Count; index++) 
            { 
                var product = products[index]; 
                finalPrice += product.Amount * product.Price; 
                stringBuilder.Append($"Product number:  {index+1}" + Environment.NewLine);
                stringBuilder.Append($"Name:            {product.Name}" + Environment.NewLine);
                stringBuilder.Append($"Ordered:         {product.OrderDate}" + Environment.NewLine);
                stringBuilder.Append($"Amount:          {product.Amount}" + Environment.NewLine);
                stringBuilder.Append($"Unit price:      {product.Price:C}" + (product.IsCountable ? "P" : "KG") + Environment.NewLine);
                stringBuilder.Append($"Line total:      {(product.Price * product.Amount):C}" + Environment.NewLine);
                stringBuilder.Append($"-----------------------------------------------------" + Environment.NewLine);
            }
            //2.
            stringBuilder.Append($"Total price to pay: {finalPrice:C}" + Environment.NewLine);
            stringBuilder.Append($"----------------------------------" + Environment.NewLine);
            //3.Nqs folderi location ekziston, klasa Directory vjen nga system.IO
            if(Directory.Exists(location)) 
            { 
                var path = $"{location}\\Order-Summary.txt"; //pathin ku do ta ruajme kete fajl, ose emrin e fajl-it
                File.WriteAllText(path, stringBuilder.ToString()); //stringBuilderi eshte content-i qe do ta printojme ne path
            }
            else { throw new Exception($"Location: {location} does not exist in this computer."); }
        }

        public void PrintToJsonFile(List<Product> products)
        {
            //1).Objektin/Listen products e konvertojme ne nje format JSON ne string
            var productsToString = JsonConvert.SerializeObject(products);
            //2).E ruajme ne nje fajl me emrin Order.json
            File.WriteAllText("Order.json", productsToString);
            /*File.WriteAllText(path, content), ne rastin tone si path po leme direktorine e programit dhe pastaj shkruajme emrinefajlit.json
            psh Order.json, .json dmth qe ky fajl do te permbaje objekte / elemente te tipit JSON
            Kujdes: Nqs nuk mund ta perdorim JsonConvert, dmth kemi harruar me shtuar lart: using Newtonsoft.Json;*/
        }


        //Pra ketu do te bejme te kunderten
        public List<Product> ReadJsonFromFile()
        {       
            if (!File.Exists("Order.json")) return new List<Product>();
            else 
            {
                //1).Lexojme cfare ka ne kete fajl Order.json
                var productsToText = File.ReadAllText("Order.json");
                //2).E konvertojme kete tekst qe ndodhet ne kete fajl ne List<Product>
                var products = JsonConvert.DeserializeObject<List<Product>>(productsToText);
                //3).E marrim kete List<Product>
                return products;
            }
        }
    }
}
