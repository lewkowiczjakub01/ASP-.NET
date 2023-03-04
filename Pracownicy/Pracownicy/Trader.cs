using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Workers.GenerateID;

namespace Workers {


    public class Trader : Worker
    {
        private EFFECTIVNESS effectivness;
        private int? commision;

        public Trader() { }
        public Trader(string name, string surname, int age, int experience, Address address, EFFECTIVNESS effectivness,int? commision)
        {
            this.id = GeneratedID();
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.experience = experience;
            this.address = address;
            this.effectivness = effectivness;
            if (commision <= 100 && commision >= 0)
                this.commision = commision;
            else
                this.commision = null;
        }

        public int? getCommision() { return commision; }
        public void setCommision(int? commision) {
            if (commision <= 100 && commision >= 0)
                this.commision = commision;
            else
                this.commision = null;
        }
        public EFFECTIVNESS getEffectivness() { return effectivness; }
        public void setEffectivness(EFFECTIVNESS effectivness) { this.effectivness = effectivness; }
        public override string ToString() {
            return "ID: " + id + "\nName: " + name + "\nSurname: " + surname + "\nAge: " + age +
                "\nExperience: " + experience + "\nAdress: " + address + "\nEffectivness: " +
                effectivness +"\nCommision: " + commision + "%\nEmployee value: " +
                experience*(int)effectivness + "\n\n";
        }
    }
}