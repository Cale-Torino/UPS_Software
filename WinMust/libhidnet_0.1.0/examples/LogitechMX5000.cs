using System;
using Hid;

class LogitechMX5000
{
    public static int Main(string[] args)
    {
        // Find exactly one device.
        IDevice[] mx5000s = DeviceFactory.Enumerate(0x046d, 0xc70a);

        /* Note that MX5000 keyboards connected by bluetooth or HCI have
         * the product ID 0xb305. RF mode uses 0xc70a.
         */

        if (mx5000s.Length < 1)
        {
            Console.Error.WriteLine("No MX5000s found.");
            Console.ReadKey(false);
            return 1;
        }

        if (mx5000s.Length > 1)
            Console.Error.WriteLine(
                "Warning: {0} MX5000s found. Will only use first device.",
                mx5000s.Length);

        IDevice device = mx5000s[0];

        /*
         * For now, you SHOULD specifically assign report IDs to any Windows
         * devices that you want to use. If you don't, it may be guessed
         * incorrectly.
         * 
         * An aim of the project is to stop this from being necessary on any
         * platform.
         * 
         * This is not necessary on Linux.
         */
        /*if (device is Hid.Win32.Win32DeviceSet)
        {
            Hid.Win32.Win32DeviceSet deviceSet = (Hid.Win32.Win32DeviceSet)device;

            // Get a copy of the list to loop though while changes are made.
            System.Collections.Generic.List<Hid.Win32.Win32Device> deviceList =
                new System.Collections.Generic.List<Hid.Win32.Win32Device>(deviceSet.UnallocatedDevices);

            foreach (Hid.Win32.Win32Device winDevice in deviceList)
            {
                switch (winDevice.OutputLength)
                {
                    case 7:
                        deviceSet.AddDevice(0x10, winDevice);
                        break;

                    case 20:
                        deviceSet.AddDevice(0x11, winDevice);
                        break;

                    case 46:
                        deviceSet.AddDevice(0x12, winDevice);
                        break;

                    default:
                        winDevice.Dispose();
                        break;
                }
            }
        }*/
        
        // Do some I/O with the MX5000 keyboard.
        byte[] request;
        byte[] response;

        // Send a beep
        request = new byte[] { 0x01, 0x80, 0x50, 0x02, 0x00, 0x00 };
        response = device.WriteRead(0x10, request);

        Console.WriteLine("Request OPCODE = Response OPCODE: {0}",
            request[2] == response[2]);

        foreach (byte b in response)
            Console.Write("0x{0:x2} ", b);
        Console.WriteLine();

        // Read the battery
        request = new byte[] { 0x01, 0x81, 0x07, 0x00, 0x00, 0x00 };
        response = device.WriteRead(0x10, request);

        Console.WriteLine("Request OPCODE = Response OPCODE: {0}",
            request[2] == response[2]);

        foreach (byte b in response)
            Console.Write("0x{0:x2} ", b);
        Console.WriteLine();

        if (response[3] == 0x07)
            Console.WriteLine("Battery High");
        else if (response[3] == 0x01)
            Console.WriteLine("Battery Low");
        else
            Console.Error.WriteLine("Unknown battery status 0x{0:x2}",
                response[3]);


        return 0;
    }
}
