using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    [Serializable()]

    public class Animal12 : ISerializable
    {

        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal12() { }

        public Animal12(string name = "No Name", double weight = 0, double height = 0, int animalID = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
            AnimalID = animalID;
        }

        public override string ToString()
        {
            return string.Format("{0} weighs {1} kg and is {2} cm tall",Name,Weight,Height);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
            info.AddValue("AnimalID", AnimalID);
        }

        public Animal12(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
            AnimalID = (int)info.GetValue("AnimalID", typeof(int));
        }
    }
}