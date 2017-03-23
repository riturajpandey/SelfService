using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Managers.SettingManager
{
    public class SettingsManager : ISettingsManager
    {
        public static string RestUrl = "https://api.ettersokt.no/api/EttersoktObject/";
        // Credentials that are hard coded into the REST service
        public SettingsManager()
        {

        }
        /// <summary>
        /// Set API Host URL.
        /// </summary>
        public string ApiHost
        {
            get
            {
                //return "https://api.ettersokt.no/api/EttersoktObject/?searchWord=LS455";
                return "https://api.ettersokt.no/api/EttersoktObject/?searchWord=";
            }
        }
        public static string Username
        {
            get
            {
                return "c0410914-205d-4a74-b05f-7d2de989956b";
            }
        }
        public static string Password
        {
            get
            {
                return "f3900fc3-bb96-4225-8b5c-ec4a7b7fc801";
            }
        }
    }
}
