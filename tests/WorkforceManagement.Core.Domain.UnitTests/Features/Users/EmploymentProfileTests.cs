using WorkforceManagement.Core.Domain.Users.Entities;
using WorkforceManagement.Core.Domain.UnitTests.TestHelpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace WorkforceManagement.Core.Domain.UnitTests.Features.Users
{
    [TestClass]
    public sealed class EmploymentProfileTests
    {
        [TestMethod]
        public void Create_Should_NormalizePositionTitleAndDates_When_ProfileIsValid()
        {
            const string positionTitle = "  Backend developer  ";
            var hireDate = new DateTime(2026, 3, 1, 12, 0, 0);
            var probationEndDate = new DateTime(2026, 6, 1, 17, 30, 0);

            var profile = EmploymentProfile.Create(positionTitle, hireDate, probationEndDate);

            Assert.AreEqual("Backend developer", profile.PositionTitle);
            Assert.AreEqual(new DateTime(2026, 3, 1), profile.HireDate);
            Assert.AreEqual(new DateTime(2026, 6, 1), profile.ProbationEndDate);
            Assert.AreEqual(0, profile.Id);
        }

        [TestMethod]
        public void Create_Should_ThrowArgumentException_When_ProbationEndDateIsEarlierThanHireDate()
        {
            const string positionTitle = "Backend developer";
            var hireDate = new DateTime(2026, 3, 10);
            var probationEndDate = new DateTime(2026, 3, 9);

            DomainAssert.Throws<ArgumentException>(
                () => EmploymentProfile.Create(positionTitle, hireDate, probationEndDate),
                "probationEndDate");
        }

        [TestMethod]
        public void AssignId_Should_AssignValueAndThrowOnReassign_When_IdIsSet()
        {
            const string positionTitle = "Backend developer";
            var hireDate = new DateTime(2026, 3, 1);
            const int firstId = 9;
            const int secondId = 10;
            var profile = EmploymentProfile.Create(positionTitle, hireDate, null);

            profile.AssignId(firstId);

            Assert.AreEqual(firstId, profile.Id);
            DomainAssert.Throws<InvalidOperationException>(() => profile.AssignId(secondId));
        }
    }
}
