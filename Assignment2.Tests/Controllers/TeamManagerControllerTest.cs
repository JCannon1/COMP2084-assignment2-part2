using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Web.Mvc;
using Assignment2.Controllers;
using Moq;
using Assignment2.Models;
using System.Linq;

namespace Assignment2.Tests.Controllers
{
    [TestClass]
    public class TeamManagerControllerTest
    {
        // Globals 
        TeamController controler;
        Mock<ITeamManagerRepository> mock;
        List<Team> teams;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange 
            mock = new Mock<ITeamManagerRepository>();

            // Mock Team data
            teams = new List<Team>
            {
                new Team { TeamId = 4, Title = "Team 4", City = "Florida" },
                new Team { TeamId = 5, Title = "Team 5", City = "New Jersey" },
                new Team { TeamId = 6, Title = "Team 6", City = "North Carolina" }
            };

            // Add Team data to the mock object
            mock.Setup(m => m.Teams).Returns(teams.AsQueryable());

            // Pass the mock to the controller
            controller = new TeamController(mock.Object);
        }

        // 1. Test to see if Index loads the correct View 
        [TestMethod]
        public void IndexLoadsValid()
        {
            // Arrange 
            //TeamManagerController controller = new TeamManagerController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // 2. Test to see if the Index Loads the correct type of data
        [TestMethod]
        public void IndexShowsValidTeams()
        {
            // Act
            var actual = (List<Team>)Controller.Index().Model;

            // Assert
            CollectionAssert.AreEqual(teams, actual);
        }

        // 3. Test to see if Details loads the correct object
        [TestMethod]
        public void DetailsValidId()
        {
            // Act
            

            // Assert
           
        }

        // 4. Test to see if Details loads the error view with an invalid Id
        [TestMethod]
        public void DetailsErrorView()
        {
            // Act
            

            // Assert
           
        }

        // 5. Test to see if Details loads the error view with no Id 
        [TestMethod]
        public void DetailsErrorViewNoId()
        {
            // Act


            // Assert

        }

        // 6. Test to see if DeleteConfirmed deletes the correct object 
        [TestMethod]
        public void DeleteConfirmed()
        {
            // Act


            // Assert

        }

        // 7. Test to see if DeleteConfirmed loads the error view with an invalid Id
        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // Act


            // Assert

        }

        // 8. Test to see if DeleteConfirmed loads the error view with no Id
        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // Act


            // Assert

        }
    }
}
