// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<linq>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.#ctor(Embassy.Repository.IAgencyRepository)")]
[assembly: SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "<linq>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.GetAgencyByName(System.String)~System.Linq.IQueryable{Embassy.Program.Models.Agency}")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<database>", Scope = "member", Target = "~M:Embassy.Logic.ApplicantLogic.#ctor(Embassy.Repository.IApplicantRepository)")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<hashcode>", Scope = "member", Target = "~M:Embassy.Logic.ApplicantSalaryWithTax.GetHashCode~System.Int32")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<integer and string parameters>", Scope = "member", Target = "~M:Embassy.Logic.IAgencyLogic.ChangeAgencyEmail(System.Int32,System.String)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<database>", Scope = "member", Target = "~M:Embassy.Logic.PaymentLogic.#ctor(Embassy.Repository.IPaymentRepository)")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<id param>", Scope = "member", Target = "~M:Embassy.Logic.PaymentLogic.CreateNewPayment(System.Int32,System.Int32,System.Int32,System.Int32,System.String)")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "<FK param>", Scope = "member", Target = "~M:Embassy.Logic.PaymentLogic.CreateNewPayment(System.Int32,System.Int32,System.Int32,System.Int32,System.String)")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "<interface repository field>", Scope = "member", Target = "~F:Embassy.Logic.PaymentLogic.payment_repo")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<databaseinCtor>", Scope = "member", Target = "~M:Embassy.Logic.VisaLogic.#ctor(Embassy.Repository.IVisaRepository)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<EmbCtx>", Scope = "member", Target = "~M:Embassy.Logic.ApplicantLogic.#ctor(Embassy.Repository.IApplicantRepository,Embassy.Repository.IPaymentRepository)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<ctx>", Scope = "member", Target = "~M:Embassy.Logic.PaymentLogic.#ctor(Embassy.Repository.IPaymentRepository,Embassy.Repository.IAgencyRepository,Embassy.Repository.IApplicantRepository)")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<PropAgency>", Scope = "member", Target = "~P:Embassy.Logic.PaymentCommission.IsPaid")]
[assembly: SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "<toUpper>", Scope = "member", Target = "~M:Embassy.Logic.VisaLogic.GetVisaActualDays~System.Collections.Generic.IList{Embassy.Logic.VisaDaysBeforeLegalExtension}")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<emb>", Scope = "member", Target = "~M:Embassy.Logic.VisaLogic.#ctor(Embassy.Repository.IVisaRepository,Embassy.Repository.IApplicantRepository)")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<NonCrudForAgency>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.GetAgenciesCommission~System.Collections.Generic.List{Embassy.Logic.AgenciesSumCommission}")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<embLocal>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.#ctor(Embassy.Repository.IAgencyRepository,Embassy.Repository.IPaymentRepository)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<emb>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.#ctor(Embassy.Repository.IAgencyRepository,Embassy.Repository.IPaymentRepository,Embassy.Repository.IApplicantRepository,Embassy.Repository.IVisaRepository)")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<Constructor>", Scope = "member", Target = "~M:Embassy.Logic.ApplicantLogic.#ctor")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Context>", Scope = "member", Target = "~M:Embassy.Logic.ApplicantLogic.#ctor")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<ConstructorVisa>", Scope = "member", Target = "~M:Embassy.Logic.VisaLogic.#ctor")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<ContextEmb>", Scope = "member", Target = "~M:Embassy.Logic.VisaLogic.#ctor")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<ContEmb>", Scope = "member", Target = "~M:Embassy.Logic.PaymentLogic.#ctor")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<Constructor>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.#ctor")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Emb>", Scope = "member", Target = "~M:Embassy.Logic.AgencyLogic.#ctor")]
