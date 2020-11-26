# ROOT.CIMV2.Win32_ComputerSystem.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Nmea/Notes/ROOT.CIMV2.Win32_ComputerSystem.cs

## Public Class - ComputerSystem

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

#### Public Constructor - ComputerSystem


#### Public Constructor - ComputerSystem

#####  Parameters

 - string keyName 

#### Public Constructor - ComputerSystem

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - string keyName 

#### Public Constructor - ComputerSystem

#####  Parameters

 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions getOptions 

#### Public Constructor - ComputerSystem

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 

#### Public Constructor - ComputerSystem

#####  Parameters

 - System . Management . ManagementPath path 

#### Public Constructor - ComputerSystem

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions getOptions 

#### Public Constructor - ComputerSystem

#####  Parameters

 - System . Management . ManagementObject theObject 

#### Public Constructor - ComputerSystem

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

#### Public Property - IsAdminPasswordStatusNull

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

#### Public Property - AdminPasswordStatus

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
 - "The AdminPasswordStatus property identifies the system-wide hardware security set"
 - +
 - "tings for Administrator Password Status."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The AdminPasswordStatus property identifies the system-wide hardware security set" + "tings for Administrator Password Status." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] AdminPasswordStatusValues 

#### Public Property - IsAutomaticResetBootOptionNull

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

#### Public Property - AutomaticResetBootOption

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
 - "The AutomaticResetBootOption property determines whether the automatic reset boot"
 - +
 - " option is enabled, i.e. whether the machine will try to reboot after a system f"
 - +
 - "ailure.\nValues: TRUE or FALSE. If TRUE, the automatic reset boot option is enabl"
 - +
 - "ed."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The AutomaticResetBootOption property determines whether the automatic reset boot" + " option is enabled, i.e. whether the machine will try to reboot after a system f" + "ailure.\nValues: TRUE or FALSE. If TRUE, the automatic reset boot option is enabl" + "ed." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsAutomaticResetCapabilityNull

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

#### Public Property - AutomaticResetCapability

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
 - "The AutomaticResetCapability property determines whether the auto reboot feature "
 - +
 - "is available with this machine. This capability is available on Windows NT but n"
 - +
 - "ot on Windows 95.\nValues: TRUE or FALSE. If TRUE, the automatic reset is enabled"
 - +
 - "."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The AutomaticResetCapability property determines whether the auto reboot feature " + "is available with this machine. This capability is available on Windows NT but n" + "ot on Windows 95.\nValues: TRUE or FALSE. If TRUE, the automatic reset is enabled" + "." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsBootOptionOnLimitNull

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

#### Public Property - BootOptionOnLimit

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
 - "Boot Option on Limit. Identifies the system action to be taken when the Reset Lim"
 - +
 - "it is reached."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "Boot Option on Limit. Identifies the system action to be taken when the Reset Lim" + "it is reached." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] BootOptionOnLimitValues 

#### Public Property - IsBootOptionOnWatchDogNull

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

#### Public Property - BootOptionOnWatchDog

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
 - "The BootOptionOnWatchDog Property indicates the type of re-boot action to be take"
 - +
 - "n after the time on the watchdog timer has elapsed."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The BootOptionOnWatchDog Property indicates the type of re-boot action to be take" + "n after the time on the watchdog timer has elapsed." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] BootOptionOnWatchDogValues 

#### Public Property - IsBootROMSupportedNull

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

#### Public Property - BootROMSupported

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
 - "The BootROMSupported property determines whether a boot ROM is supported.\nValues "
 - +
 - "are TRUE or FALSE. If BootROMSupported equals TRUE, then a boot ROM is supported"
 - +
 - "."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The BootROMSupported property determines whether a boot ROM is supported.\nValues " + "are TRUE or FALSE. If BootROMSupported equals TRUE, then a boot ROM is supported" + "." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - BootupState

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
 - "The BootupState property specifies how the system was started. Fail-safe boot (al"
 - +
 - "so called SafeBoot) bypasses the user\'s startup files. \nConstraints: Must have a"
 - +
 - " value."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The BootupState property specifies how the system was started. Fail-safe boot (al" + "so called SafeBoot) bypasses the user\'s startup files. \nConstraints: Must have a" + " value." ) ] string 

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

