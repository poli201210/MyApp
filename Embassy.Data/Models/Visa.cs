// <copyright file="Visa.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Program.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Visa table class in models.
    /// </summary>
    public partial class Visa
    {
        /// <summary>
        /// Gets or sets for identical number for Visa data.
        /// </summary>
        public int VisaId { get; set; }

        /// <summary>
        /// Gets or sets for identical number for applicant in visa table as foreign key.
        /// </summary>
        public int? VisaApplId { get; set; }

        /// <summary>
        /// Gets or sets for string text as type of visa.
        /// </summary>
        public string VisaType { get; set; }

        /// <summary>
        /// Gets or sets for number of days as amout of days legally applicant can stay abroad.
        /// </summary>
        public int? VisaDuration { get; set; }

        /// <summary>
        /// Gets or sets for date time, when visa will expire.
        /// </summary>
        public DateTime? VisaEnddate { get; set; }

        /// <summary>
        /// Gets or sets for text if with was given to the applicant.
        /// </summary>
        public string VisaIsapproved { get; set; }

        /// <summary>
        /// Gets or sets virtual for applicant in visa table as foreign key.
        /// </summary>
        public virtual Applicant VisaAppl { get; set; }
    }
}
