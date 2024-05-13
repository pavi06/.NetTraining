using ERequestTrackerBLL1Library;
using ERequestTrackerBLLLibrary;
using ERequestTrackerBLLLibrary.CustomExceptions;
using ERequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ERequestTrackerApp
{
    public class EmployeeMain
    {
        async Task<int> UserMenu()
        {
            int userInput = 0;
            List<int> validChoices = new List<int> { 1, 2, 3, 4, 5, 6 };
            await Console.Out.WriteLineAsync("\n-------Main Menu---------\n1.Raise Request\n2.View the request raised\n3.View solution for the request" +
               "\n4.Give comment for the solution provided\n5.Give Feedback for the solution\n6.Logout");
            do
            {
                Console.WriteLine("Enter your choice : ");
            }
            while (!int.TryParse(Console.ReadLine(), out userInput) && !validChoices.Any(c => c == userInput));
            return userInput;              

        }

        public async Task CreateRequest(EmployeeRequestBL employeeRequestBL)
        {
                await Console.Out.WriteLineAsync("Provide the issue : ");
                string issue = Console.ReadLine();
                Request request = new Request() { RequestMessage = issue };
                var reqId = await employeeRequestBL.RaiseRequest(request);
                if (reqId != -1)
                    await Console.Out.WriteLineAsync($"Request raised successfully!\nRequest Id - {reqId}");
                else
                    await Console.Out.WriteLineAsync("your request is not raised! Try again later");

        }

        public async Task ProvideComment(EmployeeRequestBL employeeRequestBL)
        {
            try
            {
                await Console.Out.WriteLineAsync("Please provide the solution Id for the comment : ");
                int solId = Convert.ToInt32(Console.ReadLine());
                if(await employeeRequestBL.CheckObjectAvailableOrNot("solution", solId))
                {
                    await Console.Out.WriteLineAsync("Please provide your comment : ");
                    string comment = Console.ReadLine();
                    if (await employeeRequestBL.CheckRequestRaisedByEmployeeOrNot(solId))
                        await Console.Out.WriteLineAsync(await employeeRequestBL.RespondToSolutionProvided(solId, comment));
                    else
                        await Console.Out.WriteLineAsync("Cannot provide comment for the solution not provided to you!");
                }
                else
                {
                    await Console.Out.WriteLineAsync($"Solution with id - {solId} not available!");
                }
                
            }
            catch (ObjectNotAvailableException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }            
        }

        public async Task ProvideFeedback(EmployeeRequestBL employeeRequestBL)
        {
            await Console.Out.WriteLineAsync("Please provide the solution id : ");
            int solId1 = Convert.ToInt32(Console.ReadLine());
            if(await employeeRequestBL.CheckObjectAvailableOrNot("solution", solId1))
            {                
                if (await employeeRequestBL.CheckRequestRaisedByEmployeeOrNot(solId1))
                {
                    await Console.Out.WriteLineAsync("Provide the rating out of 5 : ");
                    int rating = Convert.ToInt32(Console.ReadLine());
                    await Console.Out.WriteLineAsync("Provide the remarks : ");
                    string remark = Console.ReadLine();
                    SolutionFeedback feedback = new SolutionFeedback() { Rating = rating, Remarks = remark, SolutionId = solId1 };
                    Console.WriteLine(await employeeRequestBL.GiveFeedback(feedback));
                }                    
                else
                    await Console.Out.WriteLineAsync("You Cannot provide feedback for this solution since its not raised by you!");
            }
            else
            {
                await Console.Out.WriteLineAsync($"Solution with id - {solId1} is not available!");
            }
            
        }

        public async Task GetAllSolutionsForRequest(EmployeeRequestBL employeeRequestBL)
        {
            try
            {
                await Console.Out.WriteLineAsync("Please provide the request Id: ");
                int id1 = Convert.ToInt32(Console.ReadLine());
                if (await employeeRequestBL.CheckObjectAvailableOrNot("request", id1))
                {
                    List<RequestSolution> solutions = await employeeRequestBL.GetAllSolutionsForTheRequestRaised(id1);
                    await Console.Out.WriteLineAsync("----------solutions---------");
                    foreach (var solution in solutions)
                    {
                        await Console.Out.WriteLineAsync(solution.ToString());
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync($"Request with id - {id1} is not available!");
                }
            }
            catch (NoObjectsAvailableException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
        }

        public async Task Logout(IEmployeeLoginBL employeeLoginBl)
        {
            await Console.Out.WriteLineAsync(employeeLoginBl.Logout().Result);
        }

        public async Task Starter(Employee user, IEmployeeLoginBL employeeLoginBl)
        {
            EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL(user);
            var choice = 0;
            do
            {
                choice = UserMenu().Result;
                switch (choice)
                {
                    case 1:
                        await CreateRequest(employeeRequestBL);
                        break;

                    case 2:
                        try
                        {
                            await Console.Out.WriteLineAsync("Please provide the request Id : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Request reqRaised = await employeeRequestBL.GetRequestRaised(id);
                            await Console.Out.WriteLineAsync(reqRaised.ToString());
                        }
                        catch (ObjectNotAvailableException e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }                                            
                        break;

                    case 3:
                        await GetAllSolutionsForRequest(employeeRequestBL);
                        break;

                    case 4:
                        await ProvideComment(employeeRequestBL);
                        break;

                    case 5:
                        await ProvideFeedback(employeeRequestBL);
                        break;

                    case 6:
                        await Logout(employeeLoginBl);
                        break;

                    default:
                        await Console.Out.WriteLineAsync("Invalid Input!");
                        break;
                }
            } while (choice != 6);            
        }
    }
}