#### Public Property - IsChassisBootupStateNull

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

#### Public Property - ChassisBootupState

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
 - "The ChassisBootupState property indicates the enclosure\'s bootup state."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The ChassisBootupState property indicates the enclosure\'s bootup state." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ChassisBootupStateValues 

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
 - @"The CreationClassName property indicates the name of the class or the subclass used in the creation of an instance. When used with the other key properties of this class, this property allows all instances of this class and its subclasses to be uniquely identified."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The CreationClassName property indicates the name of the class or the subclass used in the creation of an instance. When used with the other key properties of this class, this property allows all instances of this class and its subclasses to be uniquely identified." ) ] string 

#### Public Property - IsCurrentTimeZoneNull

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

#### Public Property - CurrentTimeZone

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
 - "The CurrentTimeZone property  indicates the amount of time the unitary computer s"
 - +
 - "ystem is offset from Coordinated Universal Time."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The CurrentTimeZone property  indicates the amount of time the unitary computer s" + "ystem is offset from Coordinated Universal Time." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] short 

#### Public Property - IsDaylightInEffectNull

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

#### Public Property - DaylightInEffect

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
 - "The DaylightInEffect property specifies if the daylight savings is in effect. \nVa"
 - +
 - "lues: TRUE or FALSE.  If TRUE, daylight savings is presently being observed.  In"
 - +
 - " most cases this means that the current time is one hour earlier than the standa"
 - +
 - "rd time."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The DaylightInEffect property specifies if the daylight savings is in effect. \nVa" + "lues: TRUE or FALSE.  If TRUE, daylight savings is presently being observed.  In" + " most cases this means that the current time is one hour earlier than the standa" + "rd time." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

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

#### Public Property - Domain

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
 - "The Domain property indicates the name of the domain to which the computer belong"
 - +
 - "s."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Domain property indicates the name of the domain to which the computer belong" + "s." ) ] string 

#### Public Property - IsDomainRoleNull

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

#### Public Property - DomainRole

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
 - @"The DomainRole property indicates the role this computer plays within its assigned domain-workgroup. The domain-workgroup is a collection of computers on the same network.  For example, the DomainRole property may show this computer is a ""Member Workstation"" (value of [1])."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The DomainRole property indicates the role this computer plays within its assigned domain-workgroup. The domain-workgroup is a collection of computers on the same network.  For example, the DomainRole property may show this computer is a ""Member Workstation"" (value of [1])." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] DomainRoleValues 

#### Public Property - IsEnableDaylightSavingsTimeNull

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

#### Public Property - EnableDaylightSavingsTime

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
 - "The EnableDaylightSavingsTime property indicates whether Daylight Savings Time is"
 - +
 - " recognized on this machine.  FALSE - time does not move an hour ahead or behind"
 - +
 - " in the year.  NULL - the status of DST is unknown on this system"
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The EnableDaylightSavingsTime property indicates whether Daylight Savings Time is" + " recognized on this machine.  FALSE - time does not move an hour ahead or behind" + " in the year.  NULL - the status of DST is unknown on this system" ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsFrontPanelResetStatusNull

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

#### Public Property - FrontPanelResetStatus

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
 - "The FrontPanelResetStatus property identifies the hardware security settings for "
 - +
 - "the reset button on the machine."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The FrontPanelResetStatus property identifies the hardware security settings for " + "the reset button on the machine." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] FrontPanelResetStatusValues 

#### Public Property - IsInfraredSupportedNull

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

