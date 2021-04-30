// <copyright file="IVisaLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Embassy.Program.Models;

    /// <summary>
    /// Interface, which storing methods for
    /// Visa logic class.
    /// </summary>
    public interface IVisaLogic
    {
        /// <summary>
        /// Get one variable method.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <returns>Visa data.</returns>
        Visa GetOneVisa(int id);

        /// <summary>
        /// CRUD- update method, updating days.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <param name="days">number of days abroad.</param>
        void ChangeDays(int id, int days);

        /// <summary>
        /// Get all list of visa data.
        /// </summary>
        /// <returns>list of visas.</returns>
        IList<Visa> GetAllVisas();

        /// <summary>
        /// Interface method for list visas, which
        /// we will require.
        /// </summary>
        /// <returns>IList.</returns>
        IList<VisaDaysBeforeLegalExtension> GetVisaActualDays();

        /// <summary>
        /// Task method.
        /// </summary>
        /// <returns>IList.</returns>
        Task<IList<VisaDaysBeforeLegalExtension>> GetVisaActualDaysAsync();
    }
}
