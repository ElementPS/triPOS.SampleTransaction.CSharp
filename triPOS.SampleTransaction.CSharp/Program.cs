namespace triPOS.SampleTransaction.CSharp
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    ///     The class containing the main method for the Send Request and View Receipt app
    /// </summary>
    internal static class Program
    {
        #region Methods

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new triPOSSampleTransactionCSharpForm());
        }

        #endregion
    }
}