#### Public Property - InfraredSupported

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
 - "The InfraredSupported property determines whether an infrared (IR) port exists on"
 - +
 - " the computer system.\nValues are TRUE or FALSE. If InfraredSupported equals TRUE"
 - +
 - ", then an IR port exists."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The InfraredSupported property determines whether an infrared (IR) port exists on" + " the computer system.\nValues are TRUE or FALSE. If InfraredSupported equals TRUE" + ", then an IR port exists." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - InitialLoadInfo

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
 - "This object contains the data needed to find either the initial load device (its "
 - +
 - "key) or the boot service to request the operating system to start up. In additio"
 - +
 - "n, the load parameters (ie, a pathname and parameters) may also be specified."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "This object contains the data needed to find either the initial load device (its " + "key) or the boot service to request the operating system to start up. In additio" + "n, the load parameters (ie, a pathname and parameters) may also be specified." ) ] string [  ] 

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

#### Public Property - IsKeyboardPasswordStatusNull

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

#### Public Property - KeyboardPasswordStatus

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
 - "The KeyboardPasswordStatus property identifies the system-wide hardware security "
 - +
 - "settings for Keyboard Password Status."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The KeyboardPasswordStatus property identifies the system-wide hardware security " + "settings for Keyboard Password Status." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] KeyboardPasswordStatusValues 

#### Public Property - LastLoadInfo

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
 - "This object contains the data identifying either the initial load device (its key"
 - +
 - ") or the boot service that requested the last operating system load. In addition"
 - +
 - ", the load parameters (ie, a pathname and parameters) may also be specified."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "This object contains the data identifying either the initial load device (its key" + ") or the boot service that requested the last operating system load. In addition" + ", the load parameters (ie, a pathname and parameters) may also be specified." ) ] string 

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
 - "The Manufacturer property indicates the name of the computer manufacturer.\nExampl"
 - +
 - "e: Acme"
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Manufacturer property indicates the name of the computer manufacturer.\nExampl" + "e: Acme" ) ] string 

#### Public Property - Model

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
 - "The Model property indicates the product name of the computer given by the manufa"
 - +
 - "cturer."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Model property indicates the product name of the computer given by the manufa" + "cturer." ) ] string 

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

#### Public Property - NameFormat

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
 - @"The CIM_ComputerSystem object and its derivatives are Top Level Objects of CIM. They provide the scope for numerous components. Having unique CIM_System keys is required. A heuristic is defined to create the CIM_ComputerSystem name to attempt to always generate the same name, independent of discovery protocol. This prevents inventory and management problems where the same asset or entity is discovered multiple times, but can not be resolved to a single object. Use of the heuristic is optional, but recommended. 

 The NameFormat property identifies how the computer system name is generated, using a heuristic. The heuristic is outlined, in detail, in the CIM V2 Common Model specification. It assumes that the documented rules are traversed in order, to determine and assign a name. The NameFormat values list defines the precedence order for assigning the computer system name. Several rules do map to the same Value. 

 Note that the CIM_ComputerSystem Name calculated using the heuristic is the system's key value. Other names can be assigned and used for the CIM_ComputerSystem that better suit the business, using Aliases."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The CIM_ComputerSystem object and its derivatives are Top Level Objects of CIM. They provide the scope for numerous components. Having unique CIM_System keys is required. A heuristic is defined to create the CIM_ComputerSystem name to attempt to always generate the same name, independent of discovery protocol. This prevents inventory and management problems where the same asset or entity is discovered multiple times, but can not be resolved to a single object. Use of the heuristic is optional, but recommended. 

 The NameFormat property identifies how the computer system name is generated, using a heuristic. The heuristic is outlined, in detail, in the CIM V2 Common Model specification. It assumes that the documented rules are traversed in order, to determine and assign a name. The NameFormat values list defines the precedence order for assigning the computer system name. Several rules do map to the same Value. 

 Note that the CIM_ComputerSystem Name calculated using the heuristic is the system's key value. Other names can be assigned and used for the CIM_ComputerSystem that better suit the business, using Aliases." ) ] string 

