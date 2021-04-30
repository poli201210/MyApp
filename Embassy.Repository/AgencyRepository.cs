// <copyright file="AgencyRepository.cs" company="PlaceholderCompany">
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
    /// Repository for agency data table
    /// with constructor and update method.
    /// </summary>
    public class AgencyRepository : RepositoryGener<Agency>, IAgencyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyRepository"/> class.
        /// constructor with database
        /// context.
        /// </summary>
        /// <param name="context">database parameter.</param>
        public AgencyRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Update method with exception
        /// handling.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <param name="newemail">string.</param>
        public void ChangeEmail(int id, string newemail)
        {
            var agency = this.GetOne(id);
            if (agency == null)
            {
                throw new InvalidOperationException("Agency not found");
            }

            agency.AgenEmail = newemail;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Method from repository
        /// allows take one variable of data with
        /// specifying id.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <returns>Agency data.</returns>
        public override Agency GetOne(int id)
        {
            return this.GetAll().Single(ag => ag.AgenId == id);
        }
    }
}
