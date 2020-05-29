using System;
using System.Linq;
using System.Windows.Forms;

namespace FindPairsGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            var size = 16;
            if (args.Where(arg => int.TryParse(arg, out size)).Any(arg => size / 2 == 1))
            {
                throw new ArgumentException(nameof(size));
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FindPairsForm(size));
        }
    }
}