#### Public Property - IsNetworkServerModeEnabledNull

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

#### Public Property - NetworkServerModeEnabled

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
 - "The NetworkServerModeEnabled property determines whether Network Server Mode is e"
 - +
 - "nabled.\nValues: TRUE or FALSE.  If TRUE, Network Server Mode is enabled."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The NetworkServerModeEnabled property determines whether Network Server Mode is e" + "nabled.\nValues: TRUE or FALSE.  If TRUE, Network Server Mode is enabled." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsNumberOfProcessorsNull

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

#### Public Property - NumberOfProcessors

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
 - @"The NumberOfProcessors property indicates the number of processors currently available on the system. This is the number of processors whose status is ""enabled"" - versus simply the number of processors for the computer system. The former can be determined by enumerating the number of processor instances associated with the computer system object, using the Win32_ComputerSystemProcessor association."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The NumberOfProcessors property indicates the number of processors currently available on the system. This is the number of processors whose status is ""enabled"" - versus simply the number of processors for the computer system. The former can be determined by enumerating the number of processor instances associated with the computer system object, using the Win32_ComputerSystemProcessor association." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] uint 

#### Public Property - OEMLogoBitmap

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
 - "The OEMLogoBitmap array holds the data for a bitmap created by the OEM."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The OEMLogoBitmap array holds the data for a bitmap created by the OEM." ) ] byte [  ] 

#### Public Property - OEMStringArray

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
 - "This structure contains free form strings defined by the OEM. Examples of this ar"
 - +
 - "e: Part Numbers for Reference Documents for the system, contact information for "
 - +
 - "the manufacturer, etc."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "This structure contains free form strings defined by the OEM. Examples of this ar" + "e: Part Numbers for Reference Documents for the system, contact information for " + "the manufacturer, etc." ) ] string [  ] 

#### Public Property - IsPartOfDomainNull

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

#### Public Property - PartOfDomain

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
 - "The PartOfDomain property indicates whether the computer is part of a domain or w"
 - +
 - "orkgroup.  If TRUE, the computer is part of a domain.  If FALSE, the computer is"
 - +
 - " part of a workgroup.  If NULL, the computer is not part of a network group, or "
 - +
 - "is unknown."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The PartOfDomain property indicates whether the computer is part of a domain or w" + "orkgroup.  If TRUE, the computer is part of a domain.  If FALSE, the computer is" + " part of a workgroup.  If NULL, the computer is not part of a network group, or " + "is unknown." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsPauseAfterResetNull

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

