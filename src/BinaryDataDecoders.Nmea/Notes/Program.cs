using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;
using Test1.ROOT.CIMV2;

namespace Test1
{
    class Program
    {
        private static Guid _gpsGuid = new Guid("745a17a0-74d3-11d0-b6fe-00a0c90f57da");
        private static SafeFileHandle mHandle;
        private static FileStream mStream;

        private const short VID = 0x1163;
        private const short PID = 0x0200;
        private const int REPORT_LENGTH = 1024;

        static void Main(string[] args)
        {
            Guid _hidGuid;
            HIDImports.HidD_GetHidGuid(out _hidGuid);

            IntPtr _hidDevPtr = HIDImports.SetupDiGetClassDevs(ref _hidGuid, null, IntPtr.Zero, HIDImports.DIGCF_PRESENT | HIDImports.DIGCF_DEVICEINTERFACE);

            HIDImports.SP_DEVICE_INTERFACE_DATA diData = new HIDImports.SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = Marshal.SizeOf(diData);

            int index=0;

            while (HIDImports.SetupDiEnumDeviceInterfaces(_hidDevPtr, IntPtr.Zero, ref _hidGuid, index, ref diData))
            {
                HIDImports.SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new HIDImports.SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5; //should be: (uint)Marshal.SizeOf(diDetail);, but that's the wrong size
                UInt32 size = 0;

                bool _result1 = HIDImports.SetupDiGetDeviceInterfaceDetail(_hidDevPtr, ref diData, IntPtr.Zero, 0, out size, IntPtr.Zero);

                if (HIDImports.SetupDiGetDeviceInterfaceDetail(_hidDevPtr, ref diData, ref diDetail, size, out size, IntPtr.Zero))
                {
                    mHandle = HIDImports.CreateFile(diDetail.DevicePath, FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, HIDImports.EFileAttributes.Overlapped, IntPtr.Zero);       
                    // 4. create an attributes struct and initialize the size        
                    HIDImports.HIDD_ATTRIBUTES attrib = new HIDImports.HIDD_ATTRIBUTES();        
                    attrib.Size = Marshal.SizeOf(attrib);        
                    // get the attributes of the current device        
                    if(HIDImports.HidD_GetAttributes(mHandle.DangerousGetHandle(), ref attrib))        
                    {            
                        // if the vendor and product IDs match up            
                        if(attrib.VendorID == VID && attrib.ProductID == PID)            
                        {                
                            // 5. create a nice .NET FileStream wrapping the handle above               
                            mStream = new FileStream(mHandle, FileAccess.ReadWrite, REPORT_LENGTH, true);          
                        }            
                        else               
                            mHandle.Close();     
                    }    
                }    
                // move to the next device    
                index++;
            }
            // 6. clean up our list
            HIDImports.SetupDiDestroyDeviceInfoList(_hidDevPtr);

            //========================================================================================

            List<byte> _buffer = new List<byte>();
            int _valueBuffer = 0;
            while (_valueBuffer != -1)
            {
                _valueBuffer = mStream.ReadByte();

                if (_valueBuffer == 36) //$
                {
                    string _fullMessage = ASCIIEncoding.ASCII.GetString(_buffer.ToArray());
                    if (_fullMessage.StartsWith("$GPRMC"))
                    {
                        //Console.WriteLine(_fullMessage);
                        try
                        {
                            Console.Write(new Gprmc(_fullMessage).ToString());
                        }
                        catch (ArgumentNullException anEx)
                        {
                            Debug.WriteLine("ArgumentNullException: " + anEx.Message);
                        }
                        catch (ArgumentOutOfRangeException aorEx)
                        {
                            Debug.WriteLine("ArgumentOutOfRangeException: " + aorEx.Message);
                        }
                        catch (ArgumentException aEx)
                        {
                            Debug.WriteLine("ArgumentException: " + aEx.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ERROR: " + ex.Message);
                            Debug.WriteLine("Exception: " + ex.Message);
                        }
                    }
                    _buffer.Clear();
                }

                _buffer.Add((byte)_valueBuffer);

            }
        }
    }
}
