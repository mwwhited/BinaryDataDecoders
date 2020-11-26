# ROOT.CIMV2.Win32_USBController.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Nmea/Notes/ROOT.CIMV2.Win32_USBController.cs

## Public Class - USBController

### Members

#### Private Static Field - CreatedWmiNamespace

##### Summary

 * Type: 

#### Private Static Field - CreatedClassName

##### Summary

 * Type: 

#### Private Static Field - statMgmtScope

##### Summary

 * Type: 

#### Private Field - PrivateSystemProperties

##### Summary

 * Type: ManagementSystemProperties 

#### Private Field - PrivateLateBoundObject

##### Summary

 * Type: 

#### Private Field - AutoCommitProp

##### Summary

 * Type: 

#### Private Field - embeddedObj

##### Summary

 * Type: 

#### Private Field - curObj

##### Summary

 * Type: 

#### Private Field - isEmbedded

##### Summary

 * Type: 

#### Public Constructor - USBController


#### Public Constructor - USBController

#####  Parameters

 - string keyDeviceID 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - string keyDeviceID 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions getOptions 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementPath path 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions getOptions 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementObject theObject 

#### Public Constructor - USBController

#####  Parameters

 - System . Management . ManagementBaseObject theObject 

#### Public Property - OriginatingNamespace

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] string 

#### Public Property - ManagementClassName

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] string 

#### Public Property - SystemProperties

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] ManagementSystemProperties 

#### Public Property - LateBoundObject

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] System . Management . ManagementBaseObject 

#### Public Property - Scope

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] System . Management . ManagementScope 

#### Public Property - AutoCommit

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - Path

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] System . Management . ManagementPath 

#### Public Static Property - StaticScope

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] System . Management . ManagementScope 

#### Public Property - IsAvailabilityNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - Availability

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - @"The availability and status of the device.  For example, the Availability property indicates that the device is running and has full power (value=3), or is in a warning (4), test (5), degraded (10) or power save state (values 13-15 and 17). Regarding the power saving states, these are defined as follows: Value 13 (""Power Save - Unknown"") indicates that the device is known to be in a power save mode, but its exact status in this mode is unknown; 14 (""Power Save - Low Power Mode"") indicates that the device is in a power save state but still functioning, and may exhibit degraded performance; 15 (""Power Save - Standby"") describes that the device is not functioning but could be brought to full power 'quickly'; and value 17 (""Power Save - Warning"") indicates that the device is in a warning state, though also in a power save mode."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The availability and status of the device.  For example, the Availability property indicates that the device is running and has full power (value=3), or is in a warning (4), test (5), degraded (10) or power save state (values 13-15 and 17). Regarding the power saving states, these are defined as follows: Value 13 (""Power Save - Unknown"") indicates that the device is known to be in a power save mode, but its exact status in this mode is unknown; 14 (""Power Save - Low Power Mode"") indicates that the device is in a power save state but still functioning, and may exhibit degraded performance; 15 (""Power Save - Standby"") describes that the device is not functioning but could be brought to full power 'quickly'; and value 17 (""Power Save - Warning"") indicates that the device is in a warning state, though also in a power save mode." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] AvailabilityValues 

#### Public Property - Caption

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The Caption property is a short textual description (one-line string) of the obje"
 - +
 - "ct."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Caption property is a short textual description (one-line string) of the obje" + "ct." ) ] string 

