using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Data;

namespace BinarySerialization2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\data";

            if (Class1.Version == 1)
            {
                Console.WriteLine("Writing data");
                File.WriteAllBytes(path, SerializeHelper<Class1>.Serialize(new Class1() { SomeInt = 42, SomeString = "HelloWorld", Next = new Class1() { SomeInt = 3, SomeString = "Boo" } }));
            }

            Console.WriteLine(Class1.Version);
            Console.WriteLine(SerializeHelper<Class1>.Deserialize(File.ReadAllBytes(path)).ToString());
        }
    }

    public class SerializeHelper<T>
    {
        public static byte[] Serialize(T obj)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        public static T Deserialize(byte[] bytes)
        {
            using (var stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)new BinaryFormatter().Deserialize(stream);
            }
        }
    }
}
