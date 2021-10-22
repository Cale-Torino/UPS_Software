using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Globalization;

namespace USB_Communication
{
    public partial class GUI : Form
    {
        #region WinAPI

		    [DllImport("setupapi.dll", SetLastError = true)]
            static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

		    [DllImport("setupapi.dll", SetLastError = true)]
            static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, int memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

            [DllImport(@"setupapi.dll", SetLastError = true)]
            static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

            [DllImport(@"setupapi.dll", SetLastError = true)]
            static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

            [DllImport(@"kernel32.dll", SetLastError = true)]
            static extern IntPtr CreateFile(string fileName, uint fileAccess, uint fileShare, FileMapProtection securityAttributes, uint creationDisposition, uint flags, IntPtr overlapped);

            [DllImport("kernel32.dll")]
            static extern bool WriteFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

		    [DllImport("kernel32.dll")]
            static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped);

            [DllImport("hid.dll")]
            static extern void HidD_GetHidGuid(ref Guid Guid);

            [DllImport("hid.dll", SetLastError = true)]
            static extern bool HidD_GetPreparsedData(IntPtr HidDeviceObject, ref IntPtr PreparsedData);

            [DllImport("hid.dll", SetLastError = true)]
            static extern bool HidD_GetAttributes(IntPtr DeviceObject, ref HIDD_ATTRIBUTES Attributes);

            [DllImport("hid.dll", SetLastError=true)]
            static extern uint HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

