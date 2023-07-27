namespace LibraryApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new StartForm());
            Application.Run(new UserAccountForm());
        }
    }
}
