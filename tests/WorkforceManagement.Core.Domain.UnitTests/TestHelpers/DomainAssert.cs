using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace WorkforceManagement.Core.Domain.UnitTests.TestHelpers
{
    internal static class DomainAssert
    {
        public static TException Throws<TException>(Action action, string paramName = null)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException exception)
            {
                if (paramName != null)
                {
                    var argumentException = exception as ArgumentException;

                    if (argumentException == null)
                    {
                        Assert.Fail(
                            "Expected exception with parameter name, but exception type does not inherit ArgumentException.");
                    }

                    Assert.AreEqual(paramName, argumentException.ParamName);
                }

                return exception;
            }
            catch (Exception exception)
            {
                Assert.Fail(
                    $"Expected exception of type {typeof(TException).Name}, but got {exception.GetType().Name}: {exception.Message}");
            }

            Assert.Fail($"Expected exception of type {typeof(TException).Name}, but no exception was thrown.");
            return null;
        }
    }
}
