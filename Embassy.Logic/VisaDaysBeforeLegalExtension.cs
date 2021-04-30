// <copyright file="VisaDaysBeforeLegalExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class of non-CRUD method for Visa data. Its able to store the days, which applicant
    /// has for to stay legal in the surtain country before applying extension for visa.
    /// </summary>
    public class VisaDaysBeforeLegalExtension
    {
        /// <summary>
        /// Gets or sets visa identical number.
        /// </summary>
        public int VisaId { get; set; }

        /// <summary>
        /// Gets or sets number of days.
        /// </summary>
        public int Visadays { get; set; }

        /// <summary>
        /// Gets or sets applicants email.
        /// </summary>
        public string ApplEmail { get; set; }

        /// <summary>
        /// Ovveride method.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True  or false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is VisaDaysBeforeLegalExtension)
            {
                VisaDaysBeforeLegalExtension other = obj as VisaDaysBeforeLegalExtension;
                return this.Visadays == other.Visadays && this.VisaId == other.VisaId
                    && this.ApplEmail == other.ApplEmail;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get hashCode.
        /// </summary>
        /// <returns>integer.</returns>
        public override int GetHashCode()
        {
            return (int)this.VisaId.GetHashCode() + (int)this.Visadays.GetHashCode();
        }

        /// <summary>
        /// ToString printing variables, in console in way
        /// how you wish.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"Visa_id: {this.VisaId}, Visa_days: {this.Visadays}, Applicant's email:{this.ApplEmail}";
        }
    }
}
