using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Test
    {
        static void Main()
        {
            CurrencyConverterClient client = new CurrencyConverterClient();

            // Use the 'client' variable to call operations on the service.
            double result = client.DollarsToPounds(10);
            double result2 = client.PoundsToDollars(10);
            double result3 = client.EurosToPounds(10);
            double result4 = client.PoundsToEuros(10);
            // Always close the client.
            client.Close();
        }
    }

