# HIDImports.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Nmea/Notes/HIDImports.cs

## Class - HIDImports

### Comments

 <summary>
 Win32 import information for use with the Wiimote library
 </summary>

### Members

#### Public Field - DIGCF_DEFAULT

##### Summary

 * Type: 

#### Public Field - DIGCF_PRESENT

##### Summary

 * Type: 

#### Public Field - DIGCF_ALLCLASSES

##### Summary

 * Type: 

#### Public Field - DIGCF_PROFILE

##### Summary

 * Type: 

#### Public Field - DIGCF_DEVICEINTERFACE

##### Summary

 * Type: 

#### Public Field - cbSize

##### Summary

 * Type: 

#### Public Field - ClassGuid

##### Summary

 * Type: Guid 

#### Public Field - DevInst

##### Summary

 * Type: 

#### Public Field - Reserved

##### Summary

 * Type: IntPtr 

#### Public Field - cbSize

##### Summary

 * Type: 

#### Public Field - InterfaceClassGuid

##### Summary

 * Type: Guid 

#### Public Field - Flags

##### Summary

 * Type: 

#### Public Field - RESERVED

##### Summary

 * Type: IntPtr 

#### Public Field - cbSize

##### Summary

 * Type: UInt32 

#### Public Field - DevicePath

##### Attributes

 - MarshalAs
 - (
 - UnmanagedType
 - .
 - ByValTStr
 - ,
 - SizeConst
 - =
 - 256
 - )

##### Summary

 * Type: 

#### Public Field - Size

##### Summary

 * Type: 

#### Public Field - VendorID

##### Summary

 * Type: 

#### Public Field - ProductID

##### Summary

 * Type: 

#### Public Field - VersionNumber

##### Summary

 * Type: 

#### Public Static Method - HidD_GetHidGuid

##### Attributes

 - DllImport
 - (
 - @"hid.dll"
 - ,
 - CharSet
 - =
 - CharSet
 - .
 - Auto
 - ,
 - SetLastError
 - =
 - true
 - )

#####  Parameters

 - out Guid gHid 

#### Public Static Method - HidD_GetAttributes

##### Attributes

 - DllImport
 - (
 - "hid.dll"
 - )

#####  Parameters

 - IntPtr HidDeviceObject 
 - ref HIDD_ATTRIBUTES Attributes 

#### Internal Static Method - HidD_SetOutputReport

##### Attributes

 - DllImport
 - (
 - "hid.dll"
 - )

#####  Parameters

 - IntPtr HidDeviceObject 
 - byte [  ] lpReportBuffer 
 - uint ReportBufferLength 

#### Public Static Method - SetupDiGetClassDevs

##### Attributes

 - DllImport
 - (
 - @"setupapi.dll"
 - ,
 - CharSet
 - =
 - CharSet
 - .
 - Auto
 - ,
 - SetLastError
 - =
 - true
 - )

#####  Parameters

 - ref Guid ClassGuid 
 - [ MarshalAs ( UnmanagedType . LPTStr ) ] string Enumerator 
 - IntPtr hwndParent 
 - UInt32 Flags 

#### Public Static Method - SetupDiEnumDeviceInterfaces

##### Attributes

 - DllImport
 - (
 - @"setupapi.dll"
 - ,
 - CharSet
 - =
 - CharSet
 - .
 - Auto
 - ,
 - SetLastError
 - =
 - true
 - )

#####  Parameters

 - IntPtr hDevInfo 
 - IntPtr devInvo 
 - ref Guid interfaceClassGuid 
 - Int32 memberIndex 
 - ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData 

#### Public Static Method - SetupDiGetDeviceInterfaceDetail

##### Attributes

 - DllImport
 - (
 - @"setupapi.dll"
 - ,
 - SetLastError
 - =
 - true
 - )

#####  Parameters

 - IntPtr hDevInfo 
 - ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData 
 - IntPtr deviceInterfaceDetailData 
 - UInt32 deviceInterfaceDetailDataSize 
 - out UInt32 requiredSize 
 - IntPtr deviceInfoData 

#### Public Static Method - SetupDiGetDeviceInterfaceDetail

##### Attributes

 - DllImport
 - (
 - @"setupapi.dll"
 - ,
 - SetLastError
 - =
 - true
 - )

#####  Parameters

 - IntPtr hDevInfo 
 - ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData 
 - ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData 
 - UInt32 deviceInterfaceDetailDataSize 
 - out UInt32 requiredSize 
 - IntPtr deviceInfoData 

#### Public Static Method - SetupDiDestroyDeviceInfoList

##### Attributes

 - DllImport
 - (
 - @"setupapi.dll"
 - ,
 - CharSet
 - =
 - CharSet
 - .
 - Auto
 - ,
 - SetLastError
 - =
 - true
 - )

#####  Parameters

 - IntPtr hDevInfo 

#### Public Static Method - CreateFile

##### Attributes

 - DllImport
 - (
 - "Kernel32.dll"
 - ,
 - SetLastError
 - =
 - true
 - ,
 - CharSet
 - =
 - CharSet
 - .
 - Auto
 - )

#####  Parameters

 - string fileName 
 - [ MarshalAs ( UnmanagedType . U4 ) ] FileAccess fileAccess 
 - [ MarshalAs ( UnmanagedType . U4 ) ] FileShare fileShare 
 - IntPtr securityAttributes 
 - [ MarshalAs ( UnmanagedType . U4 ) ] FileMode creationDisposition 
 - [ MarshalAs ( UnmanagedType . U4 ) ] EFileAttributes flags 
 - IntPtr template 

#### Public Static Method - CloseHandle

##### Attributes

 - DllImport
 - (
 - "kernel32.dll"
 - ,
 - SetLastError
 - =
 - true
 - )
 - MarshalAs
 - (
 - UnmanagedType
 - .
 - Bool
 - )

#####  Parameters

 - IntPtr hObject 

## Public Enumeration - EFileAttributes

### Attributes

 - Flags

## Public Structure - SP_DEVINFO_DATA

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Sequential
 - )

### Members

#### Public Field - cbSize

##### Summary

 * Type: 

#### Public Field - ClassGuid

##### Summary

 * Type: Guid 

#### Public Field - DevInst

##### Summary

 * Type: 

#### Public Field - Reserved

##### Summary

 * Type: IntPtr 

## Public Structure - SP_DEVICE_INTERFACE_DATA

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Sequential
 - )

### Members

#### Public Field - cbSize

##### Summary

 * Type: 

#### Public Field - InterfaceClassGuid

##### Summary

 * Type: Guid 

#### Public Field - Flags

##### Summary

 * Type: 

#### Public Field - RESERVED

##### Summary

 * Type: IntPtr 

## Public Structure - SP_DEVICE_INTERFACE_DETAIL_DATA

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Sequential
 - ,
 - Pack
 - =
 - 1
 - )

### Members

#### Public Field - cbSize

##### Summary

 * Type: UInt32 

#### Public Field - DevicePath

##### Attributes

 - MarshalAs
 - (
 - UnmanagedType
 - .
 - ByValTStr
 - ,
 - SizeConst
 - =
 - 256
 - )

##### Summary

 * Type: 

## Public Structure - HIDD_ATTRIBUTES

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Sequential
 - )

### Members

#### Public Field - Size

##### Summary

 * Type: 

#### Public Field - VendorID

##### Summary

 * Type: 

#### Public Field - ProductID

##### Summary

 * Type: 

#### Public Field - VersionNumber

##### Summary

 * Type: 

