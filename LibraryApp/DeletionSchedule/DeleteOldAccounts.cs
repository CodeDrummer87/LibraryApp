using LibraryApp;
using Quartz;

namespace QuartzApp.Jobs
{
    public class DeleteOldAccounts : IJob
    {
        AccountActions account = new AccountActions();

        public async Task Execute(IJobExecutionContext context)
        {
            account.DeleteOldAccounts();
        }
    }
}