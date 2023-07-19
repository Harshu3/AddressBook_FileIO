using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_FileIO
{
    public class Address_Book
    {
        List<Address> addresses;

        public Address_Book()
        {
            addresses = new List<Address>();
        }

        public bool Add(string firstName, string lastName, string address, string city, string state, int zip, int phone, string email)
        {
            Address addr = new Address(firstName, lastName, address, city, state, zip, phone, email);
            Address result = Find(firstName);

            if (result == null)
            {
                addresses.Add(addr);
                return true;
            }
            else
                return false;
        }

        public Address Find(string name)
        {
            Address addr = addresses.Find((a) => a.firstName == name);
            return addr;
        }

        public void List(Action<Address> action)
        {
            addresses.ForEach(action);
        }

        public bool IsEmpty()
        {
            return (addresses.Count == 0);
        }
    }
}
