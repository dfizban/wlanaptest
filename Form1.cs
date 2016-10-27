using System;
using System.Security.Permissions;//for registry key
using Microsoft.Win32;
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
using System.Diagnostics; // for running or killing new process  Process[] e.g. cmd
using System.Management;//To retrieve system hardware information.



namespace WiFiExample
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //change data type to 
        //Wlan.WlanBssEntry[] BssList = new Wlan.WlanBssEntry[10];

        [DllImport("Wlanapi.dll")]
        public static extern void WlanOpenHandle();

        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);

        }

        private void btn_RadioOn_Click(object sender, EventArgs e)
        {
            string IName = GetInterfaceNames();
            //var client = new WlanClient();
          
            TurnOn(IName);
          
        }

        private void btn_RadioOff_Click(object sender, EventArgs e)
        {

            
            /*
            WlanClient.WlanInterface wlanIface;
            
            IntPtr clientHandle = IntPtr.Zero;
            Wlan.WlanPhyRadioState state = new Wlan.WlanPhyRadioState();
            state.dwPhyIndex = 0;
            state.dot11SoftwareRadioState = Wlan.Dot11RadioState.Off;
            //state.dot11HardwareRadioState = Wlan.Dot11RadioState.Off;
            Wlan.WlanIntfOpcode opCode = Wlan.WlanIntfOpcode.RadioState;
            Wlan.WlanPhyRadioState radioState = new Wlan.WlanPhyRadioState();
            uint dataSize = (uint)Marshal.SizeOf(radioState);//why Marshal
            unsafe
            {
                Wlan.WlanPhyRadioState* pData = &state;
                IntPtr pReserved = IntPtr.Zero;
                Wlan.WlanSetInterface(clientHandle, client.Interfaces[0].InterfaceGuid, opCode, dataSize, (IntPtr)pData, pReserved);
            }

            //string[] InterfaceName = GetInterfaceNames();

            //WlanClient wc = new WlanClient();
            //TurnOff(InterfaceName.ToString());
            */
            string IName = GetInterfaceNames();
            TurnOff(IName);

        }

        #region WLAN FUNC
        public static string GetInterfaceNames()
        {
            //in order to release unmanaged code clearly, use "using () { } " 
            //which means inside the using brackets(), the variable will be released on } <----T.Dispose();
            using (var client = new WlanClient())
            {
                //lambda expression (input parameter) => {expression}
                //return client.Interfaces.Select(x => x.InterfaceName).ToArray();
                string InterfaceName;
                InterfaceName = client.Interfaces[0].InterfaceName;
                return InterfaceName;
            }
            //GC.SuppressFinalize(this); could add this statement to let Garbage Collector don't call Finalize() to avoid efficiency decrease. 
        }

        public static bool TurnOn(string interfaceName)
        {
            var interfaceGuid = GetInterfaceGuid(interfaceName);
            if (!interfaceGuid.HasValue)
                return false;

            return SetRadioState(interfaceGuid.Value, Wlan.Dot11RadioState.On);
        }

        public static bool TurnOff(string interfaceName)
        {
            var interfaceGuid = GetInterfaceGuid(interfaceName);
            if (!interfaceGuid.HasValue)
                return false;

            return SetRadioState(interfaceGuid.Value, Wlan.Dot11RadioState.Off);
        }

        private static Guid? GetInterfaceGuid(string interfaceName)
        {
            using (var client = new WlanClient())
            {
                return client.Interfaces.FirstOrDefault(x => x.InterfaceName == interfaceName)?.InterfaceGuid;
            }
        }
 
        private static bool SetRadioState(Guid interfaceGuid, Wlan.Dot11RadioState radioState)
        {
            //set Wlan.WlanPhyRadioState struct state's value.
            var state = new Wlan.WlanPhyRadioState
            {
                dwPhyIndex = (int)Wlan.Dot11PhyType.Any,
                dot11SoftwareRadioState = radioState,
            };
            var size = Marshal.SizeOf(state);

            var pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(state, pointer, false);

                var clientHandle = IntPtr.Zero;
                try
                {
                    uint negotiatedVersion;
                    var result = Wlan.WlanOpenHandle(
                        Wlan.WLAN_CLIENT_VERSION_LONGHORN,
                        IntPtr.Zero,
                        out negotiatedVersion,
                        out clientHandle);
                    if (result != 0)
                        return false;

                    result = Wlan.WlanSetInterface(
                        clientHandle,
                        interfaceGuid,
                        Wlan.WlanIntfOpcode.RadioState,
                        (uint)size,
                        pointer,
                        IntPtr.Zero);

                    return (result == 0);
                }
                finally
                {
                    Wlan.WlanCloseHandle(
                        clientHandle,
                        IntPtr.Zero);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pointer);
            }
        }

        public static string[] GetAvailableNetworkProfileNames(string interfaceName)
        {
            using (var client = new WlanClient())
            {
                var wlanInterface = client.Interfaces.FirstOrDefault(x => x.InterfaceName == interfaceName);
                if (wlanInterface == null)
                    return Array.Empty<string>();

                return wlanInterface.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllManualHiddenProfiles)
                    .Select(x => x.profileName)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();
            }
        }

        public static void ConnectNetwork(string interfaceName, string profileName)
        {
            using (var client = new WlanClient())
            {
                var wlanInterface = client.Interfaces.FirstOrDefault(x => x.InterfaceName == interfaceName);
                if (wlanInterface == null)
                    return;

                wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
            }
        }

        private static void GetInterfaceDescription()
        {
            var client = new WlanClient();
            WlanClient.WlanInterface[] WI = client.Interfaces;
            foreach (WlanClient.WlanInterface wi in WI)
            { 
                APInfo.SSID = wi.CurrentConnection.profileName;
                APInfo.WlanInterface = wi.InterfaceName;
                APInfo.RSSI = wi.RSSI;
                APInfo.Channel = wi.Channel;
                
                

            }
            
            //string IFD = client.Interfaces[0].InterfaceDescription;
            //return WD;
        }

        
        




        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnScanAP_Click(object sender, EventArgs e)
        {
            
            //fix:  It should works even if wlaninterface doesn't connect to AP 
            var client = new WlanClient();
            WlanClient.WlanInterface[] apCount = client.Interfaces;
            DataGridViewRowCollection rows = this.dataGridView1.Rows;//define DataGridViewRowCollection rows for adding new APs
            rows.Clear();//fix:  Clear() previous records of AP after press down button second time.


            //fix: 2 string concatenate to form a new one to perform DataGridViewCollection.add().
            foreach (WlanClient.WlanInterface APC in apCount) //loop all element returned by client.Interfaces with type WlanClient.WlanInterface
            {
                
                Wlan.WlanBssEntry[] bssNetworks = APC.GetNetworkBssList();//exception occurs when WlanInterface doesn't connect to AP
                Wlan.WlanAvailableNetwork[] availableNetworks = APC.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles);
                
                foreach (Wlan.WlanBssEntry network in bssNetworks)
                {
                    int rssi = network.rssi;
                    byte[] macAddr = network.dot11Bssid;

                    string tMac = "";
                    for (int i = 0; i < macAddr.Length; i++)
                    {
                        tMac += macAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();
                    }
                    
                    /*
                    for (int i = 0; i < availableNetworks.Length; i++)
                    {
                        string AuthMech = availableNetworks[i].dot11DefaultAuthAlgorithm.ToString();
                        string EncrypMech = availableNetworks[i].dot11DefaultCipherAlgorithm.ToString();
                        string[] MechString = { "", "", "", "", AuthMech, EncrypMech };
                        rows.Add(MechString);

                    }
                    */
                    //string[] row1 = { "hpinc", "3168", "-50", "36", "2F" }; for test only
                    string[] APstring = { System.Text.ASCIIEncoding.ASCII.GetString(network.dot11Ssid.SSID).ToString(), network.rssi.ToString(), APC.Channel.ToString(), tMac, };
                    //DataGridViewRowCollection rows = this.dataGridView1.Rows;       
                    rows.Add(APstring);
                    

                    //APC.Scan();
         
                }
              
            }
            
        }

       

        private void test()
        {
            
            
        }

        private void btnWiFiCap_Click(object sender, EventArgs e)
        {
            //call function to run command line: "netsh wlan show wirelesscapabilities"
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/C netsh wlan show wirelesscapabilities");
            startInfo.CreateNoWindow = true;//use hidden window mode to output string to new form2
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C netsh wlan show wirelesscapabilities";

            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;//in order to capture stdoutput the above command must assign to false.
            process.StartInfo = startInfo;
            process.Start();

            string s = process.StandardOutput.ReadToEnd();
            Form2 f2 = new Form2();
            f2.Show();
            f2.tBWlanCap.Text = s; //set Form2.Designers.cs Textboxt:tBWlanCap's accessible property to public in order to let Form1 class to access.
          
        }

        /*str : ProcessStartInfo startInfo.Arguments = str // command run on
        private string ExecuteCommandLine(string str)
        {
            //call function to run command line: "netsh wlan show wirelesscapabilities"
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//use hidden window mode to output string to new form2
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = str;
            process.StartInfo = startInfo;
            process.Start();

            
        }
        */

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //selected row from datagridview, it must matched with the parameters of Connect() to trigger.
            //Connect(Wlan.WlanConnectionMode connectionMode, Wlan.Dot11BssType bssType, string profile);
            WlanClient wc = new WlanClient();
             
            

        }

        private void fun()
        {
            

        }

        //To access system hardware information
        private void btnHWNetwokInfo_Click(object sender, EventArgs e)
        {
            //Add System Reference :System.Management to access system hardware information
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter");
            Form3 f3 = new Form3();
            f3.Show();
            foreach (ManagementObject share in searcher.Get())
            {
                //string str = share.
                
                //f3.HWNetworkDisplay.Text = str;
                foreach(PropertyData PD in share.Properties)
                {
                    

                }



            }

            

        }
    }


}
