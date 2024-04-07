using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part11.CommandInterceptors
{
    public class SaveCommandInterceptor : ICommandInterceptor
    {
        public string Operation => "Save";
        /*
        Per te ruajtur te dhenat dhe pas mbylljes se programit duhet te gjejme nje format sesi ne duam ti ruajme keto te dhena
        dhe vendin ku duam ti ruajme keto te dhena.
        Ka formate te ndryyshme sesi ne mund ti ruajme te dhenat. Por ne kete rast do te perdorim nje format qe quhet JSON
        Ky format na lejon te ruajme te dhena me forme teksti, ne nje tekst file ne nje format te tille qe ne mund ta rilexojme me vone
        dhe ta konvertojme kete tekst ne objekte te nje klase te caktuar.
        Per te ruajtur te dhena ne nje JSON format pra ne nje tekst file dhe per ti lexuar ato.
        Ne do te perdorim nje Librari te cilen ne do ta instalojme tani.
        Per ta instaluar kete librari:
        1.Klikojme mbi Part11 pastaj mbi Dependencies-me te djathten. Pastaj Manage Nudget Packages
        2.Kerkojme Newtonsoft.Json.Pastaj e selektojme dhe klikojme Install
        Nudget eshte thjesht nje depo ku secili mund te hedhi librarite/paketat e tyre dhe te tjeret mund ti shkarkojne dhe ti perdorin
        Tani po te shkojme tek Part11-Dependencies-Packages do te shohim Newtonsoft.Json
        */
        public void Execute(Command command)
        {
            var products = StoreManager.GetProducts(); //marrim produktet
            //if (products.Count > 0) 
            //{ 
                var printer = new Printer();
                printer.PrintToJsonFile(products);
                Console.WriteLine("Products are saved successfully.");
            //}
            //else { Console.WriteLine("There is no product to save."); }
        }

        public void ShowDoc()
        {
            Console.WriteLine("Save: - used to save all changes to a file.");
        }
    }
}
