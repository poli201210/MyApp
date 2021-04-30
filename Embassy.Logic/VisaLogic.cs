// <copyright file="VisaLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Embassy.Program.Models;
    using Embassy.Repository;

    /// <summary>
    /// Class for store CRUD methods for visa logic
    /// update (change days), create, remove.
    /// </summary>
    public class VisaLogic : IVisaLogic
    {
        private readonly IVisaRepository visarepository;
        private readonly IApplicantRepository apprepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisaLogic"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="repo">interface visa repository.</param>
        public VisaLogic(IVisaRepository repo = null)
        {
            if (repo == null)
            {
                this.visarepository = new VisaRepository(new EmbCtx());
            }
            else
            {
                this.visarepository = repo;
            }
        }

        /// <summary>
        /// update method implementing in logic
        /// class.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <param name="days">number of days abroad.</param>
        public void ChangeDays(int id, int days)
        {
            this.visarepository.ChangeDays(id, days);
        }

        /// <summary>
        /// method to store all visa data.
        /// </summary>
        /// <returns>list of visa.</returns>
        public IList<Visa> GetAllVisas()
        {
            return this.visarepository.GetAll().ToList();
        }

        /// <summary>
        /// method to take one variable, by
        /// entering only id number.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <returns>visa data.</returns>
        public Visa GetOneVisa(int id)
        {
            return this.visarepository.GetOne(id);
        }

        /// <summary>
        /// Create method from CRUD.
        /// Creating new visa variable with all
        /// parameters, which we need.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <param name="applicantId">identical for applicant (Foreign key).</param>
        /// <param name="typeOfVisa">text as type of visa (X2), depends on country.</param>
        /// <param name="period">number of days, given for applicant for to locate abroad.</param>
        /// <param name="lastDate">Exact date till when applicant ligal to stay abroad.</param>
        /// <param name="approve">text as was specific applicant approved for to have a visa.</param>
        public void CreateNewVisa(int id, int applicantId, string typeOfVisa, int period, DateTime lastDate, string approve)
        {
            Visa tempVisa = new Visa()
            {
                VisaId = id,
                VisaApplId = applicantId,
                VisaType = typeOfVisa,
                VisaDuration = period,
                VisaEnddate = lastDate,
                VisaIsapproved = approve,
            };
            this.visarepository.Create(tempVisa);
        }

        /// <summary>
        /// CRUD -remove/delete method,
        /// to remove old or unnecessary data of visa.
        /// </summary>
        /// <param name="id">identical.</param>
        public void RemoveOldVisa(int id)
        {
            var del_visa = this.visarepository.GetOne(id);
            this.visarepository.Remove(del_visa);
        }

        /// <summary>
        /// Method foe the tests in test class.
        /// </summary>
        /// <param name="visa">Visa data.</param>
        public void AddVisa(Visa visa)
        {
            this.visarepository.Create(visa);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisaLogic"/> class.
        /// </summary>
        public VisaLogic()
        {
           EmbCtx emb = new EmbCtx();
           this.visarepository = new VisaRepository(emb);
           this.apprepository = new ApplicantRepository(emb);
    }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisaLogic"/> class.
        /// Visa constructor.
        /// </summary>
        /// <param name="aplRepo">interface repo.</param>
        /// <param name="visaRepo">interface repo for visa.</param>
        public VisaLogic(IApplicantRepository aplRepo, IVisaRepository visaRepo)
    {
        this.apprepository = aplRepo;
        this.visarepository = visaRepo;
    }

    /// <summary>
    /// Method for Embassy be sure how much applicant can spend days in another country (ex. Germany)
    /// before applying in case of exstension visa again.
    /// </summary>
    /// <returns>list of visa.</returns>
        public IList<VisaDaysBeforeLegalExtension> GetVisaActualDays()
        {
            var q1 = from ty in this.visarepository.GetAll()
                     join ap in this.apprepository.GetAll() on ty.VisaApplId equals ap.ApplId
                     select new
                     {
                         Visaid = ty.VisaId,
                         VisaDays = ty.VisaDuration,
                         ApplicantName = ap.ApplName,
                         ApplicantEmail = ap.ApplEmail,
                     };

            var actual_days = from s in q1
                     let com = s.VisaDays - 30
                     where com <= 31
                     select new VisaDaysBeforeLegalExtension()
                     {
                         VisaId = (int)s.Visaid,
                         Visadays = (int)com,
                         ApplEmail = s.ApplicantEmail.ToUpper(),
                     };
            return actual_days.ToList();
        }

        /// <summary>
        /// Task method for Non-CRUD method
        /// GetVisaActualDays.
        /// </summary>
        /// <returns>Task IList.</returns>
        public Task<IList<VisaDaysBeforeLegalExtension>> GetVisaActualDaysAsync()
        {
            var taskVisa = Task.Run(() => this.GetVisaActualDays());
            return taskVisa;
        }
    }
}
