using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork
{
    public class Menu
    {
        ProgramLogic programLogic;
        public Menu() 
        {
            programLogic = new ProgramLogic();
            MainMenu();
        }
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Poshta:\n1-Search Subscriber" +
                    "\n2-Search Postmen\n3-Count Subscribers of magazine\n4-Premium subscribers to whom the postman brings magazines from certain branches" +
                    "\n5-Show full Table\n6-Show a subscribers of Magazine\n7-Exit");
                string check = Console.ReadLine();
                switch (check)
                {
                    case "1":
                        SearchSubscriber();
                        break;
                    case "2":
                        SearchPostmen();
                        break;
                    case "3":
                        CountMagazine();
                        break;
                    case "4":
                        TaskOne();
                        break;
                    case "5":
                        ShowFull();
                        break;
                    case "6":
                        ShowSubMag();
                        break;
                    case "7":
                        break;
                    default:
                        IncorrectData();
                        WaitMenu();
                        break;
                }
                if (check == "7")
                    break;
            }
        }

        private void ShowSubMag()
        {
            Console.Clear();
            string magazine;
            Console.WriteLine("Enter a name of magazine");
            magazine = Console.ReadLine();
            programLogic.SearchSubscriber("magazine", magazine);
            WaitMenu();
        }

        private void WaitMenu()
        {
            Console.WriteLine("Press 'Enter' to continue\n");
            Console.ReadLine();
        }

        private void IncorrectData()
        {
             Console.WriteLine("Incorrect data\n");
        }

        private void ShowFull()
        {
            Console.Clear();
            Console.WriteLine("Select a table:\n1-Subscribers" +
                "\n2-PremiumSubscribers\n3-Magazines\n4-Departments" +
                "\n5-Postmens\n6-Subscriptions\n7-Mailboxes\n8-Exit");
            string check = Console.ReadLine();
            switch (check)
            {
                case "1":
                    programLogic.ShowAllEntities("Subscribers");
                    break;
                case "2":
                    programLogic.ShowAllEntities("PremiumSubscriber");
                    break;
                case "3":
                    programLogic.ShowAllEntities("Magazines");
                    break;
                case "4":
                    programLogic.ShowAllEntities("Departments");
                    break;
                case "5":
                    programLogic.ShowAllEntities("Postmens");
                    break;
                case "6":
                    programLogic.ShowAllEntities("Subscriptions");
                    break;
                case "7":
                    programLogic.ShowAllEntities("Mailboxes");
                    break;
                case "8":
                    break;
                default:
                    IncorrectData();
                    break;
            }
            WaitMenu();
        }

        private void TaskOne()
        {
            Console.Clear();
            string address;
            Console.WriteLine("Enter a name of address, where locate department");
            address = Console.ReadLine();
            programLogic.SearchSubscriber("task1", address);
            WaitMenu();
        }

        private void CountMagazine()
        {
            Console.Clear();
            programLogic.SearchSubscriber("task2", "");
            WaitMenu();
        }

        private void SearchPostmen()
        {
            Console.Clear();
            Console.WriteLine("Select a type of search\n1-Search by First name" +
                "\n2-Search by Last name\n3-Search by department\n4-Exit");
            string check = Console.ReadLine();
            string data;
            switch (check)
            {
                case "1":
                    Console.WriteLine("Enter a First name");
                    data= Console.ReadLine();
                    programLogic.SearchPostmen("firstname", data);
                    break;
                case "2":
                    Console.WriteLine("Enter a Last name");
                    data = Console.ReadLine();
                    programLogic.SearchPostmen("lastname", data);
                    break;
                case "3":
                    Console.WriteLine("Enter number of department");
                    data = Console.ReadLine();
                    programLogic.SearchPostmen("depart", data);
                    break;
                case "4":
                    break;
                default:
                    IncorrectData();
                    break;
            }
            WaitMenu();
        }

        private void SearchSubscriber()
        {
            Console.Clear();
            Console.WriteLine("Select a type of search\n1-Search by First name" +
                "\n2-Search by Last name\n3-Search by Town\n4-Search by Postmen Last Name\n5-Search subscribers with Mailbox(sort by Last Name)" +
                "\n6-Show premium Subscribers\n7-Search by full name\n8-Search by address\n9-Exit");
            string check = Console.ReadLine();
            string data,data2,data3;
            switch (check)
            {
                case "1":
                    Console.WriteLine("Enter a First name");
                    data = Console.ReadLine();
                    programLogic.SearchSubscriber("firstname", data);
                    break;
                case "2":
                    Console.WriteLine("Enter a Last name");
                    data = Console.ReadLine();
                    programLogic.SearchSubscriber("lastname", data);
                    break;
                case "3":
                    Console.WriteLine("Enter a town");
                    data = Console.ReadLine();
                    programLogic.SearchSubscriber("town", data);
                    break;
                case "4":
                    Console.WriteLine("Enter a Postmen Last Name");
                    data = Console.ReadLine();
                    programLogic.SearchSubscriber("postmen", data);
                    break;
                case "5":
                    programLogic.SearchSubscriber("mailbox", "");
                    break;
                case "6":
                    programLogic.SearchSubscriber("premium", "");
                    break;
                case "7":
                    Console.WriteLine("Enter a First Name");
                    data = Console.ReadLine();
                    Console.WriteLine("Enter a Last Name");
                    data2 = Console.ReadLine();
                    List<string> datalist = new List<string>() { data,data2};
                    programLogic.SearchSubscriberComplex("fullname", datalist);
                    break;
                case "8":
                    Console.WriteLine("Enter a Street");
                    data = Console.ReadLine();
                    Console.WriteLine("Enter a Number of House");
                    data2 = Console.ReadLine();
                    Console.WriteLine("Enter a Number of Flat");
                    data3 = Console.ReadLine();
                    List<string> datalist1 = new List<string>() { data, data2,data3 };
                    programLogic.SearchSubscriberComplex("address", datalist1);
                    break;
                case "9":
                    break;
                default:
                    IncorrectData();
                    break;
            }
            WaitMenu();
        }
    }
}
