// <copyright file="PaymentLogic.cs" company="PlaceholderCompany">
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
    /// Class of the crud (Create,Remove) and non-crud (Change price
    /// of the payment). With help of repository interface.
    /// </summary>
    public class PaymentLogic : IPaymentLogic
    {
        /// <summary>
        /// Interface repository field
        /// for payment.
        /// </summary>
        private readonly IPaymentRepository payment_repo;
        private readonly IAgencyRepository agRepo;
        private readonly IApplicantRepository applicantRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentLogic"/> class.
        /// Constructor for class, where if repository
        /// item is null, it takes data from dtabase.
        /// </summary>
        /// <param name="repo">interface repository for payment.</param>
        public PaymentLogic(IPaymentRepository repo = null)
        {
            if (repo == null)
            {
                EmbCtx ctx = new EmbCtx();
                this.payment_repo = new PaymentRepository(ctx);
            }
            else
            {
                this.payment_repo = repo;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentLogic"/> class.
        /// Constructor.
        /// </summary>
        public PaymentLogic()
        {
            EmbCtx emb = new EmbCtx();
            this.agRepo = new AgencyRepository(emb);
            this.applicantRepository = new ApplicantRepository(emb);
            this.payment_repo = new PaymentRepository(emb);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentLogic"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="aplRepo">repository.</param>
        /// <param name="agencyRepository">agency repository.</param>
        /// <param name="paymentRepository">payment.</param>
        public PaymentLogic(IApplicantRepository aplRepo, IAgencyRepository agencyRepository, IPaymentRepository paymentRepository)
        {
            this.applicantRepository = aplRepo;
            this.agRepo = agencyRepository;
            this.payment_repo = paymentRepository;
        }

        /// <summary>
        /// Method through repoository to change
        /// the amount.
        /// </summary>
        /// <param name="newid">integer.</param>
        /// <param name="newAmount">integer instance.</param>
        public void ChangePriceAmount(int newid, int newAmount)
        {
            this.payment_repo.ChangePriceAmount(newid, newAmount);
        }

        /// <summary>
        /// Method that Listing all variables of
        /// payment table.
        /// </summary>
        /// <returns>list of payments.</returns>
        public IList<Payment> GetAllPayments()
        {
            return this.payment_repo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Payment GetOnePayment(int id)
        {
            return this.payment_repo.GetOne(id);
        }

        /// <summary>
        /// CRUD method, creating new variable in payment
        /// table, through repository. With filling the data
        /// in parameters as written bellow.
        /// </summary>
        /// <param name="pay_id">integer.</param>
        /// <param name="applicant_id">foreign key int.</param>
        /// <param name="Agency_id">another foreign key.</param>
        /// <param name="Amount">integer amount.</param>
        /// <param name="Payed">string, but could be as bool.</param>
        public void CreateNewPayment(int pay_id, int applicant_id, int Agency_id, int Amount, string Payed)
        {
            Payment new_payment = new Payment()
            {
                PayId = pay_id,
                PayApplId = applicant_id,
                PayAgenId = Agency_id,
                PayAmount = Amount,
                PayIspayed = Payed,
            };
            this.payment_repo.Create(new_payment);
        }

        /// <summary>
        /// CRUD method delete, which allow to
        /// remove one data, by entering id.
        /// </summary>
        /// <param name="id">integer identical number.</param>
        public void RemoveOldPayment(int id)
        {
            var del_payment = this.payment_repo.GetOne(id);
            this.payment_repo.Remove(del_payment);
        }

        /// <summary>
        /// Method calculations to print
        /// commissions.
        /// </summary>
        /// <returns>List.</returns>
        public IList<PaymentCommission> GetPaymentCommissions()
        {
            var ag = this.agRepo.GetAll();
            var applicant = this.applicantRepository.GetAll();

            var money = from pay in this.payment_repo.GetAll()
                        join x in ag on pay.PayAgenId equals x.AgenId
                        join a in applicant on pay.PayApplId equals a.ApplId
                        let com = pay.PayAmount * 0.1
                        where com > 4
                        orderby x.AgenName ascending
                        select new
                        {
                            PaymentId = pay.PayId,
                            Commission = (int)com,
                            To_Agency = x.AgenName,
                            IsPaid = pay.PayIspayed,
                        };
            var commissions = from c in money
                              group c by c.IsPaid into grp_ispaid
                              select new PaymentCommission()
                              {
                                  IsPaid = grp_ispaid.Key,
                                  AmountOfCommission = grp_ispaid.Select(x => x.Commission).Count(),
                              };

            return commissions.ToList();
        }

        /// <summary>
        /// Task for method GetPaymentCommission, implemented by interface.
        /// </summary>
        /// <returns>Task IList.</returns>
        public Task<IList<PaymentCommission>> GetPaymentCommissionAsync()
        {
            var taskPayment = Task.Run(() => this.GetPaymentCommissions());
            return taskPayment;
        }

        /// <summary>
        /// Query for average commissions per payment.
        /// </summary>
        /// <returns>Ilist of payments.</returns>
        public IList<PaymentCommission> GetPaymentAverageCommissions()
        {
            var q1 = from d in this.payment_repo.GetAll()
                     group d by d.PayIspayed into grp_is
                     select new PaymentCommission()
                     {
                         IsPaid = grp_is.Key,
                         AmountOfCommission = (int)grp_is.Average(x => x.PayAmount),
                     };
            return q1.ToList();
        }

        /// <summary>
        /// Task for method GetPaymentAverageCommission.
        /// </summary>
        /// <returns>Task IList.</returns>
        public Task<IList<PaymentCommission>> GetPaymentAverageCommissionsAsync()
        {
            var taskAvgComm = Task.Run(() => this.GetPaymentAverageCommissions());
            return taskAvgComm;
        }
    }
}
