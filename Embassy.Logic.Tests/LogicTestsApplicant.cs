// <copyright file="LogicTestsApplicant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Embassy.Program.Models;
    using Embassy.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests crud and non-crud methods
    /// from applicant data.
    /// </summary>
    [TestFixture]
    public class LogicTestsApplicant
    {
        /// <summary>
        /// testing possibilities of get one, from listing
        /// few of applicants data.
        /// </summary>
        [Test]
        public void TestGetOneApplicant()
        {
            // ARRANGE
            Mock<IApplicantRepository> mockApplRepo = new Mock<IApplicantRepository>(MockBehavior.Loose);
            List<Applicant> people = new List<Applicant>()
            {
                new Applicant() { ApplId = 1,   ApplName = "Arkagij Petrov" },
                new Applicant() { ApplId = 2,   ApplName = "Anastasiya Konovalova" },
                new Applicant() { ApplId = 3,   ApplName = "Darina Kadurova" },
                new Applicant() { ApplId = 4,   ApplName = "Alina Komarova" },
                new Applicant() { ApplId = 5,   ApplName = "Vyacheslav Petrushin" },
            };

            Applicant expected = new Applicant() { ApplId = 2, ApplName = "Anastasiya Konovalova" };

            mockApplRepo.Setup(repo => repo.GetOne(2)).Returns(expected as Applicant);
            ApplicantLogic applic_Logic = new ApplicantLogic(mockApplRepo.Object);

            // ACT
            Applicant result = applic_Logic.GetOneApplicant(2);
            mockApplRepo.Verify(repo => repo.GetOne(2), Times.Once);
        }

        /// <summary>
        /// Test of CRUD methods: remove one
        /// of the applicants.
        /// </summary>
        [Test]

        public void TestDeleteOneApplicant()
        {
            // Arrange
            Mock<IApplicantRepository> mockApplicRepo = new Mock<IApplicantRepository>(MockBehavior.Loose);

            List<Applicant> applList = new List<Applicant>()
            {
                new Applicant() { ApplId = 1, ApplName = "Arkagij Petrov" },
                new Applicant() { ApplId = 2,   ApplName = "Anastasiya Konovalova" },
                new Applicant() { ApplId = 3,   ApplName = "Darina Kadurova" },
                new Applicant() { ApplId = 4,   ApplName = "Alina Komarova" },
                new Applicant() { ApplId = 5,   ApplName = "Vyacheslav Petrushin" },
            };

            List<Applicant> expected = new List<Applicant>()
            {
                new Applicant() { ApplId = 1, ApplName = "Arkagij Petrov" },
                new Applicant() { ApplId = 3,  ApplName = "Darina Kadurova" },
                new Applicant() { ApplId = 4,  ApplName = "Alina Komarova" },
                new Applicant() { ApplId = 5,   ApplName = "Vyacheslav Petrushin" },
            };

            mockApplicRepo.Setup(repo => repo.GetAll()).Returns(applList.AsQueryable);
            ApplicantLogic logic = new ApplicantLogic(mockApplicRepo.Object);
            mockApplicRepo.Setup(repo => repo.GetOne(2)).Returns(applList[2 - 1]);

            var del = logic.GetOneApplicant(2);

            mockApplicRepo.Setup(repo => repo.Remove(del)).Callback(() => applList.Remove(del));
            mockApplicRepo.Verify(repo => repo.Remove(del), Times.AtMostOnce);
        }

        /// <summary>
        /// Non crud test for applicant.
        /// </summary>
        [Test]
        public void TestApplicantSalaryWithTaxes()
        {
            Mock<IApplicantRepository> mockApplicRepo = new Mock<IApplicantRepository>(MockBehavior.Loose);
            Mock<IPaymentRepository> mockPaymentRepo = new Mock<IPaymentRepository>(MockBehavior.Loose);

            List<Applicant> listapp = new List<Applicant>()
            {
                new Applicant() { ApplId = 7, ApplName = "Kesha Bolbo", ApplIncome = 9000 },
                new Applicant() { ApplId = 9, ApplName = "Lexi Grey", ApplIncome = 6000 },
                new Applicant() { ApplId = 1, ApplName = "Arkagij Petrov", ApplIncome = 5000 },
                new Applicant() { ApplId = 3, ApplName = "Darina Kadurova", ApplIncome = 4100 },
                new Applicant() { ApplId = 4, ApplName = "Alina Komarova", ApplIncome = 3900 },
            };
            List<Payment> listpayment = new List<Payment>()
            {
                new Payment() { PayApplId = 7, PayIspayed = "payed" },
                new Payment() { PayApplId = 9, PayIspayed = "payed" },
                new Payment() { PayApplId = 1, PayIspayed = "payed" },
                new Payment() { PayApplId = 3, PayIspayed = "not payed" },
                new Payment() { PayApplId = 4, PayIspayed = "not payed" },
            };

            List<ApplicantSalaryWithTax> expectedTax = new List<ApplicantSalaryWithTax>()
            {
                new ApplicantSalaryWithTax() { ApplicantName = "Kesha Bolbo", SalaryWithTax = 7650, Pay = "payed" },
                new ApplicantSalaryWithTax() { ApplicantName = "Lexi Grey", SalaryWithTax = 5100, Pay = "payed" },
                new ApplicantSalaryWithTax() { ApplicantName = "Arkagij Petrov", SalaryWithTax = 4250, Pay = "payed" },
                new ApplicantSalaryWithTax() { ApplicantName = "Darina Kadurova", SalaryWithTax = 3485, Pay = "not payed" },
                new ApplicantSalaryWithTax() { ApplicantName = "Alina Komarova", SalaryWithTax = 3315, Pay = "not payed" },
            };
            mockApplicRepo.Setup(repo => repo.GetAll()).Returns(listapp.AsQueryable);
            mockPaymentRepo.Setup(repo => repo.GetAll()).Returns(listpayment.AsQueryable);

            ApplicantLogic logic = new ApplicantLogic(mockApplicRepo.Object, mockPaymentRepo.Object);

            var result = logic.GetApplicantsSalaryWithTax();

            Assert.That(result, Is.EquivalentTo(expectedTax));
            mockApplicRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
