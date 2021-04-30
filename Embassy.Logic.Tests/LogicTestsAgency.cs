// <copyright file="LogicTestsAgency.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Embassy.Program.Models;
    using Embassy.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test Agencies class. To test functions like:
    /// get all, get one, create, delete and non-crud method
    /// get one agency by entering the name.
    /// </summary>
    [TestFixture]
    public class LogicTestsAgency
    {
        /// <summary>
        /// Get instance to each of logic,repository and list
        /// for Mock.
        /// </summary>
        private List<Agency> agenList;
        private AgencyLogic agenLogici;
        private Mock<IAgencyRepository> agenRepo;

        /// <summary>
        /// Setup for entity imagine or true data with list
        /// setup what should be returned and set up mock with interface.
        /// </summary>
        [SetUp]
        public void SetUPAgency()
        {
            this.agenList = new List<Agency>()
            {
                new Agency() { AgenId = 1,  AgenName = "PegasTouristic" },
                new Agency() { AgenId = 2,   AgenName = "AmediaTour" },
                new Agency() { AgenId = 3,   AgenName = "StarTravel" },
            };

            this.agenRepo = new Mock<IAgencyRepository>(MockBehavior.Loose);
            this.agenRepo.Setup(repo => repo.GetAll()).Returns(this.agenList.AsQueryable);
            this.agenLogici = new AgencyLogic(this.agenRepo.Object);
        }

        /// <summary>
        /// Test for return all agencys.
        /// </summary>
        [Test]
        public void GetAllFunctionsShouldReturnForObject()
        {
            Assert.That(this.agenLogici.GetAllAgencies().Count, Is.EqualTo(3));
            this.agenRepo.Verify(mo => mo.GetOne(1), Times.Never);
        }

        /// <summary>
        /// Test of get one agency.
        /// </summary>
        /// <param name="id">int identical parameter. </param>
        [TestCase(1)]
        [TestCase(3)]
        public void GetOneReturnObject(int id)
        {
            this.agenRepo.Setup(r => r.GetOne(id)).Returns(this.agenList[id - 1]);
            Assert.That(this.agenLogici.GetOneAgency(id).AgenName, Is.EqualTo(this.agenList[id - 1].AgenName));
            this.agenRepo.Verify(r => r.GetOne(id), Times.Once);
        }

        /// <summary>
        /// CRUD test to delete one of the agency,
        /// with parameter id, which will be removed with one (-1).
        /// </summary>
        /// <param name="id"> int param.</param>
        [TestCase(2)]
        [TestCase(3)]
        public void TestDeleteOldAgency(int id)
        {
            this.agenRepo.Setup(repo => repo.GetOne(id)).Returns(this.agenList[id - 1]);
            var one = this.agenLogici.GetOneAgency(id);
            this.agenRepo.Setup(repo => repo.Remove(one)).Callback(() => this.agenList.Remove(one));
            this.agenLogici.DeleteAgency(id);
            this.agenRepo.Verify(r => r.Remove(one), Times.Once);
        }

        /// <summary>
        /// test get by name.
        /// </summary>
        [Test]
        public void TestGetAgencyByName()
        {
            Mock<IApplicantRepository> mockApplicRepo = new Mock<IApplicantRepository>(MockBehavior.Loose);
            Mock<IPaymentRepository> mockPaymentRepo = new Mock<IPaymentRepository>(MockBehavior.Loose);
            Mock<IAgencyRepository> mockAgRepo = new Mock<IAgencyRepository>(MockBehavior.Loose);
            Mock<IVisaRepository> mockVisaRepo = new Mock<IVisaRepository>(MockBehavior.Loose);

            List<Agency> agencyList = new List<Agency>()
            {
                new Agency() { AgenId = 1, AgenName = "PegasTouristic" },
                new Agency() { AgenId = 5, AgenName = "TravelAround" },
            };

            List<Applicant> appList = new List<Applicant>()
            {
                new Applicant() { ApplId = 1, ApplName = "Aplicant1" },
                new Applicant() { ApplId = 2, ApplName = "Aplicant2" },
                new Applicant() { ApplId = 3, ApplName = "Aplicant3" },
            };

            List<Payment> payList = new List<Payment>()
            {
                new Payment() { PayId = 1, PayAgenId = 1, PayApplId = 2 },
                new Payment() { PayId = 2, PayAgenId = 5, PayApplId = 3 },
                new Payment() { PayId = 3, PayAgenId = 5, PayApplId = 1 },
            };

            List<Visa> listvisa = new List<Visa>()
            {
                new Visa() { VisaId = 1, VisaApplId = 2, VisaIsapproved = "approved" },
                new Visa() { VisaId = 2, VisaApplId = 1,  VisaIsapproved = "approved" },
            };

            mockApplicRepo.Setup(rep => rep.GetAll()).Returns(appList.AsQueryable());
            mockPaymentRepo.Setup(rep => rep.GetAll()).Returns(payList.AsQueryable());
            mockAgRepo.Setup(rep => rep.GetAll()).Returns(agencyList.AsQueryable());
            mockVisaRepo.Setup(rep => rep.GetAll()).Returns(listvisa.AsQueryable());

            AgencyLogic logic = new AgencyLogic(mockAgRepo.Object, mockApplicRepo.Object, mockPaymentRepo.Object, mockVisaRepo.Object);

            var result = logic.GetAgencyByName("TravelAround");

            Assert.That(result.Number, Is.EqualTo(2));
            mockAgRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
