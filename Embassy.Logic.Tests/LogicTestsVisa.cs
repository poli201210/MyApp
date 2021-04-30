// <copyright file="LogicTestsVisa.cs" company="PlaceholderCompany">
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
    /// Tests for visa table contains: Setup, two tests and
    /// four test cases.
    /// </summary>
    [TestFixture]
    public class LogicTestsVisa
    {
        private Mock<IVisaRepository> visaRepoMock;
        private VisaLogic visaLogic;
        private List<Visa> visaList;

        /// <summary>
        /// Initializing the Setup for tests visa.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.visaList = new List<Visa>()
            {
                new Visa() { VisaId = 1, VisaType = "D2" },
                new Visa() { VisaId = 2, VisaType = "X2" },
                new Visa() { VisaId = 3, VisaType = "T7" },
                new Visa() { VisaId = 4, VisaType = "D1" },
            };

            this.visaRepoMock = new Mock<IVisaRepository>(MockBehavior.Loose);
            this.visaRepoMock.Setup(repo => repo.GetAll()).Returns(this.visaList.AsQueryable);
            this.visaLogic = new VisaLogic(this.visaRepoMock.Object);
        }

        /// <summary>
        /// Tests Add new visa method.
        /// </summary>
        [Test]
        public void TestAddFunction()
        {
            Visa newVisa = new Visa();
            this.visaRepoMock.Setup(repo => repo.Create(newVisa)).Callback(() => this.visaList.Add(newVisa));
            this.visaLogic.AddVisa(newVisa);
            Assert.That(this.visaLogic.GetAllVisas().Count, Is.EqualTo(5));
            this.visaRepoMock.Verify(r => r.Create(newVisa), Times.Once);
        }

        /// <summary>
        /// Tests delete method for visa object.
        /// </summary>
        /// <param name="id">int.</param>
        [TestCase(4)]
        [TestCase(3)]
        public void TestDeleteFunction(int id)
        {
            this.visaRepoMock.Setup(repo => repo.GetOne(id)).Returns(this.visaList[id - 1]);
            var one = this.visaLogic.GetOneVisa(id);
            this.visaRepoMock.Setup(repo => repo.Remove(one)).Callback(() => this.visaList.Remove(one));
            this.visaLogic.RemoveOldVisa(id);
            this.visaRepoMock.Verify(repo => repo.Remove(one), Times.AtMostOnce);
        }

        /// <summary>
        /// Tests for GetAll method for vis object.
        /// </summary>
        [Test]
        public void GetAllFunctionsShouldReturnFour()
        {
            Assert.That(this.visaLogic.GetAllVisas().Count, Is.EqualTo(4));
            this.visaRepoMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        /// <summary>
        /// Non crud test for visa.
        /// </summary>
        [Test]
        public void TestVisaDaysBeforeLegalExtensions()
        {
            Mock<IVisaRepository> mockVisaRepo = new Mock<IVisaRepository>(MockBehavior.Loose);
            Mock<IApplicantRepository> mockApplicantRepo = new Mock<IApplicantRepository>(MockBehavior.Loose);

            List<Visa> listvisa = new List<Visa>()
            {
                new Visa() { VisaId = 1, VisaApplId = 2, VisaDuration = 30 },
                new Visa() { VisaId = 2, VisaApplId = 1,  VisaDuration = 90 },
                new Visa() { VisaId = 3, VisaApplId = 4, VisaDuration = 70 },
                new Visa() { VisaId = 7, VisaApplId = 7, VisaDuration = 61 },
            };
            List<Applicant> listapp = new List<Applicant>()
            {
                new Applicant() { ApplId = 2, ApplEmail = "pegastu@rambler.ru" },
                new Applicant() { ApplId = 1, ApplEmail = "prostnov@gmail.com" },
                new Applicant() { ApplId = 4, ApplEmail = "pop6790@yandex.ru" },
                new Applicant() { ApplId = 7, ApplEmail = "corrib21@gmail.com" },
            };
            List<VisaDaysBeforeLegalExtension> expectedExten = new List<VisaDaysBeforeLegalExtension>()
            {
                new VisaDaysBeforeLegalExtension() { VisaId = 1, Visadays = 0, ApplEmail = "PEGASTU@RAMBLER.RU" },
                new VisaDaysBeforeLegalExtension() { VisaId = 7, Visadays = 31, ApplEmail = "CORRIB21@GMAIL.COM" },
            };
            mockVisaRepo.Setup(repo => repo.GetAll()).Returns(listvisa.AsQueryable);
            mockApplicantRepo.Setup(repo => repo.GetAll()).Returns(listapp.AsQueryable);
            VisaLogic logic = new VisaLogic(mockApplicantRepo.Object, mockVisaRepo.Object);

            var result = logic.GetVisaActualDays();

            Assert.That(result, Is.EqualTo(expectedExten));
            mockVisaRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
