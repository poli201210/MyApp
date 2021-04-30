// <copyright file="ApplicantSalaryWithTax.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    /// <summary>
    /// Non-crud method class
    /// to execute salary already with taxes (Net Salary)
    /// included.
    /// </summary>
    public class ApplicantSalaryWithTax
    {
        /// <summary>
        /// Gets or sets text name property.
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// Gets or sets double salary.
        /// </summary>
        public double SalaryWithTax { get; set; }

        /// <summary>
        /// Gets or sets payment.
        /// </summary>
        public string Pay { get; set; }

        /// <summary>
        /// Gets or sets tax.
        /// </summary>
        public double Tax { get; set; }

        /// <summary>
        /// Overrided method equals.
        /// </summary>
        /// <param name="obj">object parameter.</param>
        /// <returns>true or false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ApplicantSalaryWithTax)
            {
                ApplicantSalaryWithTax other = obj as ApplicantSalaryWithTax;
                return this.ApplicantName == other.ApplicantName
                    && this.SalaryWithTax == other.SalaryWithTax
                    && this.Pay == other.Pay;
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
            return (int)(this.ApplicantName.GetHashCode() + (double)this.SalaryWithTax);
        }

        /// <summary>
        /// Method ToString printing the values and variables in the
        /// way that we would set.
        /// </summary>
        /// <returns>text.</returns>
        public override string ToString()
        {
            return $"Name: {this.ApplicantName},  Net salary:  {this.SalaryWithTax}$, Tax:{this.Tax},  IsPayed:{this.Pay} ";
        }
    }
}
