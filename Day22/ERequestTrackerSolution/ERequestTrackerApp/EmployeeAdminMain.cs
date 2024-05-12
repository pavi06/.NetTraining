using ERequestTrackerBLL1Library;
using ERequestTrackerBLLLibrary;
using ERequestTrackerBLLLibrary.CustomExceptions;
using ERequestTrackerBLLLibrary.Exceptions;
using ERequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerApp
{
    public class EmployeeAdminMain
    {
        async Task<int> UserMenu()
        {
            await Console.Out.WriteLineAsync("\n-------Main Menu---------\n1.Raise Request\n2.View all the request raised\n3.View all solution" +
                "\n4.Give comment for the solution provided\n5.Give Feedback for the solution\n" +
                "6.Provide solution\n7.Update the requests\n8.View Feedbacks\n9.UpdateRequestRaisedByThem\n10.Logout");
            List<int> validChoices = new List<int> { 1, 2, 3, 4, 5, 6,7,8,9,10 };
            int userInput;
            do
            {
                Console.WriteLine("Enter your choice : ");
            }
            while (!int.TryParse(Console.ReadLine(), out userInput) && !validChoices.Any(c => c == userInput));
            return userInput;
        }

        async Task ProvideSolutionForRequest(EmployeeAdminBL employeeAdminBL)
        {
            try
            {
                Console.WriteLine("Provide the request id : ");
                int reqId = Convert.ToInt32(Console.ReadLine());
                if (await employeeAdminBL.CheckObjectAvailableOrNot("request", reqId))
                {
                    Console.WriteLine("Provide the solution description : ");
                    string solution = Console.ReadLine();
                    RequestSolution reqSolution = new RequestSolution() { RequestId = reqId, SolutionDescription = solution };
                    await Console.Out.WriteLineAsync(employeeAdminBL.ProvideSolutionForRequestRaised(reqSolution).Result.ToString());
                }
                else
                {
                    await Console.Out.WriteLineAsync($"Request with id - {reqId} not available");
                }
            }
            catch (ObjectAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        async Task ViewSolutions(EmployeeMain userMain, EmployeeAdminBL employeeAdminBL)
        {
            Console.WriteLine("1.View all solution for the request\n2.All solutions\nEnter your choice : ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    await userMain.GetAllSolutionsForRequest(employeeAdminBL);
                    break;
                case 2:
                    try
                    {
                        var getAllSolutions = await employeeAdminBL.GetAllSolutionsForAdmin();
                        foreach (var solution in getAllSolutions)
                        {
                            Console.WriteLine(solution.ToString());
                        }
                    }
                    catch (NoObjectsAvailableException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                default:
                    await Console.Out.WriteLineAsync("Invalid input!");
                    break;
            }
        }

        public async Task Starter(Employee user, IEmployeeLoginBL employeeLoginBl)
        {
            EmployeeAdminBL employeeAdminBL = new EmployeeAdminBL(user);
            EmployeeMain userMain = new EmployeeMain();
            var choice = 0;
            do
            {
                choice = UserMenu().Result;
                switch (choice)
                {
                    case 1:
                        await userMain.CreateRequest(employeeAdminBL);
                        break;

                    case 2:
                        try
                        {
                            List<Request> reqsRaised = await employeeAdminBL.GetAllRequest();
                            foreach (var req in reqsRaised)
                            {
                                Console.WriteLine(req.ToString());
                            }
                        }
                        catch (NoObjectsAvailableException e)
                        {
                            Console.WriteLine(e.Message);
                        }                        
                        break;

                    case 3:
                        ViewSolutions(userMain, employeeAdminBL);
                        break;

                    case 4:
                        await userMain.ProvideComment(employeeAdminBL);
                        break;

                    case 5:
                        await userMain.ProvideFeedback(employeeAdminBL);
                        break;

                    case 6:
                        await ProvideSolutionForRequest(employeeAdminBL);         
                        break;

                    case 7:
                        try
                        {
                            await employeeAdminBL.GetAllRequestAndUpdate();
                        }
                        catch (NoObjectsAvailableException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 8:
                        try
                        {
                            List<SolutionFeedback> feedbacks = await employeeAdminBL.ViewFeedbacks();
                            foreach (var feedback in feedbacks)
                            {
                                await Console.Out.WriteLineAsync(feedback.ToString());
                            }
                        }
                        catch (NoObjectsAvailableException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 9:
                        await Console.Out.WriteLineAsync("Enter the request id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        await employeeAdminBL.UpdateRequestRaisedByThem(id);
                        break;

                    case 10:
                        userMain.Logout(employeeLoginBl);
                        break;

                    default:
                        await Console.Out.WriteLineAsync("Invalid Input!");
                        break;
                }
            } while (choice != 10);
        }
    }
}
