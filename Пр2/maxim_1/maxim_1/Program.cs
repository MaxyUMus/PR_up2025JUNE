namespace maxim_1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthForm());
        }
    }

    internal static class Constants
    {
        internal static string ConnectionString = "Host=localhost;Port=5433;Database=book_store;Username=postgres;Password=11111111";
        internal static Color PrimaryBackgroundColor = ColorTranslator.FromHtml("#FFFFFF");
        internal static Color SecondaryBackgroundColor = ColorTranslator.FromHtml("#8AB4FB");
        internal static Color AccentColor = ColorTranslator.FromHtml("#642B01");

        internal static Color GetContrastTextColor(Color backgroundColor)
        {
            double brightness = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            return brightness > 0.5 ? Color.Black : Color.White;
        }
    }
}