            [DllImport("hid.dll", SetLastError = true)]
            static extern int HidP_GetButtonCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_BUTTON_CAPS[] ButtonCaps, ref ushort ButtonCapsLength, IntPtr PreparsedData);
        
            [DllImport("hid.dll", SetLastError = true)]
            static extern int HidP_GetValueCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_VALUE_CAPS[] ValueCaps, ref ushort ValueCapsLength, IntPtr PreparsedData);

            [DllImport("hid.dll", SetLastError = true)]
            static extern int HidP_MaxUsageListLength(HIDP_REPORT_TYPE ReportType, ushort UsagePage, IntPtr PreparsedData);

            [DllImport("hid.dll", SetLastError = true)]
            static extern int HidP_SetUsages(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, short Usages, ref int UsageLength, IntPtr PreparsedData, IntPtr Report, int ReportLength);
        
            [DllImport("hid.dll", SetLastError = true)]
            static extern int HidP_SetUsageValue(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, ushort Usage, ulong UsageValue, IntPtr PreparsedData, IntPtr Report, int ReportLength);

            [DllImport("setupapi.dll", SetLastError = true)]
            static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

            [DllImport("kernel32.dll", SetLastError=true)]
            static extern bool CloseHandle(IntPtr hObject);

            [DllImport("hid.dll", SetLastError=true)]
            static extern bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

            [DllImport("kernel32.dll")]
            static extern uint GetLastError();

        #endregion

        #region DLL Var

            IntPtr  hardwareDeviceInfo;

            ushort DEVICE_VID, DEVICE_VIDa;
            ushort DEVICE_PID, DEVICE_PIDa;
            ushort USAGE_PAGE;
            ushort USAGE;
            byte   REPORT_ID;

            const int  DIGCF_DEFAULT            = 0x00000001;
            const int  DIGCF_PRESENT            = 0x00000002;
            const int  DIGCF_ALLCLASSES         = 0x00000004;
            const int  DIGCF_PROFILE            = 0x00000008;
            const int  DIGCF_DEVICEINTERFACE    = 0x00000010;
                                             
            const uint GENERIC_READ             = 0x80000000;
            const uint GENERIC_WRITE            = 0x40000000;
            const uint GENERIC_EXECUTE          = 0x20000000;
            const uint GENERIC_ALL              = 0x10000000;
                                             
            const uint FILE_SHARE_READ          = 0x00000001;  
            const uint FILE_SHARE_WRITE         = 0x00000002;  
            const uint FILE_SHARE_DELETE        = 0x00000004;  

            const uint CREATE_NEW               = 1;
            const uint CREATE_ALWAYS            = 2;
            const uint OPEN_EXISTING            = 3;
            const uint OPEN_ALWAYS              = 4;
            const uint TRUNCATE_EXISTING        = 5;

            const int  HIDP_STATUS_SUCCESS      = 1114112;
            const int  DEVICE_PATH              = 260;
            const int  INVALID_HANDLE_VALUE     = -1;

            enum FileMapProtection : uint
            {
                PageReadonly            = 0x02,
                PageReadWrite           = 0x04,
                PageWriteCopy           = 0x08,
                PageExecuteRead         = 0x20,
                PageExecuteReadWrite    = 0x40,
                SectionCommit           = 0x8000000,
                SectionImage            = 0x1000000,
                SectionNoCache          = 0x10000000,
                SectionReserve          = 0x4000000,
            }

            enum HIDP_REPORT_TYPE : ushort
            {
                HidP_Input   = 0x00,
                HidP_Output  = 0x01,
                HidP_Feature = 0x02,
            }

            [StructLayout(LayoutKind.Sequential)]
            struct LIST_ENTRY
            {
                public IntPtr Flink;
                public IntPtr Blink;
            }

            [StructLayout(LayoutKind.Sequential)]
            struct DEVICE_LIST_NODE
            {
                public LIST_ENTRY      Hdr;
                public IntPtr          NotificationHandle;
                public HID_DEVICE      HidDeviceInfo;
                public bool            DeviceOpened;
            }

            [StructLayout(LayoutKind.Sequential)]
            struct SP_DEVICE_INTERFACE_DATA
            {
                public  Int32   cbSize;
                public  Guid    interfaceClassGuid;
                public  Int32   flags;
                private UIntPtr reserved;
            }
        
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            struct SP_DEVICE_INTERFACE_DETAIL_DATA
            {
                public int cbSize;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
                public string DevicePath;
            }    

            [StructLayout(LayoutKind.Sequential)]
            struct SP_DEVINFO_DATA
            {
               public int       cbSize;
               public Guid      classGuid;
               public UInt32    devInst;
               public IntPtr    reserved;
            }

            [StructLayout(LayoutKind.Sequential)]
            struct HIDP_CAPS
            {
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 Usage;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 UsagePage;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 InputReportByteLength;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 OutputReportByteLength;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 FeatureReportByteLength;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
                public UInt16[] Reserved;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberLinkCollectionNodes;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberInputButtonCaps;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberInputValueCaps;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberInputDataIndices;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberOutputButtonCaps;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberOutputValueCaps;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberOutputDataIndices;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberFeatureButtonCaps;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberFeatureValueCaps;
                [MarshalAs(UnmanagedType.U2)]
                public UInt16 NumberFeatureDataIndices;
            };

            [StructLayout(LayoutKind.Sequential)]
            struct HIDD_ATTRIBUTES
            { 
                public Int32    Size; 
                public UInt16   VendorID; 
                public UInt16   ProductID; 
                public Int16    VersionNumber; 
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ButtonData
            {
                 public Int32 UsageMin;
                 public Int32 UsageMax;
                 public Int32 MaxUsageLength; 
                 public Int16 Usages;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct ValueData
            {
                 public ushort  Usage;
                 public ushort  Reserved;

                 public ulong   Value;
                 public long    ScaledValue;
            }

            [StructLayout(LayoutKind.Explicit)]
            struct HID_DATA
            {
                [FieldOffset(0)]
                public bool     IsButtonData;
                [FieldOffset(1)]
                public byte     Reserved;
                [FieldOffset(2)]
                public ushort UsagePage;
                [FieldOffset(4)]
                public Int32    Status;
                [FieldOffset(8)]
                public Int32    ReportID;
                [FieldOffset(16)]
                public bool     IsDataSet;

                [FieldOffset(17)]
                public ButtonData ButtonData;
                [FieldOffset(17)]
                public ValueData ValueData;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct HIDP_Range
            {
                public ushort UsageMin,         UsageMax;
                public ushort StringMin,        StringMax;
                public ushort DesignatorMin,    DesignatorMax;
                public ushort DataIndexMin,     DataIndexMax;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct HIDP_NotRange
            {
                public ushort Usage,            Reserved1;
                public ushort StringIndex,      Reserved2;
                public ushort DesignatorIndex,  Reserved3;
                public ushort DataIndex,        Reserved4;
            }

            [StructLayout(LayoutKind.Explicit)]
            struct HIDP_BUTTON_CAPS
            {
                [FieldOffset(0)]
                public ushort UsagePage;
                [FieldOffset(2)]
                public byte ReportID;
                [FieldOffset(3), MarshalAs(UnmanagedType.U1)]
                public bool IsAlias;
                [FieldOffset(4)]
                public short BitField;
                [FieldOffset(6)]
                public short LinkCollection;
                [FieldOffset(8)]
                public short LinkUsage;
                [FieldOffset(10)]
                public short LinkUsagePage;
                [FieldOffset(12), MarshalAs(UnmanagedType.U1)]
                public bool IsRange;
                [FieldOffset(13), MarshalAs(UnmanagedType.U1)]
                public bool IsStringRange;
                [FieldOffset(14), MarshalAs(UnmanagedType.U1)]
                public bool IsDesignatorRange;
                [FieldOffset(15), MarshalAs(UnmanagedType.U1)]
                public bool IsAbsolute;
                [FieldOffset(16), MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
                public int[] Reserved;
                [FieldOffset(56)]
                public HIDP_Range Range;
                [FieldOffset(56)]
                public HIDP_NotRange NotRange;
            }

            [StructLayout(LayoutKind.Explicit)]
            struct HIDP_VALUE_CAPS
            {
                [FieldOffset(0)]
                public ushort UsagePage;
                [FieldOffset(2)]
                public byte ReportID;
                [FieldOffset(3), MarshalAs(UnmanagedType.U1)]
                public bool IsAlias;
                [FieldOffset(4)]
                public ushort BitField;
                [FieldOffset(6)]
                public ushort LinkCollection;
                [FieldOffset(8)]
                public ushort LinkUsage;
                [FieldOffset(10)]
                public ushort LinkUsagePage;
                [FieldOffset(12), MarshalAs(UnmanagedType.U1)]
                public bool IsRange;
                [FieldOffset(13), MarshalAs(UnmanagedType.U1)]
                public bool IsStringRange;
                [FieldOffset(14), MarshalAs(UnmanagedType.U1)]
                public bool IsDesignatorRange;
                [FieldOffset(15), MarshalAs(UnmanagedType.U1)]
                public bool IsAbsolute;
                [FieldOffset(16), MarshalAs(UnmanagedType.U1)]
                public bool HasNull;
                [FieldOffset(17)]
                public byte Reserved;
                [FieldOffset(18)]
                public short BitSize;
                [FieldOffset(20)]
                public short ReportCount;
                [FieldOffset(22)]
                public ushort Reserved2a;
                [FieldOffset(24)]
                public ushort Reserved2b;
                [FieldOffset(26)]
                public ushort Reserved2c;
                [FieldOffset(28)]
                public ushort Reserved2d;
                [FieldOffset(30)]
                public ushort Reserved2e;
                [FieldOffset(32)]
                public int UnitsExp;
                [FieldOffset(36)]
                public int Units;
                [FieldOffset(40)]
                public int LogicalMin;
                [FieldOffset(44)]
                public int LogicalMax;
                [FieldOffset(48)]
                public int PhysicalMin;
                [FieldOffset(52)]
                public int PhysicalMax;
                [FieldOffset(56)]
                public HIDP_Range Range;
                [FieldOffset(56)]
                public HIDP_NotRange NotRange;
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            struct HID_DEVICE
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
                public string             DevicePath;
                public IntPtr             HidDevice;
                public bool               OpenedForRead;
                public bool               OpenedForWrite;
                public bool               OpenedOverlapped;
                public bool               OpenedExclusive;

                public IntPtr             Ppd;
                public HIDP_CAPS          Caps;
                public HIDD_ATTRIBUTES    Attributes;

                public IntPtr[]           InputReportBuffer;
                public HID_DATA[]         InputData;
                public Int32              InputDataLength;
                public HIDP_BUTTON_CAPS[] InputButtonCaps;
                public HIDP_VALUE_CAPS[]  InputValueCaps;

                public IntPtr[]           OutputReportBuffer;
                public HID_DATA[]         OutputData;
                public Int32              OutputDataLength;
                public HIDP_BUTTON_CAPS[] OutputButtonCaps;
                public HIDP_VALUE_CAPS[]  OutputValueCaps;

                public IntPtr[]           FeatureReportBuffer;
	            public HID_DATA[]         FeatureData;
                public Int32              FeatureDataLength;
                public HIDP_BUTTON_CAPS[] FeatureButtonCaps;
                public HIDP_VALUE_CAPS[]  FeatureValueCaps;
            }

        #endregion

        byte[] WriteData = new byte[7];
        int  nbrDevice, iDeviceRead, iDeviceSend;
        bool NewRead   = false;
        bool NewSend   = false;
        bool isRead    = false;
        bool isSend    = false;

        public  GUI()
        {
            InitializeComponent();
            Load += new EventHandler(Entry);
        }
        void    Entry(object sender, EventArgs Data)
        {
            Thread ReadThread = new Thread(new ThreadStart(CheckRead));
            ReadThread.IsBackground = true;
            ReadThread.Start();

            Thread SendThread = new Thread(new ThreadStart(CheckSend));
            SendThread.IsBackground = true;
            SendThread.Start();
        }
        void    CheckRead()
        {
            HID_DEVICE[] pDevice = new HID_DEVICE[1];

            while (true)
            {
                Thread.Sleep(1);

                if (nbrDevice != FindNumberDevices() || NewRead)
                {
                    nbrDevice = FindNumberDevices();
                    pDevice   = new HID_DEVICE[nbrDevice];
                    FindKnownHidDevices(ref pDevice);

                    var Index = 0;
                    while (Index < nbrDevice)
                    {
                        var Count = 0;
                        if (pDevice[Index].Attributes.VendorID == DEVICE_VID && DEVICE_VID != 0)
                        {
                            Count++;
                        }
                        if (pDevice[Index].Attributes.ProductID == DEVICE_PID)
                        {
                            Count++;
                        }

                        if (Count == 2)
                        {
                            iDeviceRead = Index;
                            isRead      = true;

                            break;
                        }
                        else
                            isRead = false;

                        Index++;
                    }

                    NewRead = false;
                }

                if (isRead)
                {
                    Read(pDevice[iDeviceRead]);
                }
            }
        }
        void    CheckSend()
        {
            HID_DEVICE[] pDevice = new HID_DEVICE[1];

            while (true)
            {
                Thread.Sleep(1);

                if (nbrDevice != FindNumberDevices() || NewSend)
                {
                    nbrDevice = FindNumberDevices();
                    pDevice   = new HID_DEVICE[nbrDevice];
                    FindKnownHidDevices(ref pDevice);

                    var Index = 0;
                    while (Index < nbrDevice)
                    {
                        var Count = 0;

                        if (pDevice[Index].Attributes.VendorID == DEVICE_VIDa && DEVICE_VIDa != 0)
                        {
                            Count++;
                        }
                        if (pDevice[Index].Attributes.ProductID == DEVICE_PIDa)
                        {
                            Count++;
                        }
                        if (pDevice[Index].Caps.UsagePage == USAGE_PAGE)
                        {
                            Count++;
                        }
                        if (pDevice[Index].Caps.Usage == USAGE)
                        {
                            Count++;
                        }

                        if (Count == 4)
                        {
                            iDeviceSend = Index;
                            isSend      = true;

                            break;
                        }
                        else
                            isSend = false;

                        Index++;
                    }

                    NewSend = false;
                }

                if (isSend)
                {
                    Write(pDevice[iDeviceSend]);
                }
            }
        }

        void    Read(HID_DEVICE HidDevice)  // Read the Report[] and send it to the USB device targeted by HidDevice.HidDevice
        {
            Byte[] Report = new Byte[HidDevice.Caps.InputReportByteLength];
            UInt32 tmp    = 0;

            try
            {
                Report[0] = REPORT_ID;
            } catch{ }

            ReadFile(HidDevice.HidDevice, Report, HidDevice.Caps.InputReportByteLength, ref tmp, IntPtr.Zero);

            try
            {
                textBox_Read.Clear();
            } catch { }

            var Index = 0;
            while (Index < HidDevice.Caps.InputReportByteLength)
            {
                try
                {
                    textBox_Read.Text += Report[Index++].ToString("X2");
                    textBox_Read.Text += " - ";
                } catch { }
            }
        }
        void    Write(HID_DEVICE HidDevice) // Read what the USB device has sent to the PC and store the result into Report[]
        {
            Byte[] Report = new Byte[HidDevice.Caps.OutputReportByteLength];
            UInt32 tmp    = 0;

            try
            {
                Report[0] = REPORT_ID;

                for (UInt32 Index = 0; Index < HidDevice.Caps.OutputReportByteLength; Index++)
                {
                    Report[Index + 1] = WriteData[Index];
                }

            } catch { }

            WriteFile(HidDevice.HidDevice, Report, HidDevice.Caps.OutputReportByteLength, ref tmp, IntPtr.Zero);
        }

        int     FindNumberDevices()
        {
            Guid                     hidGuid        = new Guid();
            SP_DEVICE_INTERFACE_DATA deviceInfoData = new SP_DEVICE_INTERFACE_DATA();
            int index = 0;

            HidD_GetHidGuid(ref hidGuid);

            //
            // Open a handle to the plug and play dev node.
            //
            SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
            hardwareDeviceInfo    = SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
            deviceInfoData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));

            index = 0;
            while (SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, IntPtr.Zero, ref hidGuid, index, ref deviceInfoData))
            {
                index++;
            }

            return (index);
        }
        int     FindKnownHidDevices(ref HID_DEVICE[] HidDevices)
        {
            int                             iHIDD;
            int                             RequiredLength;

            Guid                            hidGuid                 = new Guid();
            SP_DEVICE_INTERFACE_DATA        deviceInfoData          = new SP_DEVICE_INTERFACE_DATA();
            SP_DEVICE_INTERFACE_DETAIL_DATA functionClassDeviceData = new SP_DEVICE_INTERFACE_DETAIL_DATA();

            HidD_GetHidGuid(ref hidGuid);

            //
            // Open a handle to the plug and play dev node.
            //
            SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
            hardwareDeviceInfo    = SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
            deviceInfoData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));

            iHIDD = 0;
            while (SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, IntPtr.Zero, ref hidGuid, iHIDD, ref deviceInfoData))
            {
                RequiredLength = 0;

                //
                // allocate a function class device data structure to receive the
                // goods about this particular device.
                //
                SetupDiGetDeviceInterfaceDetail(hardwareDeviceInfo, ref deviceInfoData, IntPtr.Zero, 0, ref RequiredLength, IntPtr.Zero);

                if (IntPtr.Size == 8)
                    functionClassDeviceData.cbSize = 8;
                else if (IntPtr.Size == 4)
                    functionClassDeviceData.cbSize = 5;

                //
                // Retrieve the information from Plug and Play.
                //
                SetupDiGetDeviceInterfaceDetail(hardwareDeviceInfo, ref deviceInfoData, ref functionClassDeviceData, RequiredLength, ref RequiredLength, IntPtr.Zero);

                //
                // Open device with just generic query abilities to begin with
                //
                OpenHidDevice(functionClassDeviceData.DevicePath, ref HidDevices, iHIDD);

                iHIDD++;
            }

            return iHIDD;
        }
        void    OpenHidDevice(string DevicePath, ref HID_DEVICE[] HidDevice, int iHIDD)
        {
            /*++
            RoutineDescription:
            Given the HardwareDeviceInfo, representing a handle to the plug and
            play information, and deviceInfoData, representing a specific hid device,
            open that device and fill in all the relivant information in the given
            HID_DEVICE structure.
            --*/

            HidDevice[iHIDD].DevicePath = DevicePath;

            //
            //  The hid.dll api's do not pass the overlapped structure into deviceiocontrol
            //  so to use them we must have a non overlapped device.  If the request is for
            //  an overlapped device we will close the device below and get a handle to an
            //  overlapped device
            //
            CloseHandle(HidDevice[iHIDD].HidDevice);
            HidDevice[iHIDD].HidDevice  = CreateFile(HidDevice[iHIDD].DevicePath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, IntPtr.Zero);
            HidDevice[iHIDD].Caps       = new HIDP_CAPS();
            HidDevice[iHIDD].Attributes = new HIDD_ATTRIBUTES();

            //
            // If the device was not opened as overlapped, then fill in the rest of the
            //  HidDevice structure.  However, if opened as overlapped, this handle cannot
            //  be used in the calls to the HidD_ exported functions since each of these
            //  functions does synchronous I/O.
            //
            HidD_FreePreparsedData(ref HidDevice[iHIDD].Ppd);
            HidDevice[iHIDD].Ppd = IntPtr.Zero;
            HidD_GetPreparsedData(HidDevice[iHIDD].HidDevice, ref HidDevice[iHIDD].Ppd);
            HidD_GetAttributes(HidDevice[iHIDD].HidDevice, ref HidDevice[iHIDD].Attributes);
            HidP_GetCaps(HidDevice[iHIDD].Ppd, ref HidDevice[iHIDD].Caps);

            //MessageBox.Show(GetLastError().ToString());

            //
            // At this point the client has a choice.  It may chose to look at the
            // Usage and Page of the top level collection found in the HIDP_CAPS
            // structure.  In this way --------*it could just use the usages it knows about.
            // If either HidP_GetUsages or HidP_GetUsageValue return an error then
            // that particular usage does not exist in the report.
            // This is most likely the preferred method as the application can only
            // use usages of which it already knows.
            // In this case the app need not even call GetButtonCaps or GetValueCaps.
            //
            // In this example, however, we will call FillDeviceInfo to look for all
            //    of the usages in the device.
            //
            //FillDeviceInfo(ref HidDevice);
        }

        private void textBox_VID_Read_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_VID_Read.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            DEVICE_VID = (ushort)number;
        }
        private void textBox_PID_Read_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_PID_Read.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            DEVICE_PID = (ushort)number;
        }
        private void textBox_VIDa_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_VID_Send.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            DEVICE_VIDa = (ushort)number;
        }
        private void textBox_PIDa_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_PID_Send.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            DEVICE_PIDa = (ushort)number;
        }
        private void textBox_UsagePage_Send_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_UsagePage_Send.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            USAGE_PAGE = (ushort)number;
        }
        private void textBox_Usage_Send_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_Usage_Send.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            USAGE = (ushort)number;
        }
        private void textBox_RID_Send_TextChanged(object sender, EventArgs e)
        {
            uint number;

            UInt32.TryParse(textBox_RID_Send.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

            REPORT_ID = (byte)number;
        }

        private void textBox0_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[0] = byte.Parse(textBox0_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }
        private void textBox1_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[1] = byte.Parse(textBox1_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }
        private void textBox2_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[2] = byte.Parse(textBox2_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }
        private void textBox3_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[3] = byte.Parse(textBox3_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }
        private void textBox4_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[4] = byte.Parse(textBox4_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[5] = byte.Parse(textBox5_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }
        private void textBox6_Send_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WriteData[6] = byte.Parse(textBox6_Send.Text, NumberStyles.HexNumber);
            } catch { }
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            NewRead = !NewRead;
        }
        private void button_Send_Click(object sender, EventArgs e)
        {
            NewSend = !NewSend;
        }

        /* void FillDeviceInfo(ref HID_DEVICE[] HidDevice)
        {
            HIDP_BUTTON_CAPS[]  buttonCaps;
            HIDP_VALUE_CAPS[]   valueCaps;
            HID_DATA[]          data;
            int                 Index, numValues;
            ushort              numCaps, usage;

            //
            // setup Input Data buffers.
            //

            //
            // Allocate memory to hold on input report
            //
            HidDevice[iHIDD].InputReportBuffer = new IntPtr[HidDevice[iHIDD].Caps.InputReportByteLength];

            //HidDevice.InputReportBuffer = Marshal.AllocHGlobal();

            //
            // Allocate memory to hold the button and value capabilities.
            // NumberXXCaps is in terms of array elements.
            //
            HidDevice[iHIDD].InputButtonCaps   = buttonCaps = new HIDP_BUTTON_CAPS[HidDevice[iHIDD].Caps.NumberInputButtonCaps];
            HidDevice[iHIDD].InputValueCaps    = valueCaps  = new HIDP_VALUE_CAPS[HidDevice[iHIDD].Caps.NumberInputValueCaps];

            //
            // Have the HidP_X functions fill in the capability structure arrays.
            //
            numCaps = HidDevice[iHIDD].Caps.NumberInputButtonCaps;
            if (numCaps > 0)
            {
                HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Input, buttonCaps, ref numCaps, HidDevice[iHIDD].Ppd);
            }

            numCaps = HidDevice[iHIDD].Caps.NumberInputValueCaps;
            if (numCaps > 0)
            {
                HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Input, valueCaps, ref numCaps, HidDevice[iHIDD].Ppd);
            }

            //
            // Depending on the device, some value caps structures may represent more
            // than one value.  (A range).  In the interest of being verbose, over
            // efficient, we will expand these so that we have one and only one
            // struct _HID_DATA for each value.
            //
            // To do this we need to count up the total number of values are listed
            // in the value caps structure.  For each element in the array we test
            // for range if it is a range then UsageMax and UsageMin describe the
            // usages for this range INCLUSIVE.
            //
            numValues = 0;
            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberInputValueCaps; Index++)
            {
                if (valueCaps[Index].IsRange)
                {
                    numValues += valueCaps[Index].Range.UsageMax - valueCaps[Index].Range.UsageMin + 1;
                }
                else
                {
                    numValues++;
                }

            }

            valueCaps = HidDevice[iHIDD].InputValueCaps;

            //
            // Allocate a buffer to hold the struct _HID_DATA structures.
            // One element for each set of buttons, and one element for each value
            // found.
            //
            HidDevice[iHIDD].InputDataLength = HidDevice[iHIDD].Caps.NumberInputButtonCaps + numValues;
            HidDevice[iHIDD].InputData = data = new HID_DATA[HidDevice[iHIDD].InputDataLength];

            //
            // Fill in the button data
            //
            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberInputButtonCaps; Index++) 
            {
                data[Index].IsButtonData = true;
                data[Index].Status       = HIDP_STATUS_SUCCESS;
                data[Index].UsagePage    = buttonCaps[Index].UsagePage;

                if (buttonCaps[Index].IsRange) 
                {
                    data[Index].ButtonData.UsageMin = buttonCaps[Index].Range.UsageMin;
                    data[Index].ButtonData.UsageMax = buttonCaps[Index].Range.UsageMax;
                }
                else
                {
                    data[Index].ButtonData.UsageMin = data[Index].ButtonData.UsageMax = buttonCaps[Index].NotRange.Usage;
                }
        
                data[Index].ButtonData.MaxUsageLength = HidP_MaxUsageListLength(HIDP_REPORT_TYPE.HidP_Input, buttonCaps[Index].UsagePage, HidDevice[iHIDD].Ppd);
                //data[Index].ButtonData.Usages = new Int32[data[Index].ButtonData.MaxUsageLength];

                data[Index].ReportID = buttonCaps[Index].ReportID;
            }

            //
            // Fill in the value data
            //
            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberInputValueCaps; Index++)
            {
                if (valueCaps[Index].IsRange)
                {
                    // Never reach
                    for (usage = valueCaps[Index].Range.UsageMin; usage <= valueCaps[Index].Range.UsageMax; usage++)
                    {
                        data[Index].IsButtonData = false;
                        data[Index].Status = HIDP_STATUS_SUCCESS;
                        data[Index].UsagePage = valueCaps[Index].UsagePage;
                        data[Index].ValueData.Usage = usage;
                        data[Index].ReportID = valueCaps[Index].ReportID;
                    }
                }
                else
                {
                    data[Index].IsButtonData = false;
                    data[Index].Status = HIDP_STATUS_SUCCESS;
                    data[Index].UsagePage = valueCaps[Index].UsagePage;
                    data[Index].ValueData.Usage = valueCaps[Index].NotRange.Usage;
                    data[Index].ReportID = valueCaps[Index].ReportID;
                }
            }

            //
            // setup Output Data buffers.
            //
            HidDevice[iHIDD].OutputReportBuffer = new IntPtr[HidDevice[iHIDD].Caps.OutputReportByteLength];
            HidDevice[iHIDD].OutputButtonCaps   = buttonCaps = new HIDP_BUTTON_CAPS[HidDevice[iHIDD].Caps.NumberOutputButtonCaps];
            HidDevice[iHIDD].OutputValueCaps    = valueCaps  = new HIDP_VALUE_CAPS[HidDevice[iHIDD].Caps.NumberOutputValueCaps];

            numCaps = HidDevice[iHIDD].Caps.NumberOutputButtonCaps;

            if (numCaps > 0)
            {
                HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Output, buttonCaps, ref numCaps, HidDevice[iHIDD].Ppd);
            }

            numCaps = HidDevice[iHIDD].Caps.NumberOutputValueCaps;

            if (numCaps > 0)
            {
                HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Output, valueCaps, ref numCaps, HidDevice[iHIDD].Ppd);
            }

            numValues = 0;
            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberOutputValueCaps; Index++)
            {
                if (valueCaps[Index].IsRange)
                {
                    numValues += valueCaps[Index].Range.UsageMax - valueCaps[Index].Range.UsageMin + 1;
                }
                else
                {
                    numValues++;
                }
            }

            valueCaps = HidDevice[iHIDD].OutputValueCaps;

            HidDevice[iHIDD].OutputDataLength = HidDevice[iHIDD].Caps.NumberOutputButtonCaps + numValues;
            HidDevice[iHIDD].OutputData = data = new HID_DATA[HidDevice[iHIDD].OutputDataLength];

            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberOutputButtonCaps; Index++)
            {
                data[Index].IsButtonData = true;
                data[Index].Status = HIDP_STATUS_SUCCESS;
                data[Index].UsagePage = buttonCaps[Index].UsagePage;

                if (buttonCaps[Index].IsRange)
                {
                    data[Index].ButtonData.UsageMin = buttonCaps[Index].Range.UsageMin;
                    data[Index].ButtonData.UsageMax = buttonCaps[Index].Range.UsageMax;
                }
                else
                {
                    data[Index].ButtonData.UsageMin = data[Index].ButtonData.UsageMax = buttonCaps[Index].NotRange.Usage;
                }

                data[Index].ButtonData.MaxUsageLength = HidP_MaxUsageListLength(HIDP_REPORT_TYPE.HidP_Output, buttonCaps[Index].UsagePage, HidDevice[iHIDD].Ppd);
                //data[Index].ButtonData.Usages = new short[data[Index].ButtonData.MaxUsageLength];
                data[Index].ReportID = buttonCaps[Index].ReportID;
            }

            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberOutputValueCaps; Index++)
            {
                if (valueCaps[Index].IsRange)
                {
                    // Never reach
                    for (usage = valueCaps[Index].Range.UsageMin; usage <= valueCaps[Index].Range.UsageMax; usage++)
                    {
                        data[Index].IsButtonData = false;
                        data[Index].Status = HIDP_STATUS_SUCCESS;
                        data[Index].UsagePage = valueCaps[Index].UsagePage;
                        data[Index].ValueData.Usage = usage;
                        data[Index].ReportID = valueCaps[Index].ReportID;
                    }
                }
                else
                {
                    data[Index].IsButtonData = false;
                    data[Index].Status = HIDP_STATUS_SUCCESS;
                    data[Index].UsagePage = valueCaps[Index].UsagePage;
                    data[Index].ValueData.Usage = valueCaps[Index].NotRange.Usage;
                    data[Index].ReportID = valueCaps[Index].ReportID;
                }
            }

            //
            // setup Feature Data buffers.
            //
            HidDevice[iHIDD].FeatureReportBuffer              = new IntPtr[HidDevice[iHIDD].Caps.FeatureReportByteLength];
            HidDevice[iHIDD].FeatureButtonCaps   = buttonCaps = new HIDP_BUTTON_CAPS[HidDevice[iHIDD].Caps.NumberFeatureButtonCaps];
            HidDevice[iHIDD].FeatureValueCaps    = valueCaps  = new HIDP_VALUE_CAPS[HidDevice[iHIDD].Caps.NumberFeatureValueCaps];

            numCaps = HidDevice[iHIDD].Caps.NumberFeatureButtonCaps;

            if (numCaps > 0)
            {
                HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Feature, buttonCaps, ref numCaps, HidDevice[iHIDD].Ppd);
            }

            numCaps = HidDevice[iHIDD].Caps.NumberFeatureValueCaps;

            if (numCaps > 0)
            {
                HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Feature, valueCaps, ref numCaps, HidDevice[iHIDD].Ppd);
            }


            numValues = 0;
            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberFeatureValueCaps; Index++)
            {
                if (valueCaps[Index].IsRange)
                {
                    numValues += valueCaps[Index].Range.UsageMax - valueCaps[Index].Range.UsageMin + 1;
                }
                else
                {
                    numValues++;
                }
            }

            valueCaps = HidDevice[iHIDD].FeatureValueCaps;

            HidDevice[iHIDD].FeatureDataLength = HidDevice[iHIDD].Caps.NumberFeatureButtonCaps + numValues;
            HidDevice[iHIDD].FeatureData = data = new HID_DATA[HidDevice[iHIDD].FeatureDataLength];

            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberFeatureButtonCaps; Index++)
            {
                data[Index].IsButtonData = true;
                data[Index].Status = HIDP_STATUS_SUCCESS;
                data[Index].UsagePage = buttonCaps[Index].UsagePage;

                if (buttonCaps[Index].IsRange)
                {
                    data[Index].ButtonData.UsageMin = buttonCaps[Index].Range.UsageMin;
                    data[Index].ButtonData.UsageMax = buttonCaps[Index].Range.UsageMax;
                }
                else
                {
                    data[Index].ButtonData.UsageMin = data[Index].ButtonData.UsageMax = buttonCaps[Index].NotRange.Usage;
                }

                data[Index].ButtonData.MaxUsageLength = HidP_MaxUsageListLength(HIDP_REPORT_TYPE.HidP_Feature, buttonCaps[Index].UsagePage, HidDevice[iHIDD].Ppd);
                //data[Index].ButtonData.Usages = new short[data[Index].ButtonData.MaxUsageLength];

                data[Index].ReportID = buttonCaps[Index].ReportID;
            }

            for (Index = 0; Index < HidDevice[iHIDD].Caps.NumberFeatureValueCaps; Index++)
            {
                if (valueCaps[Index].IsRange)
                {
                    // Never reach
                    for (usage = valueCaps[Index].Range.UsageMin; usage <= valueCaps[Index].Range.UsageMax; usage++)
                    {
                        data[Index].IsButtonData = false;
                        data[Index].Status = HIDP_STATUS_SUCCESS;
                        data[Index].UsagePage = valueCaps[Index].UsagePage;
                        data[Index].ValueData.Usage = usage;
                        data[Index].ReportID = valueCaps[Index].ReportID;
                    }
                }
                else
                {
                    data[Index].IsButtonData = false;
                    data[Index].Status = HIDP_STATUS_SUCCESS;
                    data[Index].UsagePage = valueCaps[Index].UsagePage;
                    data[Index].ValueData.Usage = valueCaps[Index].NotRange.Usage;
                    data[Index].ReportID = valueCaps[Index].ReportID;
                }
            }
        }
        */

        /* void PackReport(IntPtr ReportBuffer, ushort ReportBufferLength, HIDP_REPORT_TYPE ReportType, HID_DATA[] Data, Int32 DataLength, IntPtr Ppd)
        {
            // /*++
            // Routine Description:
            //    This routine takes in a list of HID_DATA structures (DATA) and builds 
            //       in ReportBuffer the given report for all data values in the list that 
            //       correspond to the report ID of the first item in the list.  
            // 
            //    For every data structure in the list that has the same report ID as the first
            //       item in the list will be set in the report.  Every data item that is 
            //       set will also have it's IsDataSet field marked with TRUE.
            // 
            //    A return value of FALSE indicates an unexpected error occurred when setting
            //       a given data value.  The caller should expect that assume that no values
            //       within the given data structure were set.
            // 
            //    A return value of TRUE indicates that all data values for the given report
            //       ID were set without error.
            // --

            Int32   numUsages; // Number of usages to set for a given report.
            Int32   Index;
            Int32   CurrReportID;

            //
            // Go through the data structures and set all the values that correspond to
            //   the CurrReportID which is obtained from the first data structure 
            //   in the list
            //
            CurrReportID = Data[0].ReportID;

            for (Index = 0; Index < DataLength; Index++) 
            {
                //
                // There are two different ways to determine if we set the current data
                //    structure: 
                //    1) Store the report ID were using and only attempt to set those
                //        data structures that correspond to the given report ID.  This
                //        example shows this implementation.
                //
                //    2) Attempt to set all of the data structures and look for the 
                //        returned status value of HIDP_STATUS_INVALID_REPORT_ID.  This 
                //        error code indicates that the given usage exists but has a 
                //        different report ID than the report ID in the current report 
                //        buffer
                //
                if (Data[Index].ReportID == CurrReportID) 
                {
                    if (Data[Index].IsButtonData) 
                    {
                        numUsages = Data[Index].ButtonData.MaxUsageLength;
                        Data[Index].Status = HidP_SetUsages(ReportType,
                                                       Data[Index].UsagePage,
                                                       0,
                                                       Data[Index].ButtonData.Usages,
                                                       ref numUsages,
                                                       Ppd,
                                                       ReportBuffer,
                                                       ReportBufferLength);
                    }
                    else
                    {
                        Data[Index].Status = HidP_SetUsageValue(ReportType,
                                                           Data[Index].UsagePage,
                                                           0,
                                                           Data[Index].ValueData.Usage,
                                                           Data[Index].ValueData.Value,
                                                           Ppd,
                                                           ReportBuffer,
                                                           ReportBufferLength);
                    }
                }
            }

            //
            // At this point, all data structures that have the same ReportID as the
            //    first one will have been set in the given report.  Time to loop 
            //    through the structure again and mark all of those data structures as
            //    having been set.
            //
            for (Index = 0; Index < DataLength; Index++) 
            {
                if (CurrReportID == Data[Index].ReportID)
                {
                    Data[Index].IsDataSet = true;
                }
            }
        }*/
    }
}