#### Public Property - PauseAfterReset

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
 - "The PauseAfterReset property identifies the time delay before the reboot is initi"
 - +
 - "ated.  It is used after a system power cycle, system reset (local or remote), an"
 - +
 - "d automatic system reset.  A value of -1 indicates that the pause value is unkno"
 - +
 - "wn"
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The PauseAfterReset property identifies the time delay before the reboot is initi" + "ated.  It is used after a system power cycle, system reset (local or remote), an" + "d automatic system reset.  A value of -1 indicates that the pause value is unkno" + "wn" ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] long 

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
 - @"Indicates the specific power-related capabilities of a computer system and its associated running operating system. The values, 0=""Unknown"", 1=""Not Supported"", and 2=""Disabled"" are self-explanatory. The value, 3=""Enabled"" indicates that the power management features are currently enabled but the exact feature set is unknown or the information is unavailable. ""Power Saving Modes Entered Automatically"" (4) describes that a system can change its power state based on usage or other criteria. ""Power State Settable"" (5) indicates that the SetPowerState method is supported. ""Power Cycling Supported"" (6) indicates that the SetPowerState method can be invoked with the PowerState parameter set to 5 (""Power Cycle""). ""Timed Power On Supported"" (7) indicates that the SetPowerState method can be invoked with the PowerState parameter set to 5 (""Power Cycle"") and the Time parameter set to a specific date and time, or interval, for power-on."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"Indicates the specific power-related capabilities of a computer system and its associated running operating system. The values, 0=""Unknown"", 1=""Not Supported"", and 2=""Disabled"" are self-explanatory. The value, 3=""Enabled"" indicates that the power management features are currently enabled but the exact feature set is unknown or the information is unavailable. ""Power Saving Modes Entered Automatically"" (4) describes that a system can change its power state based on usage or other criteria. ""Power State Settable"" (5) indicates that the SetPowerState method is supported. ""Power Cycling Supported"" (6) indicates that the SetPowerState method can be invoked with the PowerState parameter set to 5 (""Power Cycle""). ""Timed Power On Supported"" (7) indicates that the SetPowerState method can be invoked with the PowerState parameter set to 5 (""Power Cycle"") and the Time parameter set to a specific date and time, or interval, for power-on." ) ] PowerManagementCapabilitiesValues [  ] 

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
 - @"Boolean indicating that the ComputerSystem, with its running OperatingSystem, supports power management. This boolean does not indicate that power management features are currently enabled, or if enabled, what features are supported. Refer to the PowerManagementCapabilities array for this information. If this boolean is false, the integer value 1 for the string, ""Not Supported"", should be the only entry in the PowerManagementCapabilities array."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"Boolean indicating that the ComputerSystem, with its running OperatingSystem, supports power management. This boolean does not indicate that power management features are currently enabled, or if enabled, what features are supported. Refer to the PowerManagementCapabilities array for this information. If this boolean is false, the integer value 1 for the string, ""Not Supported"", should be the only entry in the PowerManagementCapabilities array." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] bool 

#### Public Property - IsPowerOnPasswordStatusNull

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

#### Public Property - PowerOnPasswordStatus

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
 - "The PowerOnPasswordStatus property identifies the system-wide hardware security s"
 - +
 - "ettings for Power On Password Status."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The PowerOnPasswordStatus property identifies the system-wide hardware security s" + "ettings for Power On Password Status." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] PowerOnPasswordStatusValues 

#### Public Property - IsPowerStateNull

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

#### Public Property - PowerState

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
 - @"Indicates the current power state of the computer system and its associated operating system. Regarding the power saving states, these are defined as follows: Value 4 (Unknown) indicates that the system is known to be in a power save mode, but its exact status in this mode is unknown; 2 (Low Power Mode) indicates that the system is in a power save state but still functioning, and may exhibit degraded performance; 3 (Standby) describes that the system is not functioning but could be brought to full power 'quickly'; and value 7 (Warning) indicates that the computerSystem is in a warning state, though also in a power save mode."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"Indicates the current power state of the computer system and its associated operating system. Regarding the power saving states, these are defined as follows: Value 4 (Unknown) indicates that the system is known to be in a power save mode, but its exact status in this mode is unknown; 2 (Low Power Mode) indicates that the system is in a power save state but still functioning, and may exhibit degraded performance; 3 (Standby) describes that the system is not functioning but could be brought to full power 'quickly'; and value 7 (Warning) indicates that the computerSystem is in a warning state, though also in a power save mode." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] PowerStateValues 

#### Public Property - IsPowerSupplyStateNull

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

#### Public Property - PowerSupplyState

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
 - "The PowerSupplyState identifies the state of the enclosure\'s power supply (or sup"
 - +
 - "plies) when last booted."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The PowerSupplyState identifies the state of the enclosure\'s power supply (or sup" + "plies) when last booted." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] PowerSupplyStateValues 

#### Public Property - PrimaryOwnerContact

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
 - "A string that provides information on how the primary system owner can be reached"
 - +
 - " (e.g. phone number, email address, ...)."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "A string that provides information on how the primary system owner can be reached" + " (e.g. phone number, email address, ...)." ) ] string 

