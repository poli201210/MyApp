// <copyright file="VisaRepository.cs" company="PlaceholderCompany">
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
    /// Object repository for visa table.
    /// </summary>
    public class VisaRepository : RepositoryGener<Visa>, IVisaRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisaRepository"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="context">database.</param>
        public VisaRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// CRUD update method to
        /// change number of days abroad.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <param name="days">number of days.</param>
        public void ChangeDays(int id, int days)
        {
            var day = this.GetOne(id);
            day.VisaDuration = days;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Method allowing take one variable from
        /// the table of visa by entering id number.
        /// </summary>
        /// <param name="id">identical.</param>
        /// <returns>visa data.</returns>
        public override Visa GetOne(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.VisaId == id);
        }
    }
}
