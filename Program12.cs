using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp12;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ConsoleApp12
{
    public class Program12
    {
        //Functions



        static void Main(string[] args)
        {
            //directories
            #region Directories
            DirectoryInfo currDir = new DirectoryInfo(".");
            DirectoryInfo myDirectory = new DirectoryInfo(@"C:\Users\bryns");
            Console.WriteLine(myDirectory.FullName);
            Console.WriteLine(myDirectory.Name);
            Console.WriteLine(myDirectory.Parent);
            Console.WriteLine(myDirectory.Attributes);
            Console.WriteLine(myDirectory.CreationTime);

            DirectoryInfo dataDir = new DirectoryInfo(@"D:\OCOMPSCI\direct");
            dataDir.Create();
            //Directory.Delete(@"D:\OCOMPSCI\direct");
            #endregion
            //reading and writing files
            #region R/W
            string[] customers =
            {
                "Bob Smith",
                "Sally Smith",
                "Robert Smith"
            };
            string textFilePath = @"D:\OCOMPSCI\direct\testfile1.txt";
            File.WriteAllLines(textFilePath, customers);

            foreach(string customer in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine($"Customer : {customer}");
            }

            DirectoryInfo myDataDirectory = new DirectoryInfo(@"D:\OCOMPSCI\direct");
            FileInfo[] txtFiles = myDataDirectory.GetFiles("*.txt",SearchOption.AllDirectories);
            Console.WriteLine("Matches : {0}",txtFiles.Length);
            foreach(FileInfo file in txtFiles)
            {
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Length);
            }
            #endregion
            //FileStreams
            #region Filestreams
            string textFilePath2 = @"D:\OCOMPSCI\direct\testfile2.txt";
            FileStream fs = File.Open(textFilePath2,FileMode.Create);
            string randString = "This is a random string";
            byte[] rsByteArray = Encoding.Default.GetBytes(randString);
            fs.Write(rsByteArray, 0, rsByteArray.Length);
            fs.Position = 0;

            byte[] fileByteArray = new byte[rsByteArray.Length];

            for (int i = 0; i < rsByteArray.Length; i++)
            {
                fileByteArray[i] = (byte)fs.ReadByte();
            }

            Console.WriteLine(Encoding.Default.GetString(fileByteArray));
            fs.Close();
            #endregion
            //Stream writer and reader
            #region Stream R/W
            string textFilePath3 = @"D:\OCOMPSCI\direct\testfile3.txt";
            StreamWriter sw = new StreamWriter(textFilePath3);
            sw.Write("This is a random ");
            sw.WriteLine("sentence.");
            sw.WriteLine("This is another sentence yo yo");
            sw.Close();

            StreamReader sr = new StreamReader(textFilePath3);
            Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek()));
            Console.WriteLine("1st String : {0}", sr.ReadLine());
            Console.WriteLine("Everything Else : {0}", sr.ReadToEnd());
            sr.Close();
            #endregion
            //Binary writer and reader
            #region Binary R/W
            string textFilePath4 = @"D:\OCOMPSCI\direct\testfile4.txt";
            FileInfo datFile = new FileInfo(textFilePath4);
            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());
            string randText = "Random Text";
            int myAge = 17;
            double height = 6.25;
            bw.Write(randText);
            bw.Write(myAge);
            bw.Write(height);
            bw.Close();

            BinaryReader br = new BinaryReader(datFile.OpenRead());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            br.Close();
            #endregion
            //Serialisation
            #region Serialisation
            //store the state of an object in a filestream and can be passed to a remote network,...
            Animal12 bowser = new Animal12("Bowser", 45, 25, 1);
            /*Stream stream = File.Open("AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new();
            bf.Serialize(stream, bowser); //SENDING OBJECT DATA TO FILE
            stream.Close();

            bowser = null;

            stream = File.Open("AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();

            bowser = (Animal)bf.Deserialize(stream);
            stream.Close();

            Console.WriteLine(bowser.ToString());*/
            #endregion
            //Xmlserialiser
            #region XmlSerialiser
            XmlSerializer serializer = new XmlSerializer(typeof(Animal12));
            using (TextWriter tw = new StreamWriter(@"D:\OCOMPSCI\direct\bowser.xml"))
            {
                serializer.Serialize(tw, bowser);
            }

            bowser = null; // to delete the bowser data

            XmlSerializer deserializer = new XmlSerializer(typeof(Animal12));
            TextReader reader = new StreamReader(@"D:\OCOMPSCI\direct\bowser.xml");
            object obj = deserializer.Deserialize(reader);
            bowser = (Animal12)obj;
            reader.Close();
            Console.WriteLine(bowser.ToString());
            #endregion
            //with arrays
            #region
            List<Animal12> theAnimals = new List<Animal12>
            {
                new Animal12("Mario", 60, 30, 2),
                new Animal12("Luigi", 55, 24, 3),
                new Animal12("Peach", 40, 20, 4),
            };

            using (Stream fs2 = new FileStream(@"D:\OCOMPSCI\direct\animals.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Animal12>));
                serializer2.Serialize(fs2, theAnimals);
            }
            theAnimals = null;

            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Animal12>));

            using (FileStream fs3 = File.OpenRead(@"D:\OCOMPSCI\direct\animals.xml"))
            {
                theAnimals = (List<Animal12>)serializer3.Deserialize(fs3);
            }
            foreach (Animal12 a in theAnimals)
            {
                Console.WriteLine(a.ToString);
            }
            #endregion

        }
    }
}