// <copyright file="IPaymentLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Embassy.Program.Models;

    /// <summary>
    /// interface for
    /// payment table logics methods.
    /// </summary>
    public interface IPaymentLogic
    {
        /// <summary>
        /// Non crud method to calculate commissions for agency,
        /// but in payment data table.
        /// </summary>
        /// <returns>List.</returns>
        IList<PaymentCommission> GetPaymentCommissions();

        /// <summary>
        /// method to have one variable of the
        /// payment table.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <returns>variable payment.</returns>
        Payment GetOnePayment(int id);

        /// <summary>
        /// Non-Crud method to change
        /// the amount of payment.
        /// </summary>
        /// <param name="newid">integer.</param>
        /// <param name="newAmount">integer of amount.</param>
        void ChangePriceAmount(int newid, int newAmount);

        /// <summary>
        /// Get all of variables payment
        /// table in a list.
        /// </summary>
        /// <returns>list of payments.</returns>
        IList<Payment> GetAllPayments();

        /// <summary>
        /// Task for Non-CRUD PaymentCommission method.
        /// </summary>
        /// <returns>Task IList.</returns>
        Task<IList<PaymentCommission>> GetPaymentCommissionAsync();
    }
}