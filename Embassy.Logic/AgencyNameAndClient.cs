// <copyright file="AgencyNameAndClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Object for non-rud method GetAgencyByName.
    /// </summary>
    public class AgencyNameAndClient
    {
        /// <summary>
        /// Gets or sets agen name.
        /// </summary>
        public string AgenName { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Override method equals.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AgencyNameAndClient)
            {
                AgencyNameAndClient other = obj as AgencyNameAndClient;
                return this.AgenName == other.AgenName
                    && this.Number == other.Number;
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
            return 0;
        }
    }
}
