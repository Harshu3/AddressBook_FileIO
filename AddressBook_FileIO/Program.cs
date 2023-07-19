using System;

namespace AddressBook_FileIO
{
    class AddressPrompt
    {
        Address_Book book;

        public AddressPrompt()
        {
            book = new Address_Book();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            string selection = "";
            AddressPrompt prompt = new AddressPrompt();

            while (!selection.ToUpper().Equals("Q"))
            {
                prompt.displayMenu();
                Console.WriteLine("\nSelect from above options:");
                selection = Console.ReadLine();
                Console.WriteLine("=========");
                prompt.performAction(selection);
            }
        }
        void displayMenu()
        {
            Console.WriteLine("\nADDRESS BOOK\n");
            Console.WriteLine("A - Add a Contact Details");
            Console.WriteLine("L - List All Contact Details");
            Console.WriteLine("E - Edit Contact Details");
            Console.WriteLine("Q - Quit");
        }

        void performAction(string selection)
        {
            string firstName = "";
            string lastName = "";
            string address = "";
            string city = "";
            string state = "";
            int zip;
            int phone;
            string email = "";

            switch (selection.ToUpper())
            {
                case "A":
                    Console.WriteLine("To add a Contact");
                    Console.WriteLine("Enter First Name:");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    lastName = Console.ReadLine();
                    Console.WriteLine("Enter Address:");
                    address = Console.ReadLine();
                    Console.WriteLine("Enter City:");
                    city = Console.ReadLine();
                    Console.WriteLine("Enter State:");
                    state = Console.ReadLine();
                    Console.WriteLine("Enter Zip Code");
                    zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Phone Number:");
                    phone = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Email:");
                    email = Console.ReadLine();

                    if (book.Add(firstName, lastName, address, city, state, zip, phone, email))
                    {
                        Console.WriteLine("Contact successfully added!");
                        Console.WriteLine("---------------");
                    }
                    else
                        Console.WriteLine("An address is already on file for {0}", firstName);
                    break;
                case "L":
                    if (book.IsEmpty())
                        Console.WriteLine("There are no entries");
                    else
                    {
                        Console.WriteLine("----------------");
                        Console.WriteLine("LIST OF CONTACT DETAILS:");
                        book.List((a) => Console.WriteLine("First Name: {0}\n Last Name: {1}\n Address: {2}\n City: {3}\n State: {4}\n Zip Code: {5}\n Phone Number: {6}\n Email: {7} \n-------------", a.firstName, a.lastName, a.address, a.city, a.state, a.zip, a.phone, a.email));
                    }
                    break;
                case "E":
                    Console.WriteLine("Enter contact name you want to edit:");
                    firstName = Console.ReadLine();
                    Address addr = book.Find(firstName);
                    Console.WriteLine("Please choose what details you want to edit from below:");
                    Console.WriteLine("1.Address\n2.Phone Number");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (addr != null)
                    {
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter new Address:");
                                addr.address = Console.ReadLine();
                                Console.WriteLine("Address updated for {0}", firstName);
                                Console.WriteLine("---------------");
                                break;
                            case 2:
                                Console.WriteLine("Enter new Phone Number:");
                                addr.phone = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Phone Number Updated for {0}", firstName);
                                Console.WriteLine("---------------");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("Details for {0} not be found", firstName);
                    break;
            }
        }
    }
}