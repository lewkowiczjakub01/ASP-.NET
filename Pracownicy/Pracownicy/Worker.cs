using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers {
    public enum EFFECTIVNESS {
        LOW = 60,
        MEDIUM = 90,
        HIGH = 120
    }
    public abstract class Worker {
        public int id;
        public string name;
        public string surname;
        public int age;
        public int experience;
        public Address address;
        public static List<Worker> workers = new List<Worker>();

        public int GetId() { return id; }
        public string getName() { return name; }
        public void setName(string name) { this.name = name; }
        public string getSurname() { return surname; }
        public void setSurname(string surname) { this.surname = surname; }
        public int getAge() { return age; }
        public void setAge(int age) { this.age = age; }
        public int getExperience() { return experience; }
        public void setExperience(int experience) { this.experience = experience; }
        public Address getAddress() { return address; }
        public void setAddress(Address address) { this.address = address; }
        public static string viewAllWorkers() {
            string all = "";
            foreach (var i in workers)
                all += i.ToString();
            return all;
        }
        public static void addWorker(Worker worker) { workers.Add(worker); }
        
        public static void removeWorker(int id) { workers.RemoveAll(i => i.id == id); }
        public static string WorkersSortByExperience() {
            List<Worker> sorted = workers.OrderByDescending(i => i.experience).ToList();
            string all = "";
            foreach (var i in sorted)
                all += i.ToString();
            return all;
        }
        public static string WorkersSortByAge() {
            List<Worker> sorted = workers.OrderBy(i => i.age).ToList();
            string all = "";
            foreach (var i in sorted)
                all += i.ToString();
            return all;
        }
        public static string WorkersSortBySurname() {
            List<Worker> sorted = workers.OrderBy(i => i.surname).ToList();
            string all = "";
            foreach (var i in sorted)
                all += i.ToString();
            return all;
        }
        public static string WorkersCity(string city) {
            List<Worker> found = new List<Worker>();
            foreach(var i in workers) {
                if( city.Equals(i.address.getCity()))
                    found.Add(i);
            }
            string all = "";
            foreach (var i in found)
                all += i.ToString();
            return all;
        }
        public static void addFewWorkers(params Worker[] wok) {
            foreach (var i in wok)
                workers.Add(i);
        }
        public abstract override string ToString();
    }
}
