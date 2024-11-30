using LibraryApp.Jobs;

namespace LibraryApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // starting the work of deleting old accounts
            DeletingScheduler.Start();

            Application.Run(new StartForm());
        }
    }
}
