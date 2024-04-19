﻿using RequestTrackerBLLLibrary;
using RequestTrackerBLLLibrary.CustomExceptions;
using RequestTrackerModelLibrary;

namespace RequestTrackerApp
{
    internal class Program
    {
        void AddDepartment()
        {

            DepartmentBL departmentBL = new DepartmentBL();
            try
            {
                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Pleae enter the department name");
                name = Console.ReadLine();
                department = new Department() { Name = name };
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        static void Main(string[] args)
        {
            new Program().AddDepartment();

        }
    }
}
