namespace SecurityPractice.Tests.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class AssertionHelper
    {
        public static void HasOnlyOne<T>(IEnumerable<T> collection)
        {
            const int singleEntityCount = 1;

            Assert.AreEqual(singleEntityCount, collection.Count());
        }
    }
}
