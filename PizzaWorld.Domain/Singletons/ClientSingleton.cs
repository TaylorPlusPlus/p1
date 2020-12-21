using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;
using System.Linq;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private const string Path = @"pizzaworld.xml";
        public static ClientSingleton _instance;
        public static ClientSingleton Instance {
            get
            {
                if(_instance == null)
                {
                     _instance = new ClientSingleton();
                }
                return _instance;
            }
        }
        
        public List<Store> Stores { get; set;}
        private ClientSingleton()
        {
           Read();
        }

        public Store SelectStore()
        {
            Console.WriteLine("Select A Store");
            int.TryParse(Console.ReadLine(), out  int input);
           // Stores.Where(s => s == input);

            return Stores.ElementAtOrDefault(input);
            // All of the following code reduces to return Stores.ElementAt(input)
/*
            Store store = Stores.ElementAt(input);
           // Stores.FirstOrDefault(s => s == input);
            if(Stores.ElementAtOrDefault(input) != null)
            {
                return store;
            }else
            {
                return null;
            }
*/
            

        }
       

        public void MakeAStore()
        {
            var s = new Store();
            Stores.Add(s);
            Save();
        }
        private void Save()
        {
            string path  = @"pizzaworld.xml";
            var file = new StreamWriter(path);
            var xml = new XmlSerializer(typeof(List<Store>));
            xml.Serialize(file, Stores);

        }

         public void Read()
        {
            if(File.Exists(Path)){
                var file = new StreamReader(Path);
                var xml = new XmlSerializer(typeof(List<Store>));
                Stores = xml.Deserialize(file) as List<Store>;  
            }else
            {
                Stores = new List<Store>();
            }
        }
    }
}