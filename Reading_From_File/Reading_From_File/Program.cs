using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reading_From_File
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"C:\Users\Ian James Fannon\Documents\Visual Studio 2015\Projects\Reading_From_File\cSharp.txt";
            input(path);
            writeToFile(path);
            readFromFile(path);
            
            
        }

        public static void input(String path)
        {
            if (!(File.Exists(path)))
            {
                Console.WriteLine("Creating File");
                File.Create(path);
            } 
            else
            {
                Console.WriteLine("File Exists");
            }
        }

        public static void writeToFile(string path)
        {
            String[] input = new String[3];
            Console.Write("Enter 2 lines of text to write to file: ");
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadLine();
            }

            try
            {
                TextWriter writer = new StreamWriter(path);
                for (int i = 0; i < input.Length; i++)
                {
                    writer.WriteLine(input[i]);
                }
                
                writer.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O Error has occurred: " + ex.Message);
            }          
        }

        public static void readFromFile(String path)
        {
            List<String> lines = new List<String>();
            String buffer = "";

            try
            {
                TextReader reader = new StreamReader(path);
                
                while ((buffer = reader.ReadLine()) != null)
                {
                    lines.Add(buffer);
                }
                reader.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O Error has occurred " + ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("The contents of your file are: ");

            foreach (String s in lines)
            {
                Console.WriteLine(s);
            }
        }
    }
}
