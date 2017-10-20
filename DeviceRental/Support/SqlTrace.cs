using System;
using System.IO;

namespace DeviceRentalManagement.Support
{
    class SqlTrace
    {
        public static void WriteSQL(string data)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "SQLtrace.sql";
                File.AppendAllText(path, data);
            }
            catch (Exception)
            {

            }
        }
    }
}
