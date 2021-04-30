// <copyright file="Applicant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Program.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for Aolicant data from database.
    /// </summary>
    public partial class Applicant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Applicant"/> class.
        /// Aplicant constructor of the class.
        /// </summary>
        public Applicant()
        {
            this.Payment = new HashSet<Payment>();
            this.Visa = new HashSet<Visa>();
        }

        /// <summary>
        /// Gets or sets for identical number of applicant.
        /// </summary>
        public int ApplId { get; set; }

        /// <summary>
        /// Gets or sets for text as a name.
        /// </summary>
        public string ApplName { get; set; }

        /// <summary>
        /// Gets or sets for text as gender.
        /// </summary>
        public string ApplGender { get; set; }

        /// <summary>
        /// Gets or sets for string as email address.
        /// </summary>
        public string ApplEmail { get; set; }

        /// <summary>
        /// Gets or sets for integer number as salary for applicant.
        /// </summary>
        public int? ApplIncome { get; set; }

        /// <summary>
        /// Gets or sets for date as applicant birthdate.
        /// </summary>
        public DateTime? ApplBirth { get; set; }

        /// <summary>
        /// Gets or sets for string as job name.
        /// </summary>
        public string ApplJob { get; set; }

        /// <summary>
        /// Gets or sets for foreign key payment.
        /// </summary>
        public virtual ICollection<Payment> Payment { get; set; }

        /// <summary>
        /// Gets or sets for foreign key as visa data.
        /// </summary>
        public virtual ICollection<Visa> Visa { get; set; }
    }
}
