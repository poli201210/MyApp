// <copyright file="IApplicantLogic.cs" company="PlaceholderCompany">
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
    /// inerface for applicant logic
    /// class.
    /// </summary>
    internal interface IApplicantLogic
    {
        /// <summary>
        /// Method for take one variable from
        /// Applicant table datadase by id
        /// instance.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <returns>applicant data.</returns>
        Applicant GetOneApplicant(int id);

        /// <summary>
        /// Non-crud method.
        /// </summary>
        /// <param name="applicantId">integer.</param>
        /// <param name="address">text.</param>
        void ChangeApplicantAddress(int applicantId, string address);

        /// <summary>
        /// Method to have all variables of applicant
        /// table in a list.
        /// </summary>
        /// <returns>list.</returns>
        IList<Applicant> GetAllApplicants();

        /// <summary>
        /// Non-CRUD method,
        /// to have salary with taxes in a list.
        /// </summary>
        /// <returns>list.</returns>
        IList<ApplicantSalaryWithTax> GetApplicantsSalaryWithTax();

        /// <summary>
        /// Task method for Applicant data and non-crud method.
        /// </summary>
        /// <returns>Task IList.</returns>
        Task<IList<ApplicantSalaryWithTax>> GetApplicantSalaryWithTaxAsync();
    }
}
