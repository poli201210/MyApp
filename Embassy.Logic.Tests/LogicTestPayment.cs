// <copyright file="LogicTestPayment.cs" company="PlaceholderCompany">
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
    /// Class of test for Non-CRUD
    /// method for payment business logic.
    /// </summary>
    [TestFixture]
    public class LogicTestPayment
    {
        /// <summary>
        /// Non crud test for payments commissions.
        /// </summary>
        [Test]
        public void TestPaymentCommission()
        {
            Mock<IPaymentRepository> mockPayRepo = new Mock<IPaymentRepository>(MockBehavior.Loose);
            Mock<IAgencyRepository> mockAgenRepo = new Mock<IAgencyRepository>(MockBehavior.Loose);
            Mock<IApplicantRepository> mockAppRepo = new Mock<IApplicantRepository>(MockBehavior.Loose);

            List<Payment> listPay = new List<Payment>()
            {
                new Payment() { PayId = 1, PayAgenId = 1, PayApplId = 2, PayAmount = 50, PayIspayed = "payed" },
                new Payment() { PayId = 2, PayAgenId = 2, PayApplId = 3,  PayAmount = 100, PayIspayed = "not payed" },
                new Payment() { PayId = 3, PayAgenId = 3, PayApplId = 1, PayAmount = 100, PayIspayed = "payed" },
                new Payment() { PayId = 4, PayAgenId = 7, PayApplId = 4,  PayAmount = 60, PayIspayed = "not payed" },
                new Payment() { PayId = 5, PayAgenId = 5, PayApplId = 5, PayAmount = 130, PayIspayed = "payed" },
                new Payment() { PayId = 6, PayAgenId = 7, PayApplId = 8,  PayAmount = 67, PayIspayed = "payed" },
                new Payment() { PayId = 7, PayAgenId = 6, PayApplId = 10, PayAmount = 60, PayIspayed = "payed" },
                new Payment() { PayId = 8, PayAgenId = 4, PayApplId = 6,  PayAmount = 40, PayIspayed = "not payed" },
                new Payment() { PayId = 9, PayAgenId = 5, PayApplId = 7,  PayAmount = 10, PayIspayed = "not payed" },
                new Payment() { PayId = 10, PayAgenId = 5, PayApplId = 9,  PayAmount = 41, PayIspayed = "payed" },
            };
            List<Agency> listAgency = new List<Agency>()
            {
                new Agency() { AgenId = 1, AgenName = "PegasTouristic" },
                new Agency() { AgenId = 2,   AgenName = "AmediaTour" },
                new Agency() { AgenId = 3, AgenName = "StarTravel" },
                new Agency() { AgenId = 7,   AgenName = "PortalAsia" },
                new Agency() { AgenId = 5, AgenName = "TravelAround" },
                new Agency() { AgenId = 6,   AgenName = "AhmadTravel" },
                new Agency() { AgenId = 4, AgenName = "CCUnated" },
            };
            List<Applicant> listApplicant = new List<Applicant>()
            {
                new Applicant() { ApplId = 2 },
                new Applicant() { ApplId = 3 },
                new Applicant() { ApplId = 1 },
                new Applicant() { ApplId = 4 },
                new Applicant() { ApplId = 5 },
                new Applicant() { ApplId = 8 },
                new Applicant() { ApplId = 10 },
                new Applicant() { ApplId = 6 },
                new Applicant() { ApplId = 7 },
                new Applicant() { ApplId = 9 },
            };

            List<PaymentCommission> expectedExten = new List<PaymentCommission>()
            {
                new PaymentCommission() { AmountOfCommission = 6, IsPaid = "payed" },
                new PaymentCommission() { AmountOfCommission = 2, IsPaid = "not payed" },
            };
            mockPayRepo.Setup(repo => repo.GetAll()).Returns(listPay.AsQueryable);
            mockAppRepo.Setup(repo => repo.GetAll()).Returns(listApplicant.AsQueryable);
            mockAgenRepo.Setup(repo => repo.GetAll()).Returns(listAgency.AsQueryable);
            PaymentLogic logic = new PaymentLogic(mockAppRepo.Object, mockAgenRepo.Object, mockPayRepo.Object);

            var result = logic.GetPaymentCommissions();

            Assert.That(result, Is.EqualTo(expectedExten));
            mockPayRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
