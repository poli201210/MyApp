// <copyright file="IPaymentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Embassy.Program.Models;

    /// <summary>
    /// Repository interface for payment table
    /// from database.
    /// </summary>
    public interface IPaymentRepository : IRepository<Payment>
    {
        /// <summary>
        /// CRUD method update initializer.
        /// </summary>
        /// <param name="newid">integer.</param>
        /// <param name="newAmount">integer for price.</param>
        void ChangePriceAmount(int newid, int newAmount);
    }
}