#### Public Property - PrimaryOwnerName

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
 - "The name of the primary system owner."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The name of the primary system owner." ) ] string 

#### Public Property - IsResetCapabilityNull

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

#### Public Property - ResetCapability

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
 - @"If enabled (value = 4), the unitary computer system can be reset via hardware (e.g. the power and reset buttons). If disabled (value = 3), hardware reset is not allowed. In addition to Enabled and Disabled, other values for the property are also defined - ""Not Implemented"" (5), ""Other"" (1) and ""Unknown"" (2)."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"If enabled (value = 4), the unitary computer system can be reset via hardware (e.g. the power and reset buttons). If disabled (value = 3), hardware reset is not allowed. In addition to Enabled and Disabled, other values for the property are also defined - ""Not Implemented"" (5), ""Other"" (1) and ""Unknown"" (2)." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ResetCapabilityValues 

#### Public Property - IsResetCountNull

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

#### Public Property - ResetCount

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
 - "The ResetCount property indicates the number of automatic resets since the last i"
 - +
 - "ntentional reset.  A value of -1 indicates that the count is unknown."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The ResetCount property indicates the number of automatic resets since the last i" + "ntentional reset.  A value of -1 indicates that the count is unknown." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] short 

#### Public Property - IsResetLimitNull

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

#### Public Property - ResetLimit

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
 - "The ResetLimit property indicates the number of consecutive time the system reset"
 - +
 - " will be attempted. A value of -1 indicates that the limit is unknown"
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The ResetLimit property indicates the number of consecutive time the system reset" + " will be attempted. A value of -1 indicates that the limit is unknown" ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] short 

#### Public Property - Roles

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
 - @"An array (bag) of strings that specify the roles this System plays in the IT-environment. Subclasses of System may override this property to define explicit Roles values. Alternately, a Working Group may describe the heuristics, conventions and guidelines for specifying Roles. For example, for an instance of a networking system, the Roles property might contain the string, 'Switch' or 'Bridge'."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"An array (bag) of strings that specify the roles this System plays in the IT-environment. Subclasses of System may override this property to define explicit Roles values. Alternately, a Working Group may describe the heuristics, conventions and guidelines for specifying Roles. For example, for an instance of a networking system, the Roles property might contain the string, 'Switch' or 'Bridge'." ) ] string [  ] 

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

#### Public Property - SupportContactDescription

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
 - "The SupportContactDescription property is an array that indicates the support con"
 - +
 - "tact information for the Win32 computer system."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The SupportContactDescription property is an array that indicates the support con" + "tact information for the Win32 computer system." ) ] string [  ] 

#### Public Property - IsSystemStartupDelayNull

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

#### Public Property - SystemStartupDelay

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
 - "The SystemStartupDelay property indicates the time to delay before starting the o"
 - +
 - "perating system\n\nNote:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on "
 - +
 - "IA64bit machines. This privilege is not required for 32bit systems."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The SystemStartupDelay property indicates the time to delay before starting the o" + "perating system\n\nNote:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on " + "IA64bit machines. This privilege is not required for 32bit systems." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ushort 

#### Public Property - SystemStartupOptions

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
 - @"The SystemStartupOptions property array indicates the options for starting up the computer system. Note that this property is not writable on IA64 bit machines. 
Constraints: Must have a value.

Note:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on IA64bit machines. This privilege is not required for other systems."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The SystemStartupOptions property array indicates the options for starting up the computer system. Note that this property is not writable on IA64 bit machines. 
Constraints: Must have a value.

Note:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on IA64bit machines. This privilege is not required for other systems." ) ] string [  ] 

#### Public Property - IsSystemStartupSettingNull

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