#### Public Property - IsConfigManagerErrorCodeNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - ConfigManagerErrorCode

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "Indicates the Win32 Configuration Manager error code.  The following values may b"
 - +
 - "e returned: \n0\tThis device is working properly. \n1\tThis device is not configured"
 - +
 - " correctly. \n2\tWindows cannot load the driver for this device. \n3\tThe driver for"
 - +
 - " this device might be corrupted, or your system may be running low on memory or "
 - +
 - "other resources. \n4\tThis device is not working properly. One of its drivers or y"
 - +
 - "our registry might be corrupted. \n5\tThe driver for this device needs a resource "
 - +
 - "that Windows cannot manage. \n6\tThe boot configuration for this device conflicts "
 - +
 - "with other devices. \n7\tCannot filter. \n8\tThe driver loader for the device is mis"
 - +
 - "sing. \n9\tThis device is not working properly because the controlling firmware is"
 - +
 - " reporting the resources for the device incorrectly. \n10\tThis device cannot star"
 - +
 - "t. \n11\tThis device failed. \n12\tThis device cannot find enough free resources tha"
 - +
 - "t it can use. \n13\tWindows cannot verify this device\'s resources. \n14\tThis device"
 - +
 - " cannot work properly until you restart your computer. \n15\tThis device is not wo"
 - +
 - "rking properly because there is probably a re-enumeration problem. \n16\tWindows c"
 - +
 - "annot identify all the resources this device uses. \n17\tThis device is asking for"
 - +
 - " an unknown resource type. \n18\tReinstall the drivers for this device. \n19\tYour r"
 - +
 - "egistry might be corrupted. \n20\tFailure using the VxD loader. \n21\tSystem failure"
 - +
 - ": Try changing the driver for this device. If that does not work, see your hardw"
 - +
 - "are documentation. Windows is removing this device. \n22\tThis device is disabled."
 - +
 - " \n23\tSystem failure: Try changing the driver for this device. If that doesn\'t wo"
 - +
 - "rk, see your hardware documentation. \n24\tThis device is not present, is not work"
 - +
 - "ing properly, or does not have all its drivers installed. \n25\tWindows is still s"
 - +
 - "etting up this device. \n26\tWindows is still setting up this device. \n27\tThis dev"
 - +
 - "ice does not have valid log configuration. \n28\tThe drivers for this device are n"
 - +
 - "ot installed. \n29\tThis device is disabled because the firmware of the device did"
 - +
 - " not give it the required resources. \n30\tThis device is using an Interrupt Reque"
 - +
 - "st (IRQ) resource that another device is using. \n31\tThis device is not working p"
 - +
 - "roperly because Windows cannot load the drivers required for this device."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "Indicates the Win32 Configuration Manager error code.  The following values may b" + "e returned: \n0\tThis device is working properly. \n1\tThis device is not configured" + " correctly. \n2\tWindows cannot load the driver for this device. \n3\tThe driver for" + " this device might be corrupted, or your system may be running low on memory or " + "other resources. \n4\tThis device is not working properly. One of its drivers or y" + "our registry might be corrupted. \n5\tThe driver for this device needs a resource " + "that Windows cannot manage. \n6\tThe boot configuration for this device conflicts " + "with other devices. \n7\tCannot filter. \n8\tThe driver loader for the device is mis" + "sing. \n9\tThis device is not working properly because the controlling firmware is" + " reporting the resources for the device incorrectly. \n10\tThis device cannot star" + "t. \n11\tThis device failed. \n12\tThis device cannot find enough free resources tha" + "t it can use. \n13\tWindows cannot verify this device\'s resources. \n14\tThis device" + " cannot work properly until you restart your computer. \n15\tThis device is not wo" + "rking properly because there is probably a re-enumeration problem. \n16\tWindows c" + "annot identify all the resources this device uses. \n17\tThis device is asking for" + " an unknown resource type. \n18\tReinstall the drivers for this device. \n19\tYour r" + "egistry might be corrupted. \n20\tFailure using the VxD loader. \n21\tSystem failure" + ": Try changing the driver for this device. If that does not work, see your hardw" + "are documentation. Windows is removing this device. \n22\tThis device is disabled." + " \n23\tSystem failure: Try changing the driver for this device. If that doesn\'t wo" + "rk, see your hardware documentation. \n24\tThis device is not present, is not work" + "ing properly, or does not have all its drivers installed. \n25\tWindows is still s" + "etting up this device. \n26\tWindows is still setting up this device. \n27\tThis dev" + "ice does not have valid log configuration. \n28\tThe drivers for this device are n" + "ot installed. \n29\tThis device is disabled because the firmware of the device did" + " not give it the required resources. \n30\tThis device is using an Interrupt Reque" + "st (IRQ) resource that another device is using. \n31\tThis device is not working p" + "roperly because Windows cannot load the drivers required for this device." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ConfigManagerErrorCodeValues 

#### Public Property - IsConfigManagerUserConfigNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - ConfigManagerUserConfig

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "Indicates whether the device is using a user-defined configuration."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "Indicates whether the device is using a user-defined configuration." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - CreationClassName

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "CreationClassName indicates the name of the class or the subclass used in the cre"
 - +
 - "ation of an instance. When used with the other key properties of this class, thi"
 - +
 - "s property allows all instances of this class and its subclasses to be uniquely "
 - +
 - "identified."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "CreationClassName indicates the name of the class or the subclass used in the cre" + "ation of an instance. When used with the other key properties of this class, thi" + "s property allows all instances of this class and its subclasses to be uniquely " + "identified." ) ] string 

#### Public Property - Description

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The Description property provides a textual description of the object. "
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Description property provides a textual description of the object. " ) ] string 

#### Public Property - DeviceID

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The DeviceID property contains a string uniquely identifying the USB controller f"
 - +
 - "rom other devices on the system."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The DeviceID property contains a string uniquely identifying the USB controller f" + "rom other devices on the system." ) ] string 

#### Public Property - IsErrorClearedNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - ErrorCleared

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "ErrorCleared is a boolean property indicating that the error reported in LastErro"
 - +
 - "rCode property is now cleared."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "ErrorCleared is a boolean property indicating that the error reported in LastErro" + "rCode property is now cleared." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - ErrorDescription

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "ErrorDescription is a free-form string supplying more information about the error"
 - +
 - " recorded in LastErrorCode property, and information on any corrective actions t"
 - +
 - "hat may be taken."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "ErrorDescription is a free-form string supplying more information about the error" + " recorded in LastErrorCode property, and information on any corrective actions t" + "hat may be taken." ) ] string 

#### Public Property - IsInstallDateNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - InstallDate

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The InstallDate property is datetime value indicating when the object was install"
 - +
 - "ed. A lack of a value does not indicate that the object is not installed."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The InstallDate property is datetime value indicating when the object was install" + "ed. A lack of a value does not indicate that the object is not installed." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] System . DateTime 

#### Public Property - IsLastErrorCodeNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - LastErrorCode

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "LastErrorCode captures the last error code reported by the logical device."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "LastErrorCode captures the last error code reported by the logical device." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] uint 

#### Public Property - Manufacturer

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The Manufacturer property indicates the name of the USB controller  manufacturer."
 - +
 - "\nExample: Acme"
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Manufacturer property indicates the name of the USB controller  manufacturer." + "\nExample: Acme" ) ] string 

#### Public Property - IsMaxNumberControlledNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - MaxNumberControlled

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "Maximum number of directly addressable entities supported by this Controller.  A "
 - +
 - "value of 0 should be used if the number is unknown or unlimited."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "Maximum number of directly addressable entities supported by this Controller.  A " + "value of 0 should be used if the number is unknown or unlimited." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] uint 

#### Public Property - Name

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The Name property defines the label by which the object is known. When subclassed"
 - +
 - ", the Name property can be overridden to be a Key property."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Name property defines the label by which the object is known. When subclassed" + ", the Name property can be overridden to be a Key property." ) ] string 

#### Public Property - PNPDeviceID

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "Indicates the Win32 Plug and Play device ID of the logical device.  Example: *PNP"
 - +
 - "030b"
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "Indicates the Win32 Plug and Play device ID of the logical device.  Example: *PNP" + "030b" ) ] string 

#### Public Property - PowerManagementCapabilities

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - @"Indicates the specific power-related capabilities of the logical device. The array values, 0=""Unknown"", 1=""Not Supported"" and 2=""Disabled"" are self-explanatory. The value, 3=""Enabled"" indicates that the power management features are currently enabled but the exact feature set is unknown or the information is unavailable. ""Power Saving Modes Entered Automatically"" (4) describes that a device can change its power state based on usage or other criteria. ""Power State Settable"" (5) indicates that the SetPowerState method is supported. ""Power Cycling Supported"" (6) indicates that the SetPowerState method can be invoked with the PowerState input variable set to 5 (""Power Cycle""). ""Timed Power On Supported"" (7) indicates that the SetPowerState method can be invoked with the PowerState input variable set to 5 (""Power Cycle"") and the Time parameter set to a specific date and time, or interval, for power-on."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"Indicates the specific power-related capabilities of the logical device. The array values, 0=""Unknown"", 1=""Not Supported"" and 2=""Disabled"" are self-explanatory. The value, 3=""Enabled"" indicates that the power management features are currently enabled but the exact feature set is unknown or the information is unavailable. ""Power Saving Modes Entered Automatically"" (4) describes that a device can change its power state based on usage or other criteria. ""Power State Settable"" (5) indicates that the SetPowerState method is supported. ""Power Cycling Supported"" (6) indicates that the SetPowerState method can be invoked with the PowerState input variable set to 5 (""Power Cycle""). ""Timed Power On Supported"" (7) indicates that the SetPowerState method can be invoked with the PowerState input variable set to 5 (""Power Cycle"") and the Time parameter set to a specific date and time, or interval, for power-on." ) ] PowerManagementCapabilitiesValues [  ] 

#### Public Property - IsPowerManagementSupportedNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - PowerManagementSupported

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - @"Boolean indicating that the Device can be power managed - ie, put into a power save state. This boolean does not indicate that power management features are currently enabled, or if enabled, what features are supported. Refer to the PowerManagementCapabilities array for this information. If this boolean is false, the integer value 1, for the string, ""Not Supported"", should be the only entry in the PowerManagementCapabilities array."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"Boolean indicating that the Device can be power managed - ie, put into a power save state. This boolean does not indicate that power management features are currently enabled, or if enabled, what features are supported. Refer to the PowerManagementCapabilities array for this information. If this boolean is false, the integer value 1, for the string, ""Not Supported"", should be the only entry in the PowerManagementCapabilities array." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsProtocolSupportedNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - ProtocolSupported

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The protocol used by the controller to access \'controlled\' devices."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The protocol used by the controller to access \'controlled\' devices." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ProtocolSupportedValues 

#### Public Property - Status

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - @"The Status property is a string indicating the current status of the object. Various operational and non-operational statuses can be defined. Operational statuses are ""OK"", ""Degraded"" and ""Pred Fail"". ""Pred Fail"" indicates that an element may be functioning properly but predicting a failure in the near future. An example is a SMART-enabled hard drive. Non-operational statuses can also be specified. These are ""Error"", ""Starting"", ""Stopping"" and ""Service"". The latter, ""Service"", could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is on-line, yet the managed element is neither ""OK"" nor in one of the other states."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The Status property is a string indicating the current status of the object. Various operational and non-operational statuses can be defined. Operational statuses are ""OK"", ""Degraded"" and ""Pred Fail"". ""Pred Fail"" indicates that an element may be functioning properly but predicting a failure in the near future. An example is a SMART-enabled hard drive. Non-operational statuses can also be specified. These are ""Error"", ""Starting"", ""Stopping"" and ""Service"". The latter, ""Service"", could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is on-line, yet the managed element is neither ""OK"" nor in one of the other states." ) ] string 

#### Public Property - IsStatusInfoNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - StatusInfo

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "StatusInfo is a string indicating whether the logical device is in an enabled (va"
 - +
 - "lue = 3), disabled (value = 4) or some other (1) or unknown (2) state. If this p"
 - +
 - "roperty does not apply to the logical device, the value, 5 (\"Not Applicable\"), s"
 - +
 - "hould be used."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "StatusInfo is a string indicating whether the logical device is in an enabled (va" + "lue = 3), disabled (value = 4) or some other (1) or unknown (2) state. If this p" + "roperty does not apply to the logical device, the value, 5 (\"Not Applicable\"), s" + "hould be used." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] StatusInfoValues 

#### Public Property - SystemCreationClassName

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The scoping System\'s CreationClassName."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The scoping System\'s CreationClassName." ) ] string 

#### Public Property - SystemName

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The scoping System\'s Name."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The scoping System\'s Name." ) ] string 

#### Public Property - IsTimeOfLastResetNull

##### Attributes

 - Browsable
 - (
 - false
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )

