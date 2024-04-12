using Problems2.Models;
using System;

namespace Problems2
{
    class Program
    {
        static int GetIntegerInputFromConsole() {
            int val;
            while (!int.TryParse(Console.ReadLine(), out val))
            {
                Console.WriteLine("Invalid Value. Please Provide a valid value! The value you entered should only contain digits");
            }
            return val;
        }

        static bool CheckForDigitInAString(string s) {
            for (int i = 0; i < s.Length; i++) { 
                if (char.IsDigit(s[i])) 
                    return true;
            }
            return false;        
        }

        static string GetStringInput(string val) {
            string userInput = string.Empty;
            while (true) {
                PrintStatement(val);
                userInput = Console.ReadLine();
                if (CheckForDigitInAString(userInput)) {
                    Console.Write("Invalid Input! Enter the proper value again.It should not contain any digits!");
                    PrintStatement(val);
                }
                else
                {
                    break;
                }
            }
            return userInput;
        }

        static void PrintStatement(string s) {
            Console.WriteLine($"Enter the Doctor {s} : ");
        }

        Doctor CreateDoctorByTakingInput(int id)
        {
            Doctor doctor = new Doctor(id);
            doctor.Name = GetStringInput("Name");
            Console.WriteLine("Enter the Doctor Age : ");
            doctor.Age = GetIntegerInputFromConsole();
            Console.WriteLine("Enter the Doctor Experience : ");
            doctor.Exp = GetIntegerInputFromConsole();
            doctor.Qualification = GetStringInput("Qualification"); ;
            doctor.Speciality = GetStringInput("Specialization"); ;
            return doctor;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Enter the number of Doctors to be added : ");
            int n = GetIntegerInputFromConsole();
            Doctor[] doctors = new Doctor[n];
            for (int i = 0; i < n; i++)
            {
                doctors[i] = program.CreateDoctorByTakingInput(i + 1);
            }
            Console.WriteLine("\n\n\nDoctors Available");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nDoctor {i+1}");
                doctors[i].PrintDoctorDetails(true);
                Console.WriteLine("--------------------------------");
            }

            Console.WriteLine("\n\nEnter the Speciality to see the doctors available with it : ");
            string speciality = "";
            while (true)
            {
                speciality = Console.ReadLine();
                if (speciality == null || CheckForDigitInAString(speciality))
                {
                    Console.WriteLine("Invalid Value. Please provide a valid Value");
                }
                break;
            }

            Console.WriteLine($"Doctors with {speciality} speciality");
            for (int i = 0; i < n; i++)
            {
                if (doctors[i].Speciality == speciality)
                {
                    doctors[i].PrintDoctorDetails(false);
                    Console.WriteLine("--------------------------------");
                }
            }

        }
    }
}
