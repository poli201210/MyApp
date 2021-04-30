// <copyright file="IAgencyLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Embassy.Program.Models;

    /// <summary>
    /// interface for Agency Logic
    /// class.
    /// </summary>
    public interface IAgencyLogic
    {
        /// <summary>
        /// Interface method.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <returns>Agency data.</returns>
        Agency GetOneAgency(int id);

        /// <summary>
        /// Non-CRUD interface method to change
        /// string email.
        /// </summary>
        /// <param name="ag_Id">integer identifical number.</param>
        /// <param name="ag_email">string text.</param>
        void ChangeAgencyEmail(int ag_Id, string ag_email);

        /// <summary>
        /// List of all entity from data.
        /// </summary>
        /// <returns>list of agencies data.</returns>
        IList<Agency> GetAllAgencies();
    }
}
