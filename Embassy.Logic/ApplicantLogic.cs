// <copyright file="ApplicantLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Embassy.Program.Models;
    using Embassy.Repository;

    /// <summary>
    /// Class with CRUD and Non-CRUD methods for table Applicant
    /// like: change address,get salary taxes, create new applicant
    /// and delete.
    /// </summary>
    public class ApplicantLogic : IApplicantLogic
    {
        private readonly IApplicantRepository applicantRepo;
        private readonly IPaymentRepository paymentRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantLogic"/> class.
        /// Constructor of the class.
        /// </summary>
        /// <param name="repo">Interface repository.</param>
        public ApplicantLogic(IApplicantRepository repo = null)
        {
            if (repo == null)
            {
                this.applicantRepo = new ApplicantRepository(new EmbCtx());
            }
            else
            {
                this.applicantRepo = repo;
            }
        }

        /// <inheritdoc/>
        public void ChangeApplicantAddress(int applicantId, string address)
        {
            this.applicantRepo.ChangeAddress(applicantId, address);
        }

        /// <inheritdoc/>
        public IList<Applicant> GetAllApplicants()
        {
            return this.applicantRepo.GetAll().ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantLogic"/> class.
        /// ApplicantLog constructor.
        /// </summary>
        public ApplicantLogic()
        {
            EmbCtx emb = new EmbCtx();
            this.paymentRepo = new PaymentRepository(emb);
            this.applicantRepo = new ApplicantRepository(emb);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantLogic"/> class.
        /// Applicant logic constructor.
        /// </summary>
        /// <param name="aplRepo">repository interface.</param>
        /// <param name="payRepo">payment repos interface.</param>
        public ApplicantLogic(IApplicantRepository aplRepo, IPaymentRepository payRepo)
        {
            this.applicantRepo = aplRepo;
            this.paymentRepo = payRepo;
        }

        /// <inheritdoc/>
        public IList<ApplicantSalaryWithTax> GetApplicantsSalaryWithTax()
        {
            var applicantQuery = from app in this.applicantRepo.GetAll()
                                 join pay in this.paymentRepo.GetAll() on app.ApplId equals pay.PayApplId
                                 let taxsel = app.ApplIncome - (app.ApplIncome * 0.15)
                                  orderby taxsel descending
                                  select new ApplicantSalaryWithTax()
                                  {
                                      ApplicantName = app.ApplName,
                                      SalaryWithTax = (double)taxsel.Value,
                                      Pay = pay.PayIspayed,
                                      Tax = app.ApplIncome * 0.15 ?? 0,
                                  };
            return applicantQuery.ToList();
        }

        /// <inheritdoc/>
        public Applicant GetOneApplicant(int id)
        {
            return this.applicantRepo.GetOne(id);
        }

        /// <summary>
        /// Creating new variable of the table,
        /// throw repository create method.
        /// </summary>
        /// <param name="id">identical integer.</param>
        /// <param name="name">string text.</param>
        /// <param name="gender">text.</param>
        /// <param name="mail">string.</param>
        /// <param name="income">integer.</param>
        /// <param name="birth">date.</param>
        /// <param name="job">string parameter.</param>
        public void CreateNewApplicant(int id, string name, string gender, string mail, int income, DateTime birth, string job)
        {
            Applicant newApp = new Applicant()
            {
                ApplId = id,
                ApplName = name,
                ApplGender = gender,
                ApplEmail = mail,
                ApplIncome = income,
                ApplBirth = birth,
                ApplJob = job,
            };
            this.applicantRepo.Create(newApp);
        }

        /// <summary>
        /// CRUD remove method, allow to delete
        /// one variable of the table, by entering only id.
        /// </summary>
        /// <param name="id">identical int.</param>
        public void RemoveApplicant(int id)
        {
            var applic = this.applicantRepo.GetOne(id);
            this.applicantRepo.Remove(applic);
        }

        /// <summary>
        /// Task method for Applicant data.
        /// </summary>
        /// <returns>Task IList.</returns>
        public Task<IList<ApplicantSalaryWithTax>> GetApplicantSalaryWithTaxAsync()
        {
            var taskSalary = Task.Run(() => this.GetApplicantsSalaryWithTax());
            return taskSalary;
        }
    }
}
