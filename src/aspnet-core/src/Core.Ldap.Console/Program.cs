using Core.Ldap.Console._03;
using System;
using System.DirectoryServices;
using Utils;

namespace Core.Ldap.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Utility utility = new Utility();
            //SearchResultCollection directoryEntry = Utility.getUsers();
            //System.Console.WriteLine(directoryEntry);

            //ADUser.GetUsers("192.168.231.230", "Administrator","Chemical.ai");

            AdUserController adUserController = new AdUserController();
            adUserController.Sync();

            //Login();

            System.Console.Read();

        }


        public static void Login()
        {
            string username = "ayi";
            string password = "Chemical.ai";

            var loginFlag = LDAPUtil.Validate(username, password);

            if (loginFlag)
            {
                System.Console.WriteLine("User validate successfully!");
            }
            else
            {
                System.Console.WriteLine("User validate unsuccessfully!");
            }

            System.Console.ReadLine();
        }
    }
}
