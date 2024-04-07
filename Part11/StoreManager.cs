namespace Part11
{
    public static class StoreManager
    {
        //Dhe ne do ti lexojme keto produkte ne momentin kur ndertojme Store-in ose StoreageManager class
        //Ne kete rast duhet ta lexojme dhe themi:
        static StoreManager()
        {
            var printer = new Printer();
            var products = printer.ReadJsonFromFile();//marrim produktet ne fjale
            ListOfProducts = products;
        }
        //Tani VS na jep si rekomandim me e hequr inicializimin e meposhtem sepse normalisht inicializojme ne ctor. Pra s'eshte e nevojshme 
        //private static readonly List<Product> ListOfProducts = new List<Product>(); //shporte 
        private static readonly List<Product> ListOfProducts;

        private static readonly List<ProductMetadata> ListOfAvailableProducts = new List<ProductMetadata>() //dyqan
        {
            new ProductMetadata { Name = "Djathe", Price = 3, IsCountable = false }, //e supozojme qe blejme ne kg  
            new ProductMetadata { Name = "Patate", Price = 1.5, IsCountable = false },
            new ProductMetadata { Name = "Miell", Price = 1, IsCountable = false },
            new ProductMetadata { Name = "Veze", Price = 0.2, IsCountable = true },
            new ProductMetadata { Price = 1.5, IsCountable = false },
            new ProductMetadata { Name = "Qumesht", Price = 1, IsCountable = true },//e supozojme qe blejme me pako
            new ProductMetadata { Name = "Mish", Price = 7, IsCountable = false }
        };


        //-------
        //Metoda1: 
        //Nqs produkti me emrin name ndodhet ne dyqan, ath vendose tek value
        public static bool TryGetProductMetadata(string name, out ProductMetadata value)
        {
            //IndexOf() do ete shkoje dhe do te perdor IEquatable interface dhe do vij dhe do te krahasoje ne fund emrat.
            //dhe nqs emri/name qe kemi futur ketu si parameterperputhet me ndonje nga produktet ne dyqan atehere do te ktheje indeksin e atij produkti
            var index = ListOfAvailableProducts.IndexOf(new ProductMetadata { Name = name });
            if (index != -1)
            {
                value = ListOfAvailableProducts[index]; return true;
            }
            value = null; return false;
        }

        //Metoda2: ngjashme me Metoden1 por per  listen tjeter
        //Nqs produkti e emrin name nndodhet ne shporte, ath vendose tek product
        public static bool TryGetProduct(string name, out Product product)
        {
            var index = ListOfProducts.IndexOf(new Product { Name = name });
            if (index != -1)
            {
                product = ListOfProducts[index]; return true;
            }
            product = null; return false;
        }

        //Metoda3:
        public static void AddProduct(Product product)
        {
            if (ListOfProducts.Contains(new Product { Name = product.Name }))
            {
                throw new Exception($"Product with name: {product.Name} already exists.");
            }
            ListOfProducts.Add(product);
        }

        //Metoda4:
        public static void RemoveProduct(string name)
        {
            if (TryGetProduct(name, out var product))
            {
                ListOfProducts.Remove(product);
            }
            else
            {
                throw new Exception($"Product with name: {name} does not exist in the basket.");
            }
        }
        //Metoda5:
        public static void UpdateProduct(string name, double amount)
        {
            if (TryGetProduct(name, out var product)) {
                product.Amount = amount;
            }
            else
            {
                throw new Exception($"Product with name: {name} does not exist in the basket.");
            }
        }

        //Metoda6:
        public static void ClearProducts() { ListOfProducts.Clear(); }

        //Metoda7:
        public static List<Product> GetProducts() { return ListOfProducts; }

        //Metoda8:
        public static List<ProductMetadata> GetAvailableProducts() { return ListOfAvailableProducts; }
    }
}
