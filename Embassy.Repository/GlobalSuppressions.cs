// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "<DatabaseContext>", Scope = "member", Target = "~F:Embassy.Repository.RepositoryGener`1.context")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:Accessible fields should begin with upper-case letter", Justification = "<Dbcontext>", Scope = "member", Target = "~F:Embassy.Repository.RepositoryGener`1.context")]
[assembly: SuppressMessage("Design", "CA1012:Abstract types should not have public constructors", Justification = "<ConstructorPublic>", Scope = "type", Target = "~T:Embassy.Repository.RepositoryGener`1")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<context>", Scope = "member", Target = "~F:Embassy.Repository.RepositoryGener`1.context")]
