using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class PathStorage
    {

        public static void SavePath(string fileName, string buffer)
        {
            try
            {            
                using ( StreamWriter writer = new StreamWriter(fileName))// use streamWriter
                {
                    writer.Write(buffer);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You does not have the required permission for file");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        }

        public static string LoadPath(string fileName)
        {
            string buffer = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(fileName)) // use streamReader to read from file
                {
                    buffer = reader.ReadToEnd();
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You does not have the required permission for file");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error occurred while opening the file");
            }

           return buffer;
        }
    }
    
}
