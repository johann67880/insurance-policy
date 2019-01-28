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
using System.Linq.Expressions;
using Insurance_Policy.Domain.Models;

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
        private IRiskTypeRepository riskRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.riskRepository = Substitute.For<IRiskTypeRepository>();
            this.insuranceService = Substitute.For<IInsuranceService<Insurance>>();
            this.insuranceRepository = Substitute.For<IInsuranceRepository>();
            this.insuranceService = new InsuranceService(this.insuranceRepository, this.riskRepository);
        }

        [TestMethod]
        public void GetAllTestOk()
        {
            //Arrange
            var list = this.GetInsurancesModel();

            //Act
            this.insuranceRepository.GetAllInsurances().Returns(list);
            var controller = new InsuranceController(this.insuranceService);
            var result = controller.GetAllInsurances() as OkNegotiatedContentResult<List<InsuranceModel>>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Any());
        }

        [TestMethod]
        public void GetAllTestError()
        {
            //Arrange
            var list = this.GetInsurancesModel();

            //Act
            this.insuranceRepository.GetAllInsurances().Throws(new Exception());
            var controller = new InsuranceController(this.insuranceService);
            var result = controller.GetAllInsurances() as InternalServerErrorResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveInsuranceWithHighRiskTypeOK()
        {
            //Arrange
            var riskTypes = this.GetRiskTypes().AsQueryable();
            var insurance = new Insurance()
            {
                CoverageId = 1,
                Id = 0,
                CoveragePercentage = 40,
                CoveragePeriod = 5,
                Description = "Prueba Descripcion",
                Name = "Prueba Poliza",
                Pricing = 15000,
                RiskId = 4,
                StartDate = DateTime.Now
            };

            var highRisk = this.GetHighRiskType();

            //Act
            this.riskRepository.Get(insurance.RiskId).Returns(highRisk);
            var controller = new InsuranceController(this.insuranceService);
            var result = controller.SaveInsurance(insurance) as OkNegotiatedContentResult<bool>;

            //Assert
            Assert.IsTrue(result.Content);

        }

        [TestMethod]
        public void SaveInsuranceWithHighRiskType()
        {
            //Arrange
            var riskTypes = this.GetRiskTypes().AsQueryable();

            var insurance = new Insurance()
            {
                CoverageId = 1,
                Id = 0,
                CoveragePercentage = 50,
                CoveragePeriod = 5,
                Description = "Prueba Descripcion",
                Name = "Prueba Poliza",
                Pricing = 15000,
                RiskId = 4,
                StartDate = DateTime.Now
            };

            var highRisk = this.GetHighRiskType();

            //Act
            this.riskRepository.Get(insurance.RiskId).Returns(highRisk);
            var controller = new InsuranceController(this.insuranceService);
            var result = controller.SaveInsurance(insurance) as OkNegotiatedContentResult<bool>;

            //Assert
            Assert.IsFalse(result.Content);

        }

        private RiskType GetHighRiskType() =>
            new RiskType()
            {
                Id = 1,
                Type = "Alto"
            };


        private List<RiskType> GetRiskTypes() =>
            new List<RiskType>()
            {
                new RiskType()
                {
                    Id = 1,
                    Type = "Bajo"
                },
                new RiskType()
                {
                    Id = 2,
                    Type = "Medio"
                },
                new RiskType()
                {
                    Id = 3,
                    Type = "Medio-Alto"
                },
                new RiskType()
                {
                    Id = 4,
                    Type = "Alto"
                }

            };

        private List<InsuranceModel> GetInsurancesModel() =>
            new List<InsuranceModel>()
            {
                new InsuranceModel()
                {
                    CoverageId = 1,
                    CoveragePeriod = 5,
                    Description = "Prueba Poliza 1",
                    Id = 1,
                    Name = "Prueba 1",
                    Pricing = 5000,
                    RiskId = 1,
                    StartDate = DateTime.Now,
                    CoveragePercentage = 40,
                    CoverageType = "Terremoto",
                    RiskType = "Alto"
                },
                new InsuranceModel()
                {
                    CoverageId = 2,
                    CoveragePeriod = 12,
                    Description = "Prueba Poliza 2",
                    Id = 2,
                    Name = "Prueba 2",
                    Pricing = 10000,
                    RiskId = 2,
                    StartDate = DateTime.Now,
                    CoveragePercentage = 80,
                    CoverageType = "Incendio",
                    RiskType = "Bajo"
                }
            };
    }
}
