// <copyright file="Payment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Program.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for payment table
    /// to store variables.
    /// </summary>
    public partial class Payment
    {
        /// <summary>
        /// Gets or sets for identity number for payment data.
        /// </summary>
        public int PayId { get; set; }

        /// <summary>
        /// Gets or sets for foreign key as applicant identical number.
        /// </summary>
        public int? PayApplId { get; set; }

        /// <summary>
        /// Gets or sets for foreign key as agency identical number.
        /// </summary>
        public int? PayAgenId { get; set; }

        /// <summary>
        /// Gets or sets for amount of payment.
        /// </summary>
        public int? PayAmount { get; set; }

        /// <summary>
        /// Gets or sets for payment ensure if done trunsuctions.
        /// </summary>
        public string PayIspayed { get; set; }

        /// <summary>
        /// Gets or sets virtual for foreign key.
        /// </summary>
        public virtual Agency PayAgen { get; set; }

        /// <summary>
        /// Gets or sets virtual for foreign key.
        /// </summary>
        public virtual Applicant PayAppl { get; set; }
    }
}
