using WorkforceManagement.Core.Domain.Projects;
using WorkforceManagement.Core.Domain.UnitTests.TestHelpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace WorkforceManagement.Core.Domain.UnitTests.Features.Projects
{
    [TestClass]
    public sealed class ProjectTests
    {
        [TestMethod]
        public void Create_Should_NormalizeNameDatesAndSettings_When_ProjectIsValid()
        {
            const string name = "  Alpha  ";
            var startDate = new DateTime(2026, 4, 1, 10, 30, 0);
            var endDate = new DateTime(2026, 4, 20, 18, 45, 0);
            const bool isTimeboxed = true;
            const int iterationLengthDays = 14;

            var project = Project.Create(name, startDate, endDate, isTimeboxed, iterationLengthDays);

            Assert.AreEqual("Alpha", project.Name);
            Assert.AreEqual(new DateTime(2026, 4, 1), project.StartDate);
            Assert.AreEqual(new DateTime(2026, 4, 20), project.EndDate);
            Assert.IsTrue(project.Settings.IsTimeboxed);
            Assert.AreEqual(iterationLengthDays, project.Settings.IterationLengthDays);
            Assert.AreEqual(0, project.Id);
            Assert.AreEqual(0, project.Settings.Id);
        }

        [TestMethod]
        public void Create_Should_ThrowArgumentException_When_EndDateIsEarlierThanStartDate()
        {
            const string name = "Alpha";
            var startDate = new DateTime(2026, 4, 10);
            var endDate = new DateTime(2026, 4, 9);

            DomainAssert.Throws<ArgumentException>(
                () => Project.Create(name, startDate, endDate, false, null),
                "endDate");
        }

        [TestMethod]
        public void AssignId_Should_AssignSameIdToProjectAndSettings_When_IdIsSet()
        {
            const string name = "Alpha";
            var startDate = new DateTime(2026, 4, 1);
            var endDate = new DateTime(2026, 4, 20);
            const bool isTimeboxed = true;
            const int iterationLengthDays = 14;
            const int firstId = 7;
            const int secondId = 8;
            var project = Project.Create(name, startDate, endDate, isTimeboxed, iterationLengthDays);

            project.AssignId(firstId);

            Assert.AreEqual(firstId, project.Id);
            Assert.AreEqual(firstId, project.Settings.Id);
            DomainAssert.Throws<InvalidOperationException>(() => project.AssignId(secondId));
        }

        [TestMethod]
        public void Update_Should_UpdateMainFieldsAndNestedSettings_When_ProjectDataChanges()
        {
            const string originalName = "Alpha";
            var originalStartDate = new DateTime(2026, 4, 1);
            var originalEndDate = new DateTime(2026, 4, 20);
            const bool originalIsTimeboxed = true;
            const int originalIterationLengthDays = 14;
            const string updatedName = "  Beta  ";
            var updatedStartDate = new DateTime(2026, 5, 1, 13, 0, 0);
            var project = Project.Create(
                originalName,
                originalStartDate,
                originalEndDate,
                originalIsTimeboxed,
                originalIterationLengthDays);

            project.Update(updatedName, updatedStartDate, null, false, null);

            Assert.AreEqual("Beta", project.Name);
            Assert.AreEqual(new DateTime(2026, 5, 1), project.StartDate);
            Assert.IsNull(project.EndDate);
            Assert.IsFalse(project.Settings.IsTimeboxed);
            Assert.IsNull(project.Settings.IterationLengthDays);
        }
    }
}