##### Summary

 * Type: [ Browsable ( false ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] bool 

#### Public Property - TimeOfLastReset

##### Attributes

 - Browsable
 - (
 - true
 - )
 - DesignerSerializationVisibility
 - (
 - DesignerSerializationVisibility
 - .
 - Hidden
 - )
 - Description
 - (
 - "The TimeOfLastReset property indicates the date and time this controller was last"
 - +
 - " reset.  This could mean the controller was powered down, or reinitialized."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The TimeOfLastReset property indicates the date and time this controller was last" + " reset.  This could mean the controller was powered down, or reinitialized." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] System . DateTime 

#### Private Method - CheckIfProperClass

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions OptionsParam 

#### Private Method - CheckIfProperClass

#####  Parameters

 - System . Management . ManagementBaseObject theObj 

#### Private Method - ShouldSerializeAvailability


#### Private Method - ShouldSerializeConfigManagerErrorCode


#### Private Method - ShouldSerializeConfigManagerUserConfig


#### Private Method - ShouldSerializeErrorCleared


#### Static Method - ToDateTime

#####  Parameters

 - string dmtfDate 

#### Static Method - ToDmtfDateTime

#####  Parameters

 - System . DateTime date 

#### Private Method - ShouldSerializeInstallDate


#### Private Method - ShouldSerializeLastErrorCode


#### Private Method - ShouldSerializeMaxNumberControlled


#### Private Method - ShouldSerializePowerManagementSupported


#### Private Method - ShouldSerializeProtocolSupported


#### Private Method - ShouldSerializeStatusInfo


#### Private Method - ShouldSerializeTimeOfLastReset


#### Public Method - CommitObject

##### Attributes

 - Browsable
 - (
 - true
 - )


#### Public Method - CommitObject

##### Attributes

 - Browsable
 - (
 - true
 - )

#####  Parameters

 - System . Management . PutOptions putOptions 

#### Private Method - Initialize


#### Private Static Method - ConstructPath

#####  Parameters

 - string keyDeviceID 

#### Private Method - InitializeObject

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions getOptions 

#### Public Static Method - GetInstances


#### Public Static Method - GetInstances

#####  Parameters

 - string condition 

#### Public Static Method - GetInstances

#####  Parameters

 - System . String [  ] selectedProperties 

#### Public Static Method - GetInstances

#####  Parameters

 - string condition 
 - System . String [  ] selectedProperties 

#### Public Static Method - GetInstances

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . EnumerationOptions enumOptions 

#### Public Static Method - GetInstances

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - string condition 

#### Public Static Method - GetInstances

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . String [  ] selectedProperties 

#### Public Static Method - GetInstances

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - string condition 
 - System . String [  ] selectedProperties 

#### Public Static Method - CreateInstance

##### Attributes

 - Browsable
 - (
 - true
 - )


#### Public Method - Delete

##### Attributes

 - Browsable
 - (
 - true
 - )


#### Public Method - Reset


#### Public Method - SetPowerState

#####  Parameters

 - ushort PowerState 
 - System . DateTime Time 

#### Private Field - privColObj

##### Summary

 * Type: ManagementObjectCollection 

#### Public Constructor - USBControllerCollection

#####  Parameters

 - ManagementObjectCollection objCollection 

#### Public Property - Count

##### Summary

 * Type: int 

#### Public Property - IsSynchronized

##### Summary

 * Type: bool 

#### Public Property - SyncRoot

##### Summary

 * Type: object 

#### Public Method - CopyTo

#####  Parameters

 - System . Array array 
 - int index 

#### Public Method - GetEnumerator


#### Private Field - privObjEnum

##### Summary

 * Type: 

#### Public Constructor - USBControllerEnumerator

#####  Parameters

 - ManagementObjectCollection . ManagementObjectEnumerator objEnum 

#### Public Property - Current

##### Summary

 * Type: object 

#### Public Method - MoveNext


#### Public Method - Reset


#### Private Field - baseConverter

##### Summary

 * Type: TypeConverter 

#### Private Field - baseType

##### Summary

 * Type: 

#### Public Constructor - WMIValueTypeConverter

#####  Parameters

 - System . Type inBaseType 

#### Public Method - CanConvertFrom

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Type srcType 

#### Public Method - CanConvertTo

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Type destinationType 

#### Public Method - ConvertFrom

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Globalization . CultureInfo culture 
 - object value 

#### Public Method - CreateInstance

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Collections . IDictionary dictionary 

#### Public Method - GetCreateInstanceSupported

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetProperties

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - object value 
 - System . Attribute [  ] attributeVar 

#### Public Method - GetPropertiesSupported

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetStandardValues

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetStandardValuesExclusive

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetStandardValuesSupported

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - ConvertTo

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Globalization . CultureInfo culture 
 - object value 
 - System . Type destinationType 

#### Private Field - PrivateLateBoundObject

##### Summary

 * Type: 

#### Public Constructor - ManagementSystemProperties

#####  Parameters

 - System . Management . ManagementBaseObject ManagedObject 

#### Public Property - GENUS

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] int 

#### Public Property - CLASS

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - SUPERCLASS

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - DYNASTY

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - RELPATH

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - PROPERTY_COUNT

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] int 

#### Public Property - DERIVATION

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string [  ] 

#### Public Property - SERVER

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - NAMESPACE

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - PATH

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

## Public Enumeration - AvailabilityValues

## Public Enumeration - ConfigManagerErrorCodeValues

## Public Enumeration - PowerManagementCapabilitiesValues

## Public Enumeration - ProtocolSupportedValues

## Public Enumeration - StatusInfoValues

## Public Class - USBControllerCollection

### Members

#### Private Field - privColObj

##### Summary

 * Type: ManagementObjectCollection 

#### Public Constructor - USBControllerCollection

#####  Parameters

 - ManagementObjectCollection objCollection 

#### Public Property - Count

##### Summary

 * Type: int 

#### Public Property - IsSynchronized

##### Summary

 * Type: bool 

#### Public Property - SyncRoot

##### Summary

 * Type: object 

#### Public Method - CopyTo

#####  Parameters

 - System . Array array 
 - int index 

#### Public Method - GetEnumerator


#### Private Field - privObjEnum

##### Summary

 * Type: 

#### Public Constructor - USBControllerEnumerator

#####  Parameters

 - ManagementObjectCollection . ManagementObjectEnumerator objEnum 

#### Public Property - Current

##### Summary

 * Type: object 

#### Public Method - MoveNext


#### Public Method - Reset


## Public Class - USBControllerEnumerator

### Members

#### Private Field - privObjEnum

##### Summary

 * Type: 

#### Public Constructor - USBControllerEnumerator

#####  Parameters

 - ManagementObjectCollection . ManagementObjectEnumerator objEnum 

#### Public Property - Current

##### Summary

 * Type: object 

#### Public Method - MoveNext


#### Public Method - Reset


## Public Class - WMIValueTypeConverter

### Members

#### Private Field - baseConverter

##### Summary

 * Type: TypeConverter 

#### Private Field - baseType

##### Summary

 * Type: 

#### Public Constructor - WMIValueTypeConverter

#####  Parameters

 - System . Type inBaseType 

#### Public Method - CanConvertFrom

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Type srcType 

#### Public Method - CanConvertTo

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Type destinationType 

#### Public Method - ConvertFrom

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Globalization . CultureInfo culture 
 - object value 

#### Public Method - CreateInstance

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Collections . IDictionary dictionary 

#### Public Method - GetCreateInstanceSupported

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetProperties

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - object value 
 - System . Attribute [  ] attributeVar 

#### Public Method - GetPropertiesSupported

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetStandardValues

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetStandardValuesExclusive

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - GetStandardValuesSupported

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 

#### Public Method - ConvertTo

#####  Parameters

 - System . ComponentModel . ITypeDescriptorContext context 
 - System . Globalization . CultureInfo culture 
 - object value 
 - System . Type destinationType 

## Public Class - ManagementSystemProperties

### Attributes

 - TypeConverter
 - (
 - typeof
 - (
 - System
 - .
 - ComponentModel
 - .
 - ExpandableObjectConverter
 - )
 - )

### Members

#### Private Field - PrivateLateBoundObject

##### Summary

 * Type: 

#### Public Constructor - ManagementSystemProperties

#####  Parameters

 - System . Management . ManagementBaseObject ManagedObject 

#### Public Property - GENUS

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] int 

#### Public Property - CLASS

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - SUPERCLASS

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - DYNASTY

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - RELPATH

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - PROPERTY_COUNT

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] int 

#### Public Property - DERIVATION

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string [  ] 

#### Public Property - SERVER

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - NAMESPACE

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

#### Public Property - PATH

##### Attributes

 - Browsable
 - (
 - true
 - )

##### Summary

 * Type: [ Browsable ( true ) ] string 

