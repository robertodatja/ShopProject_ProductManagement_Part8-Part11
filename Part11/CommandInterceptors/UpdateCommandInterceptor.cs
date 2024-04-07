namespace Part11.CommandInterceptors
{
    public class UpdateCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Update";

        public void Execute(Command command)
        {
            if (command.Parameters.TryGetValue("product", out var product))
            {
                if (command.Parameters.TryGetValue("amount", out var amountText))
                {
                    if (StoreManager.TryGetProductMetadata(product, out var productMetadata))
                    {
                        double amount;
                        if (productMetadata.IsCountable)
                        {
                            if (int.TryParse(amountText, out var amounttemp)) { amount = amounttemp; }
                            else { throw new Exception("Please make sure to put a vaild integer value for parameter amount"); }
                        }
                        else
                        {
                            if (!double.TryParse(amountText, out amount)) 
                            {
                                throw new Exception("Please make sure to put a vaild double value for parameter amount");
                            }
                        }
                        if (amount <= 0) { throw new Exception("Amount can not be less than or equal to 0"); }
                        StoreManager.UpdateProduct(product, amount); //keto parametra i marrim nga useri
                        Console.WriteLine("Product is updated in the basket.");
                    }
                    else { throw new Exception($"Product with name: {product} is not available in the shop."); }
                }
                else { throw new Exception("Amount parameter is misssing"); }
            }
            else { throw new Exception("Product parameter is misssing"); }
        }

        public void ShowDoc()
        {
            Console.WriteLine("Update: - used to update a product in the basket.");
            Console.WriteLine("--product: -  used to identify the product to update.");
            Console.WriteLine("--amount: - the new amount of the product.");
        }
    }
}
