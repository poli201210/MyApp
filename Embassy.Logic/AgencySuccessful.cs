// <copyright file="AgencySuccessful.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Agency Non-crud object.
    /// </summary>
    public class AgencySuccessful
    {
        /// <summary>
        /// Gets or sets agen name.
        /// </summary>
        public string AgenName { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int AgenId { get; set; }

        /// <summary>
        /// Gets or sets approved.
        /// </summary>
        public string Approved { get; set; }

        /// <summary>
        /// Gets or sets job.
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets client name.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Override method equals.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AgencySuccessful)
            {
                AgencySuccessful other = obj as AgencySuccessful;
                return this.AgenName == other.AgenName
                    && this.Approved == other.Approved
                    && this.Job == other.Job && this.ClientName == other.ClientName;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// override hash code method.
        /// </summary>
        /// <returns>int.</returns>
        public override int GetHashCode()
        {
            return this.AgenId.GetHashCode();
        }
    }
}
