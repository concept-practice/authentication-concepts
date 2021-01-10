namespace SecurityPractice.Tests.Common
{
    public abstract class BaseIntegrationTest
    {
        protected BaseIntegrationTest()
        {
            IntegrationHelper.ClearDatabase();
        }
    }
}
