namespace BombermanGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    // using System.Security;

    public static class IOSerialization
    {
        public static void Serialize(string filePath, ICollection<object> objects)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, objects);
            }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Argument Out Of Range!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found!");
            }
        }

        public static ICollection<object> Deserialize(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (ICollection<object>)bf.Deserialize(fs);
            }
        }
    }
}
