using System;
using System.IO;

namespace XmlDoc2Markdown
{
    class Program
    {
        private string fileXml;

        static void Main(string[] args)
        {
            Program app = new Program();
            if (app.CheckParameters(args))
            {
                app.Process();

                Console.ReadLine();
            }
        }

        #region Funciones básicas CLI
        public Program()
        {
            fileXml = string.Empty;
        }

        private void InScreenHelp()
        {
            string appName = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("\nUsage: " + appName + " <file>");
            Console.WriteLine("\nWhere <file> is the Xml documentation file generate on Visual Studio\n");
            //Donde<file> es el archivo de documentación Xml generado en Visual Studio
        }

        private bool CheckParameters(string[] args)
        {
            bool result = true;

            if (args.Length <= 0)
            {
                InScreenHelp();
                return false;
            }
            else if (args.Length > 1)
            {
                InScreenHelp();
                Console.WriteLine("Error: Too much paramaters!");
                return false;
            }

            fileXml = args[0];
            if (!File.Exists(fileXml))
            {
                InScreenHelp();
                Console.WriteLine("Error: File not found!");
                return false;
            }
            return result;
        }
        #endregion

        public void Process()
        {
            try
            {
                Console.WriteLine("Processing file...");
                Convert p = new Convert(fileXml);
                p.Process();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
