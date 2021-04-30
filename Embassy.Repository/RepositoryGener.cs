// <copyright file="RepositoryGener.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Main repository class with entity.
    /// </summary>
    /// <typeparam name="T">entity of T.</typeparam>
    public abstract class RepositoryGener<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// context database.
        /// </summary>
        protected DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryGener{T}"/> class.
        /// </summary>
        /// <param name="context">Constructor parameter from database.</param>
        protected RepositoryGener(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Create method, adding instance to the entity
        /// and saving creation to database.
        /// </summary>
        /// <param name="newInstance">new instance of entity. </param>
        public void Create(T newInstance)
        {
            this.context.Set<T>().Add(newInstance);
            this.context.SaveChanges();
        }

        ///// <summary>
        ///// Boolean method if comparable
        ///// repositories.
        ///// </summary>
        ///// <param name="obj">object.</param>
        ///// <returns> object obj boolean. </returns>
        // public override bool Equals(object obj)
        // {
        //    return obj is RepositoryGeneric<T> repository &&
        //           EqualityComparer<DbContext>.Default.Equals(this.context, repository.context);
        // }

        /// <summary>
        /// Method that allowing take all list
        /// from the entity.
        /// </summary>
        /// <returns>set entity.</returns>
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// Hashcode method, overrided.
        /// </summary>
        /// <returns>hashcode context.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.context);
        }

        /// <summary>
        /// abstract entity, which
        /// allowing get one entity.
        /// </summary>
        /// <param name="id">integer parameter identical.</param>
        /// <returns>entity.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Deleting method, one of the CRUD
        /// methods.
        /// </summary>
        /// <param name="uselessInstance"> entity parameter.</param>
        public void Remove(T uselessInstance)
        {
            this.context.Set<T>().Remove(uselessInstance);
            this.context.SaveChanges();
        }
    }
}
