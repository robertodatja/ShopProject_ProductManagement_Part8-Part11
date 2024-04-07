
using System.Text;

namespace Part8
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
    }
}
