// <copyright file="Agency.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Program.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Agency class of Agency table
    /// in embassy database.
    /// </summary>
    public partial class Agency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Agency"/> class.
        /// Constructor of class.
        /// </summary>
        public Agency()
        {
            this.Payment = new HashSet<Payment>();
        }

        /// <summary>
        /// Gets or sets for Identical number of agency.
        /// </summary>
        public int AgenId { get; set; }

        /// <summary>
        /// Gets or sets text as an agency name.
        /// </summary>
        public string AgenName { get; set; }

        /// <summary>
        /// Gets or sets text as an agency address fiels.
        /// </summary>
        public string AgenAddress { get; set; }

        /// <summary>
        /// Gets or sets text as email address.
        /// </summary>
        public string AgenEmail { get; set; }

        /// <summary>
        /// Gets or sets foreign key for the agency table.
        /// </summary>
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
