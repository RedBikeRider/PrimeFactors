using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrimeFactors.Models;

namespace PrimeFactors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IList<PrimeFactorisation> _factors = new List<PrimeFactorisation>();
        public MainWindow()
        {
            InitializeComponent();

        }

        public void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            ok = int.TryParse(entered, out toFactorise);

            if (ok && toFactorise >= 2)
            {
                StringBuilder factorList = new StringBuilder();

                foreach (int factor in GetPrimeFactors(toFactorise, eratosthenes))
                {
                    if (factorList.Length == 0)
                        factorList.Append("Prime factor(s): ");
                    else
                        factorList.Append(", ");
                    factorList.Append(factor);
                }

                Console.WriteLine(factorList);
            }


        }

        private static IEnumerable<int> GetPrimeFactors(int value, Eratosthenes eratosthenes)
        {
            List<int> factors = new List<int>();

            foreach (int prime in eratosthenes)
            {
                while (value % prime == 0)
                {
                    value /= prime;
                    factors.Add(prime);
                }

                if (value == 1)
                    break;
            }

            return factors;
        }
    }
}
