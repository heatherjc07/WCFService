using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added reference
// System.ConfigurationInstall
// System.ServiceModel
// System.ServiceProcess
//added
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;


namespace Heather.ServiceModel.Samples
{

    // Define a service contract.
    [ServiceContract(Namespace = "http://Heather.ServiceModel.Samples")]
    public interface ICurrencyConverter
    {
        [OperationContract]
        double PoundsToDollars(double amt);
        [OperationContract]
        double DollarsToPounds(double amt);
        [OperationContract]
        double PoundsToEuros(double amt);
        [OperationContract]
        double EurosToPounds(double amt);
    }

    // Implement the ICurrencyConverter service contract in a service class.
    public class CurrencyConverterService : ICurrencyConverter
    {
        // Implement the ICurrencyConverter methods.
        public double PoundsToDollars(double amt)
        {
            double result = amt * 1.52;
            return result;
        }

        public double DollarsToPounds(double amt)
        {
            double result = amt * 0.66;
            return result;
        }


        public double PoundsToEuros(double amt)
        {
            double result = amt * 1.17;
            return result;
        }

        public double EurosToPounds(double amt)
        {
            double result = amt * 0.85;
            return result;
        }

    }

    public class CurrencyConverterWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public CurrencyConverterWindowsService()
        {
            // Name the Windows Service
            ServiceName = "CurrencyConverterService";
        }

        public static void Main()
        {
            ServiceBase.Run(new CurrencyConverterWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CurrencyConverterService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(CurrencyConverterService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }


        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }


    }


    // Provide the ProjectInstaller class which allows 
    // the service to be installed by the Installutil.exe tool
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "CurrencyConverterService";
            Installers.Add(process);
            Installers.Add(service);
        }
    }

}
