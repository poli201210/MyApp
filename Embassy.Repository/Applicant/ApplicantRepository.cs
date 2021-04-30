// <copyright file="ApplicantRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Linq;
    using Embassy.Program.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository for the Applicant data.
    /// </summary>
    public class ApplicantRepository : RepositoryGener<Applicant>, IApplicantRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantRepository"/> class.
        /// Empty constructor for applicant repository.
        /// </summary>
        /// <param name="context">DbContext.</param>
        public ApplicantRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Method CRUD as Update to change contact as email address.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <param name="newaddress">text.</param>
        public void ChangeAddress(int id, string newaddress)
        {
            var applicant = this.GetOne(id);
            if (applicant == null)
            {
                throw new InvalidOperationException("Applicant not found");
            }

            applicant.ApplEmail = newaddress;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Get one method to gat one by entering id.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <returns>Applicant data.</returns>
        public override Applicant GetOne(int id)
        {
            return this.GetAll().Single(a => a.ApplId == id);
        }

        /// <summary>
        /// Add applicant to existing data.
        /// </summary>
        /// <param name="app">Applicant.</param>
        public void AddApplicant(Applicant app)
        {
            this.Create(app);
        }

        /// <summary>
        /// Delete one applicant from data table.
        /// </summary>
        /// <param name="app">Applicant.</param>
        public void RemoveApplicant(Applicant app)
        {
            this.Remove(app);
        }
    }
}
