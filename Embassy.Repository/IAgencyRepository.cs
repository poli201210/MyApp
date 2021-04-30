// <copyright file="IAgencyRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using Embassy.Program.Models;

    /// <summary>
    /// Interface repository for agency data
    /// with one invented CRUD method.
    /// </summary>
    public interface IAgencyRepository : IRepository<Agency>
    {
        /// <summary>
        /// CRUD-update method as
        /// example method for to change the text of email variable,
        /// by entering id.
        /// </summary>
        /// <param name="id">identifical integer.</param>
        /// <param name="newemail">text instance.</param>
        void ChangeEmail(int id, string newemail);
    }
}
