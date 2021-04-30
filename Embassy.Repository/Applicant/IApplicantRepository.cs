// <copyright file="IApplicantRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Embassy.Program.Models;

    /// <summary>
    /// Interface Aplicant repository
    /// consist a modify method.
    /// </summary>
    public interface IApplicantRepository : IRepository<Applicant>
    {
        /// <summary>
        /// Update method from CRUD.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <param name="newaddress">text.</param>
        void ChangeAddress(int id, string newaddress);
    }
}
