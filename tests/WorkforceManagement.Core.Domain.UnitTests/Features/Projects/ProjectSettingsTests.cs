using WorkforceManagement.Core.Domain.Projects.Entities;
using WorkforceManagement.Core.Domain.UnitTests.TestHelpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace WorkforceManagement.Core.Domain.UnitTests.Features.Projects
{
    [TestClass]
    public sealed class ProjectSettingsTests
    {
        [TestMethod]
        public void Create_Should_ThrowArgumentException_When_TimeboxedProjectHasNoIterationLength()
        {
            const bool isTimeboxed = true;

            DomainAssert.Throws<ArgumentException>(
                () => ProjectSettings.Create(isTimeboxed, null),
                "iterationLengthDays");
        }

        [TestMethod]
        public void Create_Should_ThrowArgumentException_When_NonTimeboxedProjectContainsIterationLength()
        {
            const bool isTimeboxed = false;
            const int iterationLengthDays = 10;

            DomainAssert.Throws<ArgumentException>(
                () => ProjectSettings.Create(isTimeboxed, iterationLengthDays),
                "iterationLengthDays");
        }

        [TestMethod]
        public void AssignId_Should_AssignValueAndThrowOnReassign_When_IdIsSet()
        {
            const bool isTimeboxed = true;
            const int iterationLengthDays = 14;
            const int firstId = 5;
            const int secondId = 6;
            var settings = ProjectSettings.Create(isTimeboxed, iterationLengthDays);

            settings.AssignId(firstId);

            Assert.AreEqual(firstId, settings.Id);
            DomainAssert.Throws<InvalidOperationException>(() => settings.AssignId(secondId));
        }
    }
}
