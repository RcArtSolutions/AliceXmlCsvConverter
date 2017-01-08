using Rca.AliceXmlCsvConverter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rca.AxccApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RCA XML-CSV-Converter");
            Console.WriteLine("Copyright © RC-Art Solutions 2017");
            Console.WriteLine();


            string path = "";

            if (args.Length > 0)
                path = args[0];

            if (path == "")
            {
                Console.WriteLine("Bitte Pfad zur XML-Datei eingeben:");
                path = Console.ReadLine();
            }


            if (!File.Exists(path))
            {
                Console.WriteLine("XML-Datei unter folgenden Pfad nicht gefunden, Programm wird beendet.");
                Console.WriteLine(path);
                Thread.Sleep(5500);
            }
            else
            {
                Console.WriteLine("XML-Datei unter folgenden Pfad gefunden.");
                Console.WriteLine(path);
                Console.WriteLine();
                Console.WriteLine("Zum Starten beliebige Taste drücken.");
                Console.ReadKey();

                Console.WriteLine("XML-Datei wird in CSV-Datei konvertiert...");
                //string path = @"F:\LocalProjects\Git\AliceXmlCsvConverter\Data\ArticleList_PM_105094_ORG.xml";

                Axcc converter = new Axcc();

                var sw = new Stopwatch();
                sw.Start();

                converter.ReadXml(path);
                converter.GenerateCsv(path + ".csv");

                sw.Stop();

                Console.WriteLine("Konvertierung nach {0} Sekunden beendet.", (double)sw.ElapsedMilliseconds / 1000);
                Console.WriteLine("CSV-Datei wurde unter folgenden Pfad gespeichert:");
                Console.WriteLine(path + ".csv");


                Console.WriteLine();

                Console.WriteLine("Zum Beenden beliebige Taste drücken.");
                Console.ReadKey();
            }

        }
    }
}
