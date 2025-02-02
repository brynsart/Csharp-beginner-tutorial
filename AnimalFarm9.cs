using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp9
{
    class AnimalFarm9 : IEnumerable
    {
        private List<Animal9> animalList = new List<Animal9>();

        public AnimalFarm9(List<Animal9> animalList)
        {
            this.animalList = animalList;
        }

        public AnimalFarm9() { }

        public Animal9 this[int index]
        {
            get { return (Animal9)animalList[index]; }
            set { animalList.Insert(index, value); }
        }

        public int Count
        {
            get
            {
                return animalList.Count;
            }
        }

        public IEnumerator GetEnumerator() //returns an enumerator which is used to iterate through the animal names
        {
            return animalList.GetEnumerator();
        }


    }
}
