using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Services.Interfaces;
using Insurance_Policy.Domain.Entities;
using NSubstitute;
using Insurance_Policy.Services.Services;
using System.Linq;
using Insurance_Policy.API.Controllers;
using System.Web.Http.Results;
using NSubstitute.ExceptionExtensions;

namespace Insurance_Policy.API.Tests.Controllers
{
    /// <summary>
    /// Descripción resumida de InsuranceControllerTest
    /// </summary>
    [TestClass]
    public class InsuranceControllerTest
    {
        private IInsuranceRepository insuranceRepository;
        private IInsuranceService<Insurance> insuranceService;

        [TestInitialize]
        public void Initialize()
        {
            this.insuranceService = Substitute.For<IInsuranceService<Insurance>>();
            this.insuranceRepository = Substitute.For<IInsuranceRepository>();
            this.insuranceService = new InsuranceService(this.insuranceRepository);
        }

        [TestMethod]
        public void GetAllTestOk()
        {
            //Arrange
            var list = new List<Insurance>()
            {
                new Insurance()
                {
                    CoverageId = 1,
                    CoveragePeriod = 5,
                    Description = "Prueba Poliza 1",
                    Id = 1,
                    Name = "Prueba 1",
                    Pricing = 5000,
                    RiskId = 1,
                    StartDate = DateTime.Now
                },
                new Insurance()
                {
                    CoverageId = 2,
                    CoveragePeriod = 12,
                    Description = "Prueba Poliza 2",
                    Id = 2,
                    Name = "Prueba 2",
                    Pricing = 10000,
                    RiskId = 2,
                    StartDate = DateTime.Now
                }
            }.AsQueryable();

            //Act
            this.insuranceRepository.GetAll().Returns(list);
            var controller = new InsuranceController(this.insuranceService);
            var result = controller.GetInsurances() as OkNegotiatedContentResult<List<Insurance>>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Any());
        }

        [TestMethod]
        public void GetAllTestError()
        {
            //Arrange
            var list = this.GetInsurances().AsQueryable();

            //Act
            this.insuranceRepository.GetAll().Throws(new Exception());
            var controller = new InsuranceController(this.insuranceService);
            var result = controller.GetInsurances() as InternalServerErrorResult;

            //Assert
            Assert.IsNotNull(result);
        }

        private List<Insurance> GetInsurances() =>
            new List<Insurance>()
            {
                new Insurance()
                {
                    CoverageId = 1,
                    CoveragePeriod = 5,
                    Description = "Prueba Poliza 1",
                    Id = 1,
                    Name = "Prueba 1",
                    Pricing = 5000,
                    RiskId = 1,
                    StartDate = DateTime.Now
                },
                new Insurance()
                {
                    CoverageId = 2,
                    CoveragePeriod = 12,
                    Description = "Prueba Poliza 2",
                    Id = 2,
                    Name = "Prueba 2",
                    Pricing = 10000,
                    RiskId = 2,
                    StartDate = DateTime.Now
                }
            };
    }
}
