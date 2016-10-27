using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NativeWifi;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WiFiExample
{

    //delegate return type : Wlan.WlanProfileInfo    Input Parameter : string
    public delegate Wlan.WlanProfileInfo D_GetWlanInfomation(string profileName);
    delegate void ShowWlanCapabilities(string profileName);
    delegate void ShoWlan(int x);

    public partial class APInfo : Form1
    {
        public static string SSID;
        public static string WlanInterface;
        public static int RSSI;
        public static int Channel;
        public string Security { set; get; }//auto-implemented properties must have get accessors.
        public string RadioType { set; get; }//auto-implemented properties must have get accessors.
        //e.g. APInfo ap = new APInfo();  get() ==> ap.Security  set() ==> string sec = ap.Security.
        



        //delegate e.g.
        public Wlan.WlanProfileInfo GetWlanInformation(string profileName)
        {
            Wlan.WlanProfileInfo WIF;
            WIF.profileName = profileName;
            WIF.profileFlags = Wlan.WlanProfileFlags.AllUser;

            ShowWlanCapabilities WlanCap2 = GetWlanCapabilities;
            ShowWlanCapabilities WlanCap1 = new ShowWlanCapabilities(GetWlanCapabilities);
            


            return WIF;
        }

        public void GetWlanCapabilities(string profileName)
        {

        }


    }
}
