// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ConsoleTools;
    using Embassy.Logic;
    using Embassy.Program.Models;
    using Embassy.Repository;

    /// <summary>
    /// Program class showing the menu itself.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            bool embMenu = true;
            while (embMenu)
            {
                embMenu = GeneralMenu();
            }
        }

        private static bool GeneralMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose withwhat you want to work:");
            Console.WriteLine("1) applicants");
            Console.WriteLine("2) travel agencies");
            Console.WriteLine("3) payments");
            Console.WriteLine("4) visas");
            Console.WriteLine("5) exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ApplicantBusinessLogicMenu();
                    return true;
                case "2":
                    AgencyBusinessLogicMenu();
                    return true;
                case "3":
                    PaymentBusinessLogicMenu();
                    return true;
                case "4":
                    VisaBusinessLogicMenu();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }

        private static void ApplicantBusinessLogicMenu()
        {
            ApplicantLogic app_logic = new ApplicantLogic();
            Console.Clear();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1) Display all applicants");
            Console.WriteLine("2) Update an applicant");
            Console.WriteLine("3) Create an applicant");
            Console.WriteLine("4) Delete an applicant");
            Console.WriteLine("5) Show net salary");
            Console.WriteLine("6) exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Table applicants:");
                    foreach (Applicant item in app_logic.GetAllApplicants().ToList())
                    {
                        Console.WriteLine($"Applicant Id: {item.ApplId}, Name: {item.ApplName}, Position: {item.ApplJob}, Income: {item.ApplIncome}");
                    }

                    Console.ReadLine();

                    break;
                case "2":
                    Console.WriteLine(" Update an applicant:");
                    Console.WriteLine("Write id of person which needs to update:");
                    int takeId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write new email address of the applicant ");
                    string newAddress = Console.ReadLine();
                    app_logic.ChangeApplicantAddress(takeId, newAddress);
                    break;

                case "3":
                    try
                    {
                        Console.WriteLine("Create new applicant");
                        Console.WriteLine("Create new id (id should be more than 10):");
                        int modifyId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Create a name of applicant:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Write a gender");
                        string newgender = Console.ReadLine();
                        Console.WriteLine("Enter new email address: ");
                        string newMail = Console.ReadLine();
                        Console.WriteLine("Enter income: ");
                        int newIncome = int.Parse(Console.ReadLine());
                        Console.WriteLine("Type bithdate [yyyy-mm-dd]");
                        DateTime newBirthday = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Whats the applicant's job?");
                        string newJob = Console.ReadLine();
                        app_logic.CreateNewApplicant(modifyId, newName, newgender, newMail, newIncome, newBirthday, newJob);
                    }
                    catch (Exception ex)
                    {
                        string message = string.Empty;
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (ex is FormatException)
                        {
                            message = " Incorrect form";
                        }
                        else
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine(message);
                    }

                    break;

                case "4":
                    Console.WriteLine("Delete applicant by id:");
                    Console.WriteLine("Enter id:");
                    int del_Id = int.Parse(Console.ReadLine());
                    app_logic.RemoveApplicant(del_Id);
                    break;

                case "5":
                    Console.WriteLine("Show Net salary:");
                    var salary = app_logic.GetApplicantsSalaryWithTax();
                    foreach (var sal in salary)
                    {
                        Console.WriteLine($" Name: {sal.ApplicantName}, Net Salary: {sal.SalaryWithTax}, Taxes: {sal.Tax}, Ispayed: {sal.Pay} ");
                    }

                    Console.WriteLine("Tasks output:");
                    Task<IList<ApplicantSalaryWithTax>> taxTask = app_logic.GetApplicantSalaryWithTaxAsync();
                    taxTask.Wait();
                    if (taxTask.IsCompletedSuccessfully)
                    {
                        foreach (var task in taxTask.Result)
                        {
                            Console.WriteLine($"Person: {task.ApplicantName},    Net Salary: {task.SalaryWithTax}, Tax: {task.Tax}, IsPayed:{task.Pay}");
                        }
                    }

                    Console.ReadLine();
                    break;
            }
        }

        private static void AgencyBusinessLogicMenu()
        {
            AgencyLogic agencyLogic = new AgencyLogic();

            Console.Clear();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1) List all agencies");
            Console.WriteLine("2) Update agency");
            Console.WriteLine("3) Create new agency");
            Console.WriteLine("4) Delete agency");
            Console.WriteLine("5) Show more successful agencies");
            Console.WriteLine("6) Show num of applicants of agency");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Table agency:");
                    foreach (Agency item in agencyLogic.GetAllAgencies().ToList())
                    {
                        Console.WriteLine($"agen_id: {item.AgenId}, agen_name: {item.AgenName}, agen_address: {item.AgenAddress}, agen_email: {item.AgenEmail}");
                    }

                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("Update agency:");
                    Console.WriteLine("Type id of the agency which needs to modify:");
                    int takeId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Type contact email address of the agency");
                    string newMail = Console.ReadLine();
                    agencyLogic.ChangeAgencyEmail(takeId, newMail);
                    break;
                case "3":
                    try
                    {
                        Console.WriteLine("Create new travel agency");
                        Console.WriteLine("Create new id (id should be more than 7):");
                        int newId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Create a name of agency:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Write a location of the agency");
                        string newgender = Console.ReadLine();
                        Console.WriteLine("Enter new email address: ");
                        string newEmail = Console.ReadLine();
                        agencyLogic.CreateNewAgency(newId, newName, newgender, newEmail);
                    }
                    catch (Exception ex)
                    {
                        string message = string.Empty;
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (ex is FormatException)
                        {
                            message = " Incorrect form";
                        }
                        else
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine(message);
                    }

                    break;

                case "4":
                    Console.WriteLine("Delete agency by id:");
                    Console.WriteLine("Enter id:");
                    int delId = int.Parse(Console.ReadLine());
                    agencyLogic.DeleteAgency(delId);
                    Console.WriteLine("Agency deleted successfully!");
                    break;
                case "5":
                    Console.WriteLine("Show agency successful visas");
                    var successAg = agencyLogic.GetAgencyWithApprovedVisas();
                    foreach (var v in successAg)
                    {
                        Console.WriteLine($" AgName: {v.AgenName}, IsApproved:{v.Approved}, ClientJob: {v.Job}, ClientName:{v.ClientName} ");
                    }

                    Console.WriteLine("task output:");
                    Task<IList<AgencySuccessful>> agTask = agencyLogic.GetAgencyWithApprovedVisasAsync();
                    agTask.Wait();
                    if (agTask.IsCompletedSuccessfully)
                    {
                        foreach (var task in agTask.Result)
                        {
                            Console.WriteLine($" AgName: {task.AgenName}, IsApproved:{task.Approved}, ClientJob: {task.Job}, ClientName:{task.ClientName}");
                        }
                    }

                    Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Show number of applicants for the specified agency ...enter name:(eg. TravelAround, CCUnated)");
                    string newname = Console.ReadLine();
                    var agencyWanted = agencyLogic.GetAgencyByName(newname);
                    Console.WriteLine($" AgName: {agencyWanted.AgenName}, NumberOfApplicants:{agencyWanted.Number} ");

                    Console.ReadLine();
                    break;
            }
        }

        /// <summary>
        /// The menu using object of PaymentLogic class,
        /// switch to ability to choose the prefered item.
        /// </summary>
        private static void PaymentBusinessLogicMenu()
        {
            PaymentLogic paymLogic = new PaymentLogic();

            Console.Clear();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1) List all payment");
            Console.WriteLine("2) Update payment");
            Console.WriteLine("3) Create new payment");
            Console.WriteLine("4) Delete payment");
            Console.WriteLine("5) Show payment's commission to the agency");
            Console.WriteLine("6) Show average commissions per payment");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Table payment:");
                    foreach (Payment item in paymLogic.GetAllPayments().ToList())
                    {
                        Console.WriteLine($"pay_id: {item.PayId},    pay_amount: {item.PayAmount},    pay_applicant_id: {item.PayApplId},  pay_result:{item.PayIspayed}");
                    }

                    Console.ReadLine();

                    break;

                case "2":
                    Console.WriteLine("Update payment:");
                    Console.WriteLine("Write Id of payment:");
                    int payId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write new price amount for a visa:");
                    int amount = int.Parse(Console.ReadLine());
                    paymLogic.ChangePriceAmount(payId, amount);
                    Console.WriteLine("Changes done!");
                    break;
                case "3":
                    try
                    {
                        Console.WriteLine("Create new payment:");
                        Console.WriteLine("write new id :");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Write existing tourist id:");
                        int tourId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Write existing agency id:");
                        int agenId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount of money that visa costs: ");
                        int money = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter if amount is [payed] or [not payed]: ");
                        string payorNot = Console.ReadLine();
                        paymLogic.CreateNewPayment(id, tourId, agenId, money, payorNot);
                        Console.WriteLine("Agency created successfully!");
                    }
                    catch (Exception ex)
                    {
                        string message = string.Empty;
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (ex is FormatException)
                        {
                            message = " Incorrect form";
                        }
                        else
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine(message);
                    }

                    break;
                case "4":
                    Console.WriteLine("Delete payment by id:");
                    Console.WriteLine("Write payment id:");
                    int takeId = int.Parse(Console.ReadLine());
                    paymLogic.RemoveOldPayment(takeId);
                    Console.WriteLine("Payment deleted successfully!");
                    break;

                case "5":
                    Console.WriteLine("Show payment's commission");
                    var commisions = paymLogic.GetPaymentCommissions();
                    foreach (var comm in commisions)
                    {
                        Console.WriteLine($" Commission: {comm.AmountOfCommission}, IsPayed:{comm.IsPaid} ");
                    }

                    Console.WriteLine("task output:");

                    Task<IList<PaymentCommission>> paymentTask = paymLogic.GetPaymentCommissionAsync();
                    paymentTask.Wait();
                    if (paymentTask.IsCompletedSuccessfully)
                    {
                        foreach (var task in paymentTask.Result)
                        {
                            Console.WriteLine($" Commission: {task.AmountOfCommission}, IsPayed:{task.IsPaid} ");
                        }
                    }

                    Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Show average payment's commission of the agencies");
                    var comAvg = paymLogic.GetPaymentAverageCommissions();
                    foreach (var co in comAvg)
                    {
                        Console.WriteLine($" By Companies who: {co.IsPaid}, AvgCommissions:{co.AmountOfCommission} $");
                    }

                    Console.WriteLine("task output:");

                    Task<IList<PaymentCommission>> payAvgComTask = paymLogic.GetPaymentAverageCommissionsAsync();
                    payAvgComTask.Wait();
                    if (payAvgComTask.IsCompletedSuccessfully)
                    {
                        foreach (var task in payAvgComTask.Result)
                        {
                            Console.WriteLine($" By Companies who: {task.IsPaid}, AvgCommissions:{task.AmountOfCommission} $");
                        }
                    }

                    Console.ReadLine();
                    break;
            }
        }

        private static void VisaBusinessLogicMenu()
        {
            VisaLogic visaLogic = new VisaLogic();

            Console.Clear();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1) List all visa");
            Console.WriteLine("2) Update visa");
            Console.WriteLine("3) Create new visa");
            Console.WriteLine("4) Delete unnecessary visa");
            Console.WriteLine("5) Show illegal visa for extension application");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Table visa:");
                    foreach (Visa v in visaLogic.GetAllVisas().ToList())
                    {
                        Console.WriteLine($"visa_id: {v.VisaId},     visa_type:  {v.VisaType},    visa_duration:  {v.VisaDuration},   visa_lastDate: {v.VisaEnddate} ");
                    }

                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Update visa:");
                    Console.WriteLine("Write Id of visa that need to modify");
                    int takeId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Change the duration of visa:");
                    int duration = int.Parse(Console.ReadLine());
                    visaLogic.ChangeDays(takeId, duration);
                    Console.WriteLine("Changes completed!");
                    break;
                case "3":
                    try
                    {
                        Console.WriteLine("Create new visa:");
                        Console.WriteLine("write new id [9<]:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Write existing applicant id [1-10]:");
                        int tourId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Write type of visa:");
                        string visaType = Console.ReadLine();
                        Console.WriteLine("Enter duration (in days) that visa needs: ");
                        int period = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the last date of visa [YYYY-MM-DD]: ");
                        DateTime lastDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Write is visa is [approved] or [not approved]:");
                        string approving = Console.ReadLine();
                        visaLogic.CreateNewVisa(id, tourId, visaType, period, lastDate, approving);
                        Console.WriteLine("Visa created successfully!");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        string message = string.Empty;
                        if (ex is FormatException)
                        {
                            message = " Incorrect form ";
                        }
                        else
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine(message);
                    }

                    break;
                case "4":
                    Console.WriteLine("Delete visa by id:");
                    Console.WriteLine("Enter id:");
                    int tempId = int.Parse(Console.ReadLine());
                    visaLogic.RemoveOldVisa(tempId);
                    Console.WriteLine("Visa deleted!");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("Show actual days left before application day: ");
                    var visa = visaLogic.GetVisaActualDays();
                    foreach (var item in visa)
                    {
                        Console.WriteLine($"Visa_id: {item.VisaId}, Visa_days: {item.Visadays}, Applicant's email:{item.ApplEmail}");
                    }

                    Console.WriteLine("task output:");
                    Task<IList<VisaDaysBeforeLegalExtension>> visaDaysExtensionTask = visaLogic.GetVisaActualDaysAsync();
                    visaDaysExtensionTask.Wait();
                    if (visaDaysExtensionTask.IsCompletedSuccessfully)
                    {
                        foreach (var visatask in visaDaysExtensionTask.Result)
                        {
                            Console.WriteLine($"Visa id:{visatask.VisaId}, visa days:{visatask.Visadays} ");
                        }
                    }

                    Console.ReadLine();
                    break;
            }
        }
    }
}
