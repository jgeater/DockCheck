using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace DockCheck
{
    class Program
    {
        private const int ERROR_DOCK_PLUGGED_IN = 0xA0;
        private const int ERROR_WMI_QUERY_FAIL = 0xA2;
        static void Main(string[] args)
        {
            int dockCount = 0;

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PnPEntity WHERE Manufacturer = 'DisplayLink'");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    //Found a Dock so change dockCount to 1 and set the error code
                    dockCount=1;
                    Console.WriteLine("The dock is pluggen in.");
                    Environment.ExitCode = ERROR_DOCK_PLUGGED_IN;

                }
            }
            catch (ManagementException e)
            {
                //I couldnt query WMI for some reason So set the error code
                Console.WriteLine("An error occurred while querying for WMI data: {0}" + e.Message);
                Environment.ExitCode = ERROR_WMI_QUERY_FAIL;

            }
            Console.WriteLine(dockCount);
            Console.WriteLine("The dock is not pluggen in.");
            Environment.Exit(dockCount);
        }
    }
}
