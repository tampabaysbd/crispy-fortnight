using System;
using System.Configuration;

namespace QDICodeChallenge.Data
{
    public class Constants
    {
        public static char[] NameSeperator
        {
            get
            {
                return (ConfigurationManager.AppSettings["nameSeperators"] ?? ", ").ToCharArray();
            }
        }

        

    }
}