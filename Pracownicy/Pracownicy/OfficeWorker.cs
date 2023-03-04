using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Workers.GenerateID;

namespace Workers
{
    public class OfficeWorker : Worker
    {
        private GenerateOfficeID officeID;
        private int? iq;

        public OfficeWorker() { }
        public OfficeWorker(string name, string surname, int age, int experience, Address address, int? iq)
        {
            this.id = GeneratedID();
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.experience = experience;
            this.address = address;
            this.officeID = new GenerateOfficeID();
            if (iq <= 150 && iq >= 70)
                this.iq = iq;
            else
                this.iq = null;
        }
        public int? getIQ() { return iq; }
        public void setIQ(int? iq) {
            if (iq <= 150 && iq >= 70)
                this.iq = iq;
            else
                this.iq = null;
        }
        public GenerateOfficeID GetOfficeID() { return officeID; }
        public override string ToString() {
            return "ID: " + id + "\nName: " + name + "\nSurname: " + surname + "\nAge: " + age +
                "\nExperience: " + experience + "\nAdress: " + address + officeID +"\nIQ: " + iq +
                "\nEmployee value: " + experience* iq + "\n\n";
        }
    }
}
