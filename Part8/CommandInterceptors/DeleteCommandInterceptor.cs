using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part8.CommandInterceptors
{
    public class DeleteCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Delete";

        public void Execute(Command command)
        {
            //Meqe kemi ndertuar te gjitha metodat e nevojshme brenda kesaj klase ateher i perdorim, ne rastin tone ClearProducts():
            StoreManager.ClearProducts();
            Console.WriteLine("All products are removed from the basket.");
        }

        public void ShowDoc()
        {
            throw new NotImplementedException();
        }
    }
}
