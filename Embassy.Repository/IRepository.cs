// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// interface repositoty
    /// main.
    /// </summary>
    /// <typeparam name="T">entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// initializer to take one
        /// of entity item.
        /// </summary>
        /// <param name="id">integer.</param>
        /// <returns>entity.</returns>
        T GetOne(int id);

        /// <summary>
        ///  Making method to take
        /// all variables in a list.
        /// </summary>
        /// <returns>list of entities.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Initializing Create method from CRUD.
        /// </summary>
        /// <param name="newInstance">entity.</param>
        void Create(T newInstance);

        /// <summary>
        /// Initializing Remove method from CRUD.
        /// </summary>
        /// <param name="uselessInstance">entity.</param>
        void Remove(T uselessInstance);
    }
}
