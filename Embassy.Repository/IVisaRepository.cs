// <copyright file="IVisaRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Embassy.Program.Models;

    /// <summary>
    /// interface for visa table.
    /// </summary>
    public interface IVisaRepository : IRepository<Visa>
    {
        /// <summary>
        /// CRUD method update, to change
        /// number of days, allowed to stay in
        /// another country.
        /// </summary>
        /// <param name="id">integer identifical.</param>
        /// <param name="days">number of days.</param>
        void ChangeDays(int id, int days);
    }
}
