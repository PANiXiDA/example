using WorkforceManagement.Core.Domain.UnitTests.TestHelpers;
using WorkforceManagement.Core.Domain.Users;
using WorkforceManagement.Core.Domain.Users.Enums;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace WorkforceManagement.Core.Domain.UnitTests.Features.Users
{
    [TestClass]
    public sealed class UserTests
    {
        [TestMethod]
        public void Create_Should_NormalizeFieldsAndAssignEmploymentProfileId_When_UserIdIsAssigned()
        {
            const string firstName = "  John  ";
            const string lastName = "  Doe  ";
            const string email = "  John.Doe@example.com  ";
            const int organizationId = 1;
            const string positionTitle = "  Developer  ";
            var hireDate = new DateTime(2026, 3, 1, 9, 0, 0);
            var probationEndDate = new DateTime(2026, 6, 1, 18, 0, 0);
            const int userId = 12;
            var user = User.Create(
                firstName,
                lastName,
                email,
                organizationId,
                EmploymentType.FullTime,
                40,
                positionTitle,
                hireDate,
                probationEndDate);

            user.AssignId(userId);

            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);
            Assert.AreEqual("john.doe@example.com", user.Email);
            Assert.AreEqual(userId, user.Id);
            Assert.AreEqual(userId, user.EmploymentProfile.Id);
        }

        [TestMethod]
        public void Create_Should_ThrowArgumentException_When_FullTimeUserHasInvalidWeeklyHours()
        {
            const string firstName = "John";
            const string lastName = "Doe";
            const string email = "john.doe@example.com";
            const int organizationId = 1;
            const int plannedWeeklyHours = 39;
            const string positionTitle = "Developer";
            var hireDate = new DateTime(2026, 3, 1);

            DomainAssert.Throws<ArgumentException>(
                () => User.Create(
                    firstName,
                    lastName,
                    email,
                    organizationId,
                    EmploymentType.FullTime,
                    plannedWeeklyHours,
                    positionTitle,
                    hireDate,
                    null),
                "PlannedWeeklyHours");
        }

        [TestMethod]
        public void AddContactMethod_Should_ClearPreviousPrimary_When_NewPrimaryContactMethodIsAdded()
        {
            const string firstName = "John";
            const string lastName = "Doe";
            const string email = "john.doe@example.com";
            const int organizationId = 1;
            const string positionTitle = "Developer";
            const string firstContactValue = "first@example.com";
            const string secondContactValue = "@first";
            var hireDate = new DateTime(2026, 3, 1);
            var user = User.Create(
                firstName,
                lastName,
                email,
                organizationId,
                EmploymentType.FullTime,
                40,
                positionTitle,
                hireDate,
                null);

            var firstContactMethodId = user.AddContactMethod(ContactMethodType.Email, firstContactValue, true);
            var secondContactMethodId = user.AddContactMethod(ContactMethodType.Telegram, secondContactValue, true);

            var firstContactMethod = user.ContactMethods.Single(item => item.Id == firstContactMethodId);
            var secondContactMethod = user.ContactMethods.Single(item => item.Id == secondContactMethodId);

            Assert.IsFalse(firstContactMethod.IsPrimary);
            Assert.IsTrue(secondContactMethod.IsPrimary);
        }

        [TestMethod]
        public void AddContactMethod_Should_ThrowArgumentException_When_NormalizedDuplicateExists()
        {
            const string firstName = "John";
            const string lastName = "Doe";
            const string email = "john.doe@example.com";
            const int organizationId = 1;
            const string positionTitle = "Developer";
            const string firstValue = " USER@example.com ";
            const string duplicateValue = "user@example.com";
            var hireDate = new DateTime(2026, 3, 1);
            var user = User.Create(
                firstName,
                lastName,
                email,
                organizationId,
                EmploymentType.FullTime,
                40,
                positionTitle,
                hireDate,
                null);
            user.AddContactMethod(ContactMethodType.Email, firstValue, false);

            DomainAssert.Throws<ArgumentException>(
                () => user.AddContactMethod(ContactMethodType.Email, duplicateValue, false),
                "value");
        }

        [TestMethod]
        public void UpdateContactMethod_Should_ClearPreviousPrimary_When_AnotherMethodBecomesPrimary()
        {
            const string firstName = "John";
            const string lastName = "Doe";
            const string email = "john.doe@example.com";
            const int organizationId = 1;
            const string positionTitle = "Developer";
            const string firstContactValue = "first@example.com";
            const string secondContactValue = "+79990000000";
            var hireDate = new DateTime(2026, 3, 1);
            var user = User.Create(
                firstName,
                lastName,
                email,
                organizationId,
                EmploymentType.FullTime,
                40,
                positionTitle,
                hireDate,
                null);
            var firstContactMethodId = user.AddContactMethod(ContactMethodType.Email, firstContactValue, true);
            var secondContactMethodId = user.AddContactMethod(ContactMethodType.Phone, secondContactValue, false);

            user.UpdateContactMethod(secondContactMethodId, ContactMethodType.Phone, secondContactValue, true);

            var firstContactMethod = user.ContactMethods.Single(item => item.Id == firstContactMethodId);
            var secondContactMethod = user.ContactMethods.Single(item => item.Id == secondContactMethodId);

            Assert.IsFalse(firstContactMethod.IsPrimary);
            Assert.IsTrue(secondContactMethod.IsPrimary);
        }

        [TestMethod]
        public void RemoveContactMethod_Should_RemoveMethod_When_ExistingContactMethodIsDeleted()
        {
            const string firstName = "John";
            const string lastName = "Doe";
            const string email = "john.doe@example.com";
            const int organizationId = 1;
            const string positionTitle = "Developer";
            const string contactValue = "first@example.com";
            var hireDate = new DateTime(2026, 3, 1);
            var user = User.Create(
                firstName,
                lastName,
                email,
                organizationId,
                EmploymentType.FullTime,
                40,
                positionTitle,
                hireDate,
                null);
            var contactMethodId = user.AddContactMethod(ContactMethodType.Email, contactValue, true);

            user.RemoveContactMethod(contactMethodId);

            Assert.AreEqual(0, user.ContactMethods.Count);
        }
    }
}
