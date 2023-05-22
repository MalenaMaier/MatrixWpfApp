using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace TestWpfApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            string directory = @"C:\";
            DirectoryInfo dir = new DirectoryInfo(directory);
            HashSet<string> extensions = new HashSet<string>(); 
            foreach (FileInfo file in dir.GetFiles())
            {
                extensions.Add(file.Name);
            }
            Console.Write("Gefundene Dateiendungen: ");
            foreach (string extension in extensions)
            {
                Console.Write(extension);
            }

            //optimiere den code sodass eine schleife weg fällt
            //&& groß/kleinschreibung irrelevant wird
            Console.Write("Gefundene Dateiendungen: ");
            foreach (FileInfo file in dir.GetFiles())
            {
                if (extensions.Add(file.Extension.ToLower()))
                {
                    Console.WriteLine(file.Extension);
                }
            }

            var filename = "Test.xml";
            string text = "";

            //Erkläre den nachfolgenden Code so genau wie möglich. 
            //Warum benutzen wir hier using und was genau macht es?
            //Versuche erst selbsständig jede Zeile zu erklären
            //Wenn du nicht weiter kommst dann versuche zuerst ohne
            //ChatGTP zu rechergieren
            using (FileStream fs = File.OpenWrite(filename))
            {
                byte[] buffer = new UTF8Encoding().GetBytes(text);
                fs.Write(buffer, 0, buffer.Length);
            }

            using(FileStream fs = File.OpenRead(filename))
            {
                byte[] bytes = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                if(fs.Read(bytes, 0, bytes.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(bytes));
                }
            }

            
        }

    }
}
