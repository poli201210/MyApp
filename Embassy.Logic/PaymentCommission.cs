// <copyright file="PaymentCommission.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for Non-CRUD method for payment table
    /// storing the commission that agency will get from the
    /// applicant, as client using agency serveses.
    /// </summary>
    public class PaymentCommission
    {
        /// <summary>
        /// Gets or sets amount of money that agency will earn
        /// from applicant(client).
        /// </summary>
        public int AmountOfCommission { get; set; }

        /// <summary>
        /// Gets or sets property to agency.
        /// </summary>
        public string IsPaid { get; set; }

        /// <summary>
        /// Gets or sets property to PayId.
        /// </summary>
        public int PayId { get; set; }

        /// <summary>
        /// Gets or sets property for comm.
        /// </summary>
        public int Com { get; set; }

        /// <summary>
        /// Overrided method equals.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>true or false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is PaymentCommission)
            {
                PaymentCommission other = obj as PaymentCommission;
                return this.AmountOfCommission == other.AmountOfCommission
                    && this.IsPaid == other.IsPaid && this.Com == other.Com
                    && this.PayId == other.PayId;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// override method to have hash code.
        /// </summary>
        /// <returns>integer.</returns>
        public override int GetHashCode()
        {
            return this.AmountOfCommission;
        }

        /// <summary>
        /// Method ToString printing the values and variables in the
        /// way that we would set.
        /// </summary>
        /// <returns>text.</returns>
        public override string ToString()
        {
            return $" Commissions per agency: {this.AmountOfCommission},   IsPayed: {this.IsPaid}";
        }
    }
}
