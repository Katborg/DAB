using System;
using System.Collections.Generic;

namespace Personkartotek
{
    public static class JoinPersonAdress
    {
        private static List<Item> JoinList;

        static JoinPersonAdress()
        {
            JoinList = new List<Item>();
        }

        public static void AddEntry(Item item)
        {
            JoinList.Add(item);
        }

        public static  List<Item> GetAllPersonsAdresses(Person person)
        {
            List<Item> retunlist = new List<Item>();

                foreach (var variable in JoinList)
                {
                    if (variable.Person == person)
                    {
                        retunlist.Add(variable);
                    }
                }

            return retunlist;
        }
        public static List<Item> GetAllAdresseOccupant(IAdress adress)
        {
            List<Item> retunlist = new List<Item>();

            foreach (var variable in JoinList)
            {
                if (variable.Adress == adress)
                {
                    retunlist.Add(variable);
                }
            }

            return retunlist;
        }

        public static bool CorrectAdress(string before, string after)
        {
            foreach (var variable in JoinList)
            {
                if (variable.Adress.VejNavnOgNummer == before)
                {
                    variable.Adress.VejNavnOgNummer = after;
                    return true;
                }
            }

            return false;
        }

        public static string GetPrimAdresses(Person person)
        {

            foreach (var variable in JoinList)
            {
                if (variable.Person == person && variable.Type == "Prim")
                {
                    return variable.Adress.ToString();
                }
            }

            return "error";
        }

        public static void  printList()
        {
            Console.WriteLine("\nPrinting Join Person Adress List");
            foreach (var VARIABLE in JoinList)
            {
                Console.WriteLine(VARIABLE.Adress.VejNavnOgNummer + " " + VARIABLE.Person.Fornavn + " " + VARIABLE.Type);
            }
        }
    }
}
