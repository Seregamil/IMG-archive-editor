using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using XArchiveDragon;

namespace imageArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            IMG archive = new IMG();
            archive.Open(@"S:\games\Grand Theft Auto\models\gta3.img"); //путь к архиву

            archive.Delete("infernus.dff");
            archive.Delete("infernus.txd");

            archive.Add(@"S:\gta-o\infernus.dff", "infernus.dff");
            archive.Add(@"S:\gta-o\infernus.txd", "infernus.txd");
            archive.Extract("infernus.dff", "S:\\");

            for (int a = 0; a < archive.getItems().Count; a++)
            {
                Console.WriteLine("Name: " + archive.getItems()[a].Name + "\tSize: " + archive.getItems()[a].SizeInBytes);
            } // get item name and size
            
            Console.ReadLine();
        }
    }
}
