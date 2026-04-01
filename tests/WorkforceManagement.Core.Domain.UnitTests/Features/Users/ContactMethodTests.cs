using WorkforceManagement.Core.Domain.Users.Entities;
using WorkforceManagement.Core.Domain.Users.Enums;
using WorkforceManagement.Core.Domain.UnitTests.TestHelpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace WorkforceManagement.Core.Domain.UnitTests.Features.Users
{
    [TestClass]
    public sealed class ContactMethodTests
    {
        [TestMethod]
        public void Create_Should_TrimValueAndPreservePrimaryFlag_When_DataIsValid()
        {
            const int id = 1;
            const string value = "  user@example.com  ";

            var contactMethod = ContactMethod.Create(id, ContactMethodType.Email, value, true);

            Assert.AreEqual(id, contactMethod.Id);
            Assert.AreEqual(ContactMethodType.Email, contactMethod.Type);
            Assert.AreEqual("user@example.com", contactMethod.Value);
            Assert.IsTrue(contactMethod.IsPrimary);
        }

        [TestMethod]
        public void Create_Should_ThrowArgumentOutOfRangeException_When_IdIsNotPositive()
        {
            const int invalidId = 0;
            const string value = "user@example.com";

            DomainAssert.Throws<ArgumentOutOfRangeException>(
                () => ContactMethod.Create(invalidId, ContactMethodType.Email, value, false),
                "id");
        }

        [TestMethod]
        public void Update_Should_ReplaceValueAndPrimaryFlag_When_DataChanges()
        {
            const int id = 1;
            const string originalValue = "user@example.com";
            const string updatedValue = "  @user  ";
            var contactMethod = ContactMethod.Create(id, ContactMethodType.Email, originalValue, true);

            contactMethod.Update(ContactMethodType.Telegram, updatedValue, false);

            Assert.AreEqual(ContactMethodType.Telegram, contactMethod.Type);
            Assert.AreEqual("@user", contactMethod.Value);
            Assert.IsFalse(contactMethod.IsPrimary);
        }
    }
}
