// <copyright file="AgencyLogic.cs" company="PlaceholderCompany">
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
    /// Class for methods manage Agency data with interface
    /// and repository (change email, get one, get all,
    /// get by name,create and delete methods).
    /// </summary>
    public class AgencyLogic : IAgencyLogic
    {
        private readonly IAgencyRepository agencyRepository;
        private readonly IPaymentRepository payRepository;
        private readonly IApplicantRepository applRepository;
        private readonly IVisaRepository visaRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyLogic"/> class.
        /// Constructor with interface agency
        /// repository.
        /// </summary>
        /// <param name="repo">interface param.</param>
        public AgencyLogic(IAgencyRepository repo = null)
        {
            if (repo == null)
            {
                this.agencyRepository = new AgencyRepository(new EmbCtx());
            }
            else
            {
                this.agencyRepository = repo;
            }
        }

        /// <summary>
        /// Non-CRUD method to have possibility change information as
        /// email (string text), using from repository interface method.
        /// </summary>
        /// <param name="ag_Id">identical integer.</param>
        /// <param name="ag_email">string text.</param>
        public void ChangeAgencyEmail(int ag_Id, string ag_email)
        {
            this.agencyRepository.ChangeEmail(ag_Id, ag_email);
        }

        /// <summary>
        /// Method that allow listing all data from the entity (table database)
        /// that we need.
        /// </summary>
        /// <returns>list of entities.</returns>
        public IList<Agency> GetAllAgencies()
        {
            return this.agencyRepository.GetAll().ToList();
        }

        /// <summary>
        /// Get one data, by specifying the identical number.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <returns>data.</returns>
        public Agency GetOneAgency(int id)
        {
            return this.agencyRepository.GetOne(id);
        }

        /// <summary>
        /// CRUD method that remove one data of the table.
        /// </summary>
        /// <param name="id">identical number integer.</param>
        public void DeleteAgency(int id)
        {
            var agency = this.agencyRepository.GetOne(id);
            this.agencyRepository.Remove(agency);
        }

        /// <summary>
        /// CRUD method, creating new item (row) of the
        /// table, with all variables like id, name, email...
        /// </summary>
        /// <param name="ag">database table.</param>
        public void AddAgency(Agency ag)
        {
            this.agencyRepository.Create(ag);
        }

        /// <summary>
        /// Creating new variable of the table,
        /// throw repository create method.
        /// </summary>
        /// <param name="id">identical integer.</param>
        /// <param name="name">string text.</param>
        /// <param name="location">text.</param>
        /// <param name="mail">string.</param>
        public void CreateNewAgency(int id, string name, string location, string mail)
        {
            Agency newAgency = new Agency()
            {
                AgenId = id,
                AgenName = name,
                AgenAddress = location,
                AgenEmail = mail,
            };
            this.agencyRepository.Create(newAgency);
        }

        /// <summary>
        ///  Purpose is to search and find agency and its number of applicants
        /// by entering the Agency's name.
        /// </summary>
        /// <param name="name">string. </param>
        /// <returns> agency. </returns>
        public AgencyNameAndClient GetAgencyByName(string name)
        {
            var agen1 = from agency in this.agencyRepository.GetAll()
                        join payment in this.payRepository.GetAll() on agency.AgenId equals payment.PayAgenId
                        join aplicants in this.applRepository.GetAll() on payment.PayApplId equals aplicants.ApplId
                        group agency by agency.AgenName into grp
                        select new AgencyNameAndClient()
                        {
                            AgenName = grp.Key,
                            Number = grp.Count(),
                        };

            return agen1.FirstOrDefault(x => x.AgenName == name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyLogic"/> class.
        /// Constructor agency.
        /// </summary>
        public AgencyLogic()
        {
            EmbCtx ctx = new EmbCtx();
            this.agencyRepository = new AgencyRepository(ctx);
            this.applRepository = new ApplicantRepository(ctx);
            this.payRepository = new PaymentRepository(ctx);
            this.visaRepository = new VisaRepository(ctx);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyLogic"/> class.
        /// Constructor for agencylogic object.
        /// </summary>
        /// <param name="agrepo">Agency repository.</param>
        /// <param name="aprepo">Applicant repository.</param>
        /// <param name="payrepo">Payment repository.</param>
        /// <param name="visarepo">Visa repository.</param>
        public AgencyLogic(IAgencyRepository agrepo, IApplicantRepository aprepo, IPaymentRepository payrepo, IVisaRepository visarepo)
        {
            this.agencyRepository = agrepo;
            this.applRepository = aprepo;
            this.payRepository = payrepo;
            this.visaRepository = visarepo;
        }

        /// <summary>
        /// Non-crud method for Agencies.
        /// </summary>
        /// <returns>IList of non-rud object as AgencySuccessful.</returns>
        public IList<AgencySuccessful> GetAgencyWithApprovedVisas()
        {
            var successAgQuery = from ag in this.agencyRepository.GetAll()
                                 join pay in this.payRepository.GetAll() on ag.AgenId equals pay.PayAgenId
                                 join apl in this.applRepository.GetAll() on pay.PayApplId equals apl.ApplId
                                 join vis in this.visaRepository.GetAll() on apl.ApplId equals vis.VisaApplId
                                 where vis.VisaIsapproved == "approved"
                                 select new AgencySuccessful()
                                 {
                                     AgenName = ag.AgenName,
                                     Approved = vis.VisaIsapproved,
                                     Job = apl.ApplJob,
                                     ClientName = apl.ApplName,
                                 };
            return successAgQuery.ToList();
        }

        /// <summary>
        /// Task method for Agency data as AgencySuccessful.
        /// </summary>
        /// <returns>Task IList.</returns>
        public Task<IList<AgencySuccessful>> GetAgencyWithApprovedVisasAsync()
        {
            var tasks = Task.Run(() => this.GetAgencyWithApprovedVisas());
            return tasks;
        }
    }
}
