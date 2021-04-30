// <copyright file="PaymentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Embassy.Program.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class repository for one of the entity as
    /// payment with method change the price as update
    /// method from CRUD.
    /// </summary>
    public class PaymentRepository : RepositoryGener<Payment>, IPaymentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRepository"/> class.
        /// Constructor for repository payment class.
        /// </summary>
        /// <param name="context">database context.</param>
        public PaymentRepository(DbContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public void ChangePriceAmount(int newid, int newAmount)
        {
            var getId = this.GetOne(newid);
            getId.PayAmount = newAmount;
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public override Payment GetOne(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.PayId == id);
        }
    }
}
