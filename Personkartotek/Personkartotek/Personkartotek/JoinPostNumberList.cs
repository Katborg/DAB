using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Personkartotek
{
    static public class JoinPostNumberList
    {
        private static List<PostItem> _postList = new List<PostItem>();

        public static void AddEntry(PostItem item)
        {
            _postList.Add(item);
        }
        
        public static List<PostItem> GetAllAdressesInPostNumber(PostNumber post)
        {
            List<PostItem> retunlist = new List<PostItem>();

            foreach (var variable in _postList)
            {
                if (variable.PostNumber == post)
                {
                    retunlist.Add(variable);
                }
            }

            return retunlist;
        }

        public static string GetPostnumberForAdresse(IAdress adress)
        {
            foreach (var variable in _postList)
            {
                if (variable.Adress == adress)
                {
                    return variable.PostNumber.Postnumber.ToString();
                }
            }

            return "error";
        }
        public static void printList()
        {
            Console.WriteLine("\nPrinting Join Post NUmber List");
            foreach (var VARIABLE in _postList)
            {
                Console.WriteLine(VARIABLE.Adress.VejNavnOgNummer + " " + VARIABLE.PostNumber.Postnumber + " " + VARIABLE.PostNumber.City);
            }
        }

    }
}