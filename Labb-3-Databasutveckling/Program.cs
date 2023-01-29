using Labb_3_Databasutveckling.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Labb_3_Databasutveckling
{
    class Program : DbContext
    {
        static void Main(string[] args)
        {
            NavigationMenu();
        }
        public static void NavigationMenu()
        {
            Console.WriteLine("Would you like to do? ");
            Console.WriteLine("1. Get Student Data ");
            Console.WriteLine("2. Get Students from a specific class ");
            Console.WriteLine("3. Add new employee to database");
            Console.WriteLine("4. Get Employee Data ");
            Console.WriteLine("5. Exit App");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetStudentData();
                    break;
                case 2:
                    GetStudentClass();
                    break;
                case 3:
                    AddEmployee();
                    break;
                case 4:
                    GetEmployeeData();
                    break;
                default:
                    Environment.Exit(choice);
                    break;
            }
        }
        public static void GetStudentData()
        {
            Console.Clear();
            var context = new Labb3DbContext();

            //Here we look for our studentIDs and retrieves data from student table
            var Student = context.TblStudent.Where(s => s.StudentId > 0);
            //            context                  s = goto s.studentID from tblStudent
            Console.WriteLine("---------------------List of All Students---------------------");
            foreach (TblStudent item in Student)
            {
                Console.WriteLine("Student ID = {0} ", item.StudentId);
                Console.WriteLine("Firstname = {0}", item.FirstName);
                Console.WriteLine("Lastname = {0}", item.LastName);
                Console.WriteLine("Class = {0}", item.Class);
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine();
            Console.Write("Precis [ Enter ] to sort by");
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();

            //Sort by Menu
            Console.WriteLine("---------Sort Students---------");
            Console.WriteLine("1. Sort by Firstname ");
            Console.WriteLine("2. Sort by Lastname ");
            Console.WriteLine("3. Sort by Firstname Descending ");
            Console.WriteLine("4. Sort by Lastname Descending ");
            Console.WriteLine("5. Menu ");
            int choice = int.Parse(Console.ReadLine());

            //Switch statement to make our choice of how we want to sort our data
            switch (choice)
            {
                case 1:
                    var Class = context.TblStudent.OrderBy(s => s.FirstName);
                    foreach (TblStudent item in Class)
                    {
                        Console.WriteLine("Student ID = {0}", item.StudentId);
                        Console.WriteLine("Firstname = {0}", item.FirstName);
                        Console.WriteLine("Lastname = {0}", item.LastName);
                        Console.WriteLine("Class = {0}", item.Class);
                        Console.WriteLine("----------------------------------");
                    }
                    break;
                case 2:
                    Class = context.TblStudent.OrderBy(s => s.LastName);
                    foreach (TblStudent item in Class)
                    {
                        {
                            Console.WriteLine("Student ID = {0}", item.StudentId);
                            Console.WriteLine("Firstname = {0}", item.FirstName);
                            Console.WriteLine("Lastname = {0}", item.LastName);
                            Console.WriteLine("Class = {0}", item.Class);
                            Console.WriteLine("----------------------------------");
                        }
                    }
                    break;
                case 3:
                    Class = context.TblStudent.OrderByDescending(s => s.FirstName);
                    foreach (TblStudent item in Class)
                    {
                        Console.WriteLine("Student ID = {0}", item.StudentId);
                        Console.WriteLine("Firstname = {0}", item.FirstName);
                        Console.WriteLine("Lastname = {0}", item.LastName);
                        Console.WriteLine("Class = {0}", item.Class);
                        Console.WriteLine("----------------------------------");
                    }
                    break;
                case 4:
                    Class = context.TblStudent.OrderByDescending(s => s.LastName);
                    foreach (TblStudent item in Class)
                    {
                        {
                            Console.WriteLine("Student ID = {0}", item.StudentId);
                            Console.WriteLine("Firstname = {0}", item.FirstName);
                            Console.WriteLine("Lastname = {0}", item.LastName);
                            Console.WriteLine("Class = {0}", item.Class);
                            Console.WriteLine("----------------------------------");
                        }
                    }
                    break;
                default:
                    NavigationMenu();
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            GetStudentData();
        }


        public static void GetStudentClass()
        {
            Console.Clear();
            var context = new Labb3DbContext();
            
            //Retrieves data from all students with a class
            var Student = context.TblStudent.OrderBy(s => s.Class);
            foreach (TblStudent item in Student)
            {
                Console.WriteLine("Class = {0} FullName = {1} {2}", item.Class, item.FirstName, item.LastName);
                Console.WriteLine();
            }
            Console.Write("Would you like to get information from a specific class?\nWrite the Class name: ");
            string UseClassChoice = Console.ReadLine().ToUpper();
            Console.Clear();

            //Orders by class and picks out whichever data input
            var specificClass =
            context.TblStudent
                .Where(c => c.Class == UseClassChoice);
            foreach (TblStudent item in specificClass)
            {
                Console.WriteLine("Class = {0} FullName = {1} {2}", item.Class, item.FirstName, item.LastName);
                Console.WriteLine();
            }           
            Console.WriteLine("Press Enter to return to Main Menu ");
            Console.ReadKey();
            Console.Clear();
            NavigationMenu();

        }
        public static void AddEmployee()
        {
            var context = new Labb3DbContext();

            Console.Clear();


            Console.Write("Firstname: ");
            string FName = Console.ReadLine();
            Console.Write("Lastname: ");
            string LName = Console.ReadLine();
            Console.Write("Role: ");
            string Role = Console.ReadLine();
            //Here we write data to our table
            TblEmployee NewEmployee = new TblEmployee();
            NewEmployee.FirstName = FName;
            NewEmployee.LastName = LName;
            NewEmployee.Role = Role;

            //Here we add the data to the table/database also saves it to the database table, in this case TblEmployee
            context.Add(NewEmployee);
            context.SaveChanges();
            Console.WriteLine("New employee added to database! ");
            Console.ReadKey();
            Console.Clear();
            NavigationMenu();

        }
        public static void GetEmployeeData()
        {
            Console.Clear();
            var context = new Labb3DbContext();

            //Here we look for our studentIDs and retrieves data from student table using LINQ Method Synthax
            var Employee = context.TblEmployee.Where(s => s.EmployeeId > 0);
            Console.WriteLine("---------------------List of All Students---------------------");
            foreach (TblEmployee item in Employee)
            {
                Console.WriteLine("Employee ID = {0} ", item.EmployeeId);
                Console.WriteLine("Firstname = {0}", item.FirstName);
                Console.WriteLine("Lastname = {0}", item.LastName);
                Console.WriteLine("Class = {0}", item.Role);
                Console.WriteLine("----------------------------------");
            }
            Console.ReadKey();
            Console.Clear();
            NavigationMenu();
        }

    }
}
