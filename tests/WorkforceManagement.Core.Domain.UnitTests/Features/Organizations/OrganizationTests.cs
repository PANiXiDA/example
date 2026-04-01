using WorkforceManagement.Core.Domain.Organizations;
using WorkforceManagement.Core.Domain.Organizations.Enums;
using WorkforceManagement.Core.Domain.UnitTests.TestHelpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace WorkforceManagement.Core.Domain.UnitTests.Features.Organizations
{
    [TestClass]
    public sealed class OrganizationTests
    {
        [TestMethod]
        public void Create_Should_TrimNameAndClearPartnerCode_When_InternalOrganizationIsCreated()
        {
            const string name = "  Internal team  ";
            const string partnerCode = "   ";

            var organization = Organization.Create(name, OrganizationType.Internal, partnerCode);

            Assert.AreEqual("Internal team", organization.Name);
            Assert.AreEqual(OrganizationType.Internal, organization.OrganizationType);
            Assert.IsNull(organization.PartnerCode);
            Assert.AreEqual(0, organization.Id);
        }

        [TestMethod]
        public void Create_Should_ThrowArgumentException_When_PartnerOrganizationHasNoPartnerCode()
        {
            const string name = "Partner";

            DomainAssert.Throws<ArgumentException>(
                () => Organization.Create(name, OrganizationType.Partner, null),
                "partnerCode");
        }

        [TestMethod]
        public void Update_Should_ThrowArgumentException_When_InternalOrganizationContainsPartnerCode()
        {
            const string originalName = "Partner";
            const string originalPartnerCode = "PR-1";
            const string updatedName = "Internal";
            const string updatedPartnerCode = "PR-2";
            var organization = Organization.Create(originalName, OrganizationType.Partner, originalPartnerCode);

            DomainAssert.Throws<ArgumentException>(
                () => organization.Update(updatedName, OrganizationType.Internal, updatedPartnerCode),
                "partnerCode");
        }
    }
}
