using DistanceCalculatorService.Controllers;
using DistanceCalculatorService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DistanceCalculatorService.Tests
{
    public class DistanceCalculatorControllersTests
    {
        [SetUp]
        public void Setup()
        { 
                       
        }

        [Test]
        [TestCase(55.5,0,38.8,-77.1)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0, -77.2, -100.3)]
        [TestCase(-55.6, 0, -77.2, -100.3)]
        public void Get_CalculateDistanceKm_ReturnsCalculatedDistanceKm (double latitude, double longitude, double otherlatitude, double otherlongitude)
        {
            var mockservice = new Mock<IDistanceCalculatorService>();

            mockservice.Setup(x => x.CalculateDistance(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
                CalculationType.Haversine, UnitOfDistance.Km)).Returns(new CalculatedDistance { Distance=5800.0, UnitOfDistance=Model.UnitOfDistance.Km.ToString() });


            var controller = new DistanceCalculatorController(null, mockservice.Object);

            var result = controller.Get(latitude, longitude, otherlatitude, otherlongitude);
            var okresult = result as OkObjectResult;

            var calcDistance = okresult.Value as CalculatedDistance;

            Assert.IsNotNull(okresult);

            Assert.AreEqual(5800.0, calcDistance.Distance);
            Assert.AreEqual("Km", calcDistance.UnitOfDistance);
        }

        [Test]
        [TestCase(55.5, 0, 38.8, -77.1)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0, -77.2, -100.3)]
        [TestCase(-55.6, 0, -77.2, -100.3)]
        public void Get_CalculateDistanceMiles_ReturnsCalculatedDistanceMiles(double latitude, double longitude, double otherlatitude, double otherlongitude)
        {
            var mockservice = new Mock<IDistanceCalculatorService>();

            mockservice.Setup(x => x.CalculateDistance(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
                CalculationType.Haversine, UnitOfDistance.Miles)).Returns(new CalculatedDistance { Distance = 5800.0, UnitOfDistance = Model.UnitOfDistance.Miles.ToString() });

            var controller = new DistanceCalculatorController(null, mockservice.Object);
            
            var result = controller.Get(latitude, longitude, otherlatitude, otherlongitude, unitOfDistance:Model.UnitOfDistance.Miles);
            var okresult = result as OkObjectResult;

            var calcDistance = okresult.Value as CalculatedDistance;

            Assert.IsNotNull(okresult);

            Assert.AreEqual(5800.0, calcDistance.Distance);
            Assert.AreEqual("Miles", calcDistance.UnitOfDistance);


        }
        [Test]
        public void Get_DistanceCalculatorServiceThrowsException_ReturnsInternalServerError()
        {
            var mockservice = new Mock<IDistanceCalculatorService>();

            mockservice.Setup(x => x.CalculateDistance(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
                CalculationType.Haversine, UnitOfDistance.Km)).Throws( new System.Exception ("Internal Error"));

            var controller = new DistanceCalculatorController(null, mockservice.Object);

            var result = controller.Get(51.5, 0, 38.8, -77.1);

            var objectresult = result as ObjectResult;
            

            Assert.AreEqual(StatusCodes.Status500InternalServerError, objectresult.StatusCode);
        }
    }
}