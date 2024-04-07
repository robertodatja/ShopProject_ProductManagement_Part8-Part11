namespace Part11.CommandInterceptors
{
    public class AddCommandInterceptor : ICommandInterceptor
    {
        //kthejme gjithmon Add sepse kjo eshte komanda te cilen ne do ekzekutojme kete interceptor  AddCommandInterceptor
        //public string Operation { get{ return "Add";} } //gjate
        public string Operation => "Add"; //shkurt

        public void Execute(Command command)
        {
            if(command.Parameters.TryGetValue("product", out var product)) 
            {
                if (command.Parameters.TryGetValue("amount", out var amountText))
                {
                    if (StoreManager.TryGetProductMetadata(product, out var productMetadata))
                    {
                        double amount;
                        if (productMetadata.IsCountable)
                        {
                            //jodirekt assign to amount, sepse int.TryParse gjeneron int, ndaj krijojme amountTemp, pastaj assign to amount
                            if (int.TryParse(amountText, out var amounttemp)) { amount = amounttemp; }
                            else { throw new Exception("Please make sure to put a vaild integer value for parameter amount"); }
                        }
                        else
                        {
                            if (!double.TryParse(amountText, out amount)) //direkt assign to amount
                            {
                                throw new Exception("Please make sure to put a vaild double value for parameter amount");
                            }
                        }
                        if (amount <= 0) { throw new Exception("Amount can not be less than or equal to 0"); }
                        StoreManager.AddProduct(new Product
                        {
                            Name = product, //qe e marrim nga useri
                            Price = productMetadata.Price,
                            IsCountable = productMetadata.IsCountable,
                            Amount = amount //qe e marrim nga useri
                        });
                        Console.WriteLine("Product is added in the basket.");
                    }
                    else { throw new Exception($"Product with name: {product} is not available in the shop."); }
                }
                else { throw new Exception("Amount parameter is misssing"); }
            }
            else { throw new Exception("Product parameter is misssing"); }
        }

        public void ShowDoc()
        {
            Console.WriteLine("Add: - used to add a product."); //emri i interceptori - per cfare perdoret
            Console.WriteLine("--product: - it is either the name of the product."); //parametri1 - pershkrimi tij 
            Console.WriteLine("--amount: - it is the amount of the product."); //parametri2 - pershkrimi tij 
        }
    }
}