#### Public Property - SystemStartupSetting

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
 - @"The SystemStartupSetting property indicates the index of the default start profile. This value is 'calculated' so that it usually returns zero (0) because at write-time, the profile string is physically moved to the top of the list. (This is how Windows NT determines which value is the default.)

Note:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on IA64bit machines. This privilege is not required for 32bit systems."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( @"The SystemStartupSetting property indicates the index of the default start profile. This value is 'calculated' so that it usually returns zero (0) because at write-time, the profile string is physically moved to the top of the list. (This is how Windows NT determines which value is the default.)

Note:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on IA64bit machines. This privilege is not required for 32bit systems." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] byte 

#### Public Property - SystemType

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
 - "The SystemType property indicates the type of system running on the Win32 compute"
 - +
 - "r.\nConstraints: Must have a value"
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The SystemType property indicates the type of system running on the Win32 compute" + "r.\nConstraints: Must have a value" ) ] string 

#### Public Property - IsThermalStateNull

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

#### Public Property - ThermalState

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
 - "The ThermalState property identifies the enclosure\'s thermal state when last boot"
 - +
 - "ed."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The ThermalState property identifies the enclosure\'s thermal state when last boot" + "ed." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ThermalStateValues 

#### Public Property - IsTotalPhysicalMemoryNull

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

#### Public Property - TotalPhysicalMemory

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
 - "The TotalPhysicalMemory property indicates the total size of physical memory.\nExa"
 - +
 - "mple: 67108864"
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The TotalPhysicalMemory property indicates the total size of physical memory.\nExa" + "mple: 67108864" ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] ulong 

#### Public Property - UserName

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
 - "The UserName property indicates the name of the currently-logged-on user.\nConstra"
 - +
 - "ints: Must have a value. \nExample: johnsmith"
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The UserName property indicates the name of the currently-logged-on user.\nConstra" + "ints: Must have a value. \nExample: johnsmith" ) ] string 

#### Public Property - IsWakeUpTypeNull

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

#### Public Property - WakeUpType

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
 - "The WakeUpType property indicates the event that caused the system to power up."
 - )
 - TypeConverter
 - (
 - typeof
 - (
 - WMIValueTypeConverter
 - )
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The WakeUpType property indicates the event that caused the system to power up." ) ] [ TypeConverter ( typeof ( WMIValueTypeConverter ) ) ] WakeUpTypeValues 

#### Public Property - Workgroup

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
 - "The Workgroup property contains the name of the workgroup.  This value is only va"
 - +
 - "lid if the PartOfDomain property is FALSE."
 - )

##### Summary

 * Type: [ Browsable ( true ) ] [ DesignerSerializationVisibility ( DesignerSerializationVisibility . Hidden ) ] [ Description ( "The Workgroup property contains the name of the workgroup.  This value is only va" + "lid if the PartOfDomain property is FALSE." ) ] string 

#### Private Method - CheckIfProperClass

#####  Parameters

 - System . Management . ManagementScope mgmtScope 
 - System . Management . ManagementPath path 
 - System . Management . ObjectGetOptions OptionsParam 

#### Private Method - CheckIfProperClass

#####  Parameters

 - System . Management . ManagementBaseObject theObj 

#### Private Method - ShouldSerializeAdminPasswordStatus


#### Private Method - ShouldSerializeAutomaticResetBootOption


#### Private Method - ResetAutomaticResetBootOption


#### Private Method - ShouldSerializeAutomaticResetCapability


#### Private Method - ShouldSerializeBootOptionOnLimit


#### Private Method - ShouldSerializeBootOptionOnWatchDog


#### Private Method - ShouldSerializeBootROMSupported


#### Private Method - ShouldSerializeChassisBootupState


#### Private Method - ShouldSerializeCurrentTimeZone


#### Private Method - ResetCurrentTimeZone


#### Private Method - ShouldSerializeDaylightInEffect


#### Private Method - ShouldSerializeDomainRole


#### Private Method - ShouldSerializeEnableDaylightSavingsTime


