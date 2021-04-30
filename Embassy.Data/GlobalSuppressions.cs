// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Property>", Scope = "member", Target = "~P:Embassy.Program.Models.Agency.Payment")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<NavigationProperty>", Scope = "member", Target = "~P:Embassy.Program.Models.Applicant.Payment")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<NavigProperty>", Scope = "member", Target = "~P:Embassy.Program.Models.Applicant.Visa")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<DbContextOptionsBuilder>", Scope = "member", Target = "~M:Embassy.Program.Models.EmbCtx.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<ModelBuilder>", Scope = "member", Target = "~M:Embassy.Program.Models.EmbCtx.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)")]
