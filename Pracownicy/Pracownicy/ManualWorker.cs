using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Workers.Worker;
using static Workers.GenerateID;

namespace Workers
{
    public class ManualWorker : Worker
    {
        private int? strength;

        public ManualWorker() { }
        public ManualWorker(string name, string surname, int age, int experience, Address address, int? strength)
        {
            this.id = GeneratedID();
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.experience = experience;
            this.address = address;
            if (strength <= 100 && strength >= 1)
                this.strength = strength;
            else
                this.strength = null;
        }

        public int? getStrength() { return strength; }
        public void setStrength(int? strength) {
            if (strength <= 100 && strength >= 1)
                this.strength = strength;
            else
                this.strength = null;
        }
        public override string ToString() {
            return "ID: " + id + "\nName: " + name + "\nSurname: " + surname + "\nAge: " + age +
                "\nExperience: " + experience + "\nAdress: " + address + "\nStrength: " + strength +
                "\nEmployee value: " + experience*strength/age + "\n\n";
        }
    }
}

