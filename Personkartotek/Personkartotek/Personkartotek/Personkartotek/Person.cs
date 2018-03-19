using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personkartotek
{
    public class Person
    {
        public Person(string fornavn, string mellemnavn, string eftermnavn, string type, IAdress contacktAdress)
        {
            Fornavn = fornavn;
            Mellemnavn = mellemnavn;
            Eftermnavn = eftermnavn;
            Type = type;
            var person = this;
            PrimAdress = new Item(ref contacktAdress,ref person, "Prim");
         
        }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Eftermnavn { get; set; }

        public void 

        public string FullName
        {
            get { return Fornavn + " " + (Mellemnavn == "" ? "" : (" " + Mellemnavn)) + " " + Eftermnavn; }

        }
        public Item PrimAdress
        {
            get {
                foreach (var VARIABLE in JoinPersonAdress.GetAllPersonsAdresses(this))
                {
                    if (VARIABLE.Type == "Prim")
                    {
                        return VARIABLE;
                    }
                }
                return new Item( "error");
            }
            set
            {
                JoinPersonAdress.AddEntry(value);
            }
        }
        

        public void AddAlternativeAdress(ref IAdress Adress, string type)
        {
            var person = this;
            JoinPersonAdress.AddEntry(new Item(ref Adress,ref person, type));
        }
        

        public void Print()
        {
            Console.WriteLine("\nPrinting Person:");
            Console.WriteLine("\nName: {0}\n", FullName);

            Console.WriteLine("\tPrim kontakt adresse:");

            Console.WriteLine("\t\t" + JoinPersonAdress.GetPrimAdresses(this).ToString());

            Console.WriteLine("\tAlternativ adresses:");
            foreach (var VARIABLE in JoinPersonAdress.GetAllPersonsAdresses(this))
            {
                if (VARIABLE.Type != "Prim")
                {
                    Console.WriteLine("\t\t" + VARIABLE.Type + " " + VARIABLE.Adress.ToString());
                }
            }



        }

    }

}
