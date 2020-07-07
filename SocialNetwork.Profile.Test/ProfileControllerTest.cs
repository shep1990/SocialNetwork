using log4net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RestSharp.Extensions;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Data;
using SocialNetwork.Profile.Domain.Services;
using SocialNetwork.ProfileApi.Controllers;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Test
{
    [TestFixture]
    public class ProfileControllerTest
    {
        SignUpModel profileModel;
        ProfileEntity profileEntity;

        public ProfileControllerTest()
        {          
            profileModel = new SignUpModel()
            {
                Id = new Guid("2f6364c3-7574-48d8-91e4-9dce8627dc9d"),
                Name = "Richard Shepherd",
                Age = 29,
                Email = "richard@shepherd.com",
                DateOfBirth = DateTime.Parse("19/11/1990")
            };

            profileEntity = new ProfileEntity()
            {
                Id = new Guid("2f6364c3-7574-48d8-91e4-9dce8627dc9d"),
                Name = "Richard Shepherd",
                Age = 29,
                Email = "richard@shepherd.com",
                DateOfBirth = DateTime.Parse("19/11/1990")
            };
        }

        [Test]
        public async Task ProfileController_GetProfile_CorrectProfileObjectReturned()
        {
            //arrange
            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(x => x.GetProfile(It.IsAny<Guid>())).ReturnsAsync(profileModel);
            var sut = new ProfileController(mockProfileService.Object);

            //act
            var result = await sut.Get(It.IsAny<Guid>()) as OkObjectResult;
            var resultValue = (SignUpModel)result.Value;

            //assert
            Assert.AreEqual(profileModel.Id, resultValue.Id);
        }

        [Test]
        public async Task ProfileController_CreateProfile_CorrectStatusReturned()
        {
            //arrange
            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(x => x.SaveProfile(profileModel)).ReturnsAsync(profileEntity);
            var sut = new ProfileController(mockProfileService.Object);

            //act
            var result = await sut.Post(profileModel) as OkResult;
            var statusCode = result.StatusCode;

            //assert
            Assert.AreEqual(200, statusCode);
        }

        [Test]
        public async Task ProfileController_UpdateProfile_CorrectProfileObjectReturned()
        {
            //arrange
            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(x => x.UpdateProfile(profileModel, It.IsAny<Guid>())).ReturnsAsync(profileEntity);
            var sut = new ProfileController(mockProfileService.Object);

            //act
            var result = await sut.Put(profileModel, It.IsAny<Guid>()) as OkObjectResult;
            var resultObj = (ProfileEntity)result.Value;

            //assert
            Assert.AreEqual(profileEntity.Id, resultObj.Id);
        }


        [Test]
        public async Task ProfileController_GetProfile_ExceptionThrown()
        { 
            //arrange
            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(x => x.GetProfile(It.IsAny<Guid>())).Throws(new Exception());
            var sut = new ProfileController(mockProfileService.Object);

            //act
            var result = await sut.Get(It.IsAny<Guid>()) as BadRequestObjectResult;
            var statusCode = result.StatusCode;

            //assert
            Assert.AreEqual(400, statusCode);
        }

        [Test]
        public async Task ProfileController_CreateProfile_ExceptionThrown()
        {
            //arrange
            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(x => x.SaveProfile(profileModel)).Throws(new Exception());
            var sut = new ProfileController(mockProfileService.Object);

            //act
            var result = await sut.Post(profileModel) as BadRequestObjectResult;
            var statusCode = result.StatusCode;

            //assert
            Assert.AreEqual(400, statusCode);
        }

        [Test]
        public async Task ProfileController_UpdateProfile_ExceptionThrown()
        {
            //arrange
            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(x => x.UpdateProfile(profileModel, It.IsAny<Guid>())).Throws(new Exception());
            var sut = new ProfileController(mockProfileService.Object);

            //act
            var result = await sut.Put(profileModel, It.IsAny<Guid>()) as BadRequestObjectResult;
            var statusCode = result.StatusCode;

            //assert
            Assert.AreEqual(400, statusCode);
        }
    }
}
