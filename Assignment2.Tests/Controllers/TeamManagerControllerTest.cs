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
        HockeyTeamsController controller;
        Mock<ITeamManagerRepository> mock;
        List<Table_HockeyTeams> teams;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange 
            mock = new Mock<ITeamManagerRepository>();

            // Mock Team data
            teams = new List<Table_HockeyTeams>
            {
                new Table_HockeyTeams { teamId = "4", teamName = "Team 4", teamCity = "Florida" },
                new Table_HockeyTeams { teamId = "5", teamName = "Team 5", teamCity = "New Jersey" },
                new Table_HockeyTeams { teamId = "6", teamName = "Team 6", teamCity = "North Carolina" }
            };

            // Add Team data to the mock object
            mock.Setup(m => m.Teams).Returns(teams.AsQueryable());

            // Pass the mock to the controller
            controller = new HockeyTeamsController(mock.Object);
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
            var actual = (List<Table_HockeyTeams>)controller.Index().Model;

            // Assert
            CollectionAssert.AreEqual(teams, actual);
        }

        // 3. Test to see if Details loads the correct object
        [TestMethod]
        public void DetailsValidId()
        {
            // Act
            var actual = (Table_HockeyTeams)controller.Details("4").Model;

            // Assert
            Assert.AreEqual(teams.ToList()[0], actual);
        }

        // 4. Test to see if Details loads the error view with an invalid Id
        [TestMethod]
        public void DetailsInvalidId()
        {
            // Act
            ViewResult actual = controller.Details("4");

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // 5. Test to see if Details loads the error view with no Id 
        [TestMethod]
        public void DetailsInvalidNoId()
        {
            // Act
            ViewResult actual = controller.Details(null);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // 6. Test to see if DeleteConfirmed deletes the correct object 
        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // Act
            ViewResult actual = controller.DeleteConfirmed(null);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // 7. Test to see if DeleteConfirmed loads the error view with an invalid Id
        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // Act
            ViewResult actual = controller.DeleteConfirmed("4");

            // Assert
            Assert.AreEqual("Error", actual.ViewName);

        }

        // 8. Test to see if DeleteConfirmed loads the error view with valid Id
        [TestMethod] 
        public void DeleteConfirmedValidId()
        {
            // Act
            ViewResult actual = controller.DeleteConfirmed("1");

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }
    }
}