#### Private Method - ResetEnableDaylightSavingsTime


#### Private Method - ShouldSerializeFrontPanelResetStatus


#### Private Method - ShouldSerializeInfraredSupported


#### Static Method - ToDateTime

#####  Parameters

 - string dmtfDate 

#### Static Method - ToDmtfDateTime

#####  Parameters

 - System . DateTime date 

#### Private Method - ShouldSerializeInstallDate


#### Private Method - ShouldSerializeKeyboardPasswordStatus


#### Private Method - ShouldSerializeNetworkServerModeEnabled


#### Private Method - ShouldSerializeNumberOfProcessors


#### Private Method - ShouldSerializePartOfDomain


#### Private Method - ShouldSerializePauseAfterReset


#### Private Method - ShouldSerializePowerManagementSupported


#### Private Method - ShouldSerializePowerOnPasswordStatus


#### Private Method - ShouldSerializePowerState


#### Private Method - ShouldSerializePowerSupplyState


#### Private Method - ShouldSerializeResetCapability


#### Private Method - ShouldSerializeResetCount


#### Private Method - ShouldSerializeResetLimit


#### Private Method - ResetRoles


#### Private Method - ShouldSerializeSystemStartupDelay


#### Private Method - ResetSystemStartupDelay


#### Private Method - ResetSystemStartupOptions


#### Private Method - ShouldSerializeSystemStartupSetting


#### Private Method - ResetSystemStartupSetting


#### Private Method - ShouldSerializeThermalState


#### Private Method - ShouldSerializeTotalPhysicalMemory


#### Private Method - ShouldSerializeWakeUpType


#### Private Method - ResetWorkgroup


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

 - string keyName 

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


#### Public Method - JoinDomainOrWorkgroup

#####  Parameters

 - string AccountOU 
 - uint FJoinOptions 
 - string Name 
 - string Password 
 - string UserName 

#### Public Method - Rename

#####  Parameters

 - string Name 
 - string Password 
 - string UserName 

#### Public Method - SetPowerState

#####  Parameters

 - ushort PowerState 
 - System . DateTime Time 

#### Public Method - UnjoinDomainOrWorkgroup

#####  Parameters

 - uint FUnjoinOptions 
 - string Password 
 - string UserName 

#### Private Field - privColObj

##### Summary

 * Type: ManagementObjectCollection 

#### Public Constructor - ComputerSystemCollection

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

#### Public Constructor - ComputerSystemEnumerator

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

## Public Enumeration - AdminPasswordStatusValues

## Public Enumeration - BootOptionOnLimitValues

## Public Enumeration - BootOptionOnWatchDogValues

## Public Enumeration - ChassisBootupStateValues

## Public Enumeration - DomainRoleValues

## Public Enumeration - FrontPanelResetStatusValues

## Public Enumeration - KeyboardPasswordStatusValues

## Public Enumeration - PowerManagementCapabilitiesValues

## Public Enumeration - PowerOnPasswordStatusValues

## Public Enumeration - PowerStateValues

## Public Enumeration - PowerSupplyStateValues

## Public Enumeration - ResetCapabilityValues

## Public Enumeration - ThermalStateValues

## Public Enumeration - WakeUpTypeValues

## Public Class - ComputerSystemCollection

### Members

#### Private Field - privColObj

##### Summary

 * Type: ManagementObjectCollection 

#### Public Constructor - ComputerSystemCollection

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

#### Public Constructor - ComputerSystemEnumerator

#####  Parameters

 - ManagementObjectCollection . ManagementObjectEnumerator objEnum 

#### Public Property - Current

##### Summary

 * Type: object 

#### Public Method - MoveNext


#### Public Method - Reset


## Public Class - ComputerSystemEnumerator

### Members

#### Private Field - privObjEnum

##### Summary

 * Type: 

#### Public Constructor - ComputerSystemEnumerator

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

