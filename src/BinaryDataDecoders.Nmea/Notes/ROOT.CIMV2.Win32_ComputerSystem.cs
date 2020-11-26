namespace Test1.ROOT.CIMV2 {
    using System;
    using System.ComponentModel;
    using System.Management;
    using System.Collections;
    using System.Globalization;
    using System.ComponentModel.Design.Serialization;
    using System.Reflection;
    
    
    // Functions ShouldSerialize<PropertyName> are functions used by VS property browser to check if a particular property has to be serialized. These functions are added for all ValueType properties ( properties of type Int32, BOOL etc.. which cannot be set to null). These functions use Is<PropertyName>Null function. These functions are also used in the TypeConverter implementation for the properties to check for NULL value of property so that an empty value can be shown in Property browser in case of Drag and Drop in Visual studio.
    // Functions Is<PropertyName>Null() are used to check if a property is NULL.
    // Functions Reset<PropertyName> are added for Nullable Read/Write properties. These functions are used by VS designer in property browser to set a property to NULL.
    // Every property added to the class for WMI property has attributes set to define its behavior in Visual Studio designer and also to define a TypeConverter to be used.
    // Datetime conversion functions ToDateTime and ToDmtfDateTime are added to the class to convert DMTF datetime to System.DateTime and vice-versa.
    // An Early Bound class generated for the WMI class.Win32_ComputerSystem
    public class ComputerSystem : System.ComponentModel.Component {
        
        // Private property to hold the WMI namespace in which the class resides.
        private static string CreatedWmiNamespace = "ROOT\\CIMV2";
        
        // Private property to hold the name of WMI class which created this class.
        private static string CreatedClassName = "Win32_ComputerSystem";
        
        // Private member variable to hold the ManagementScope which is used by the various methods.
        private static System.Management.ManagementScope statMgmtScope = null;
        
        private ManagementSystemProperties PrivateSystemProperties;
        
        // Underlying lateBound WMI object.
        private System.Management.ManagementObject PrivateLateBoundObject;
        
        // Member variable to store the 'automatic commit' behavior for the class.
        private bool AutoCommitProp;
        
        // Private variable to hold the embedded property representing the instance.
        private System.Management.ManagementBaseObject embeddedObj;
        
        // The current WMI object used
        private System.Management.ManagementBaseObject curObj;
        
        // Flag to indicate if the instance is an embedded object.
        private bool isEmbedded;
        
        // Below are different overloads of constructors to initialize an instance of the class with a WMI object.
        public ComputerSystem() {
            this.InitializeObject(null, null, null);
        }
        
        public ComputerSystem(string keyName) {
            this.InitializeObject(null, new System.Management.ManagementPath(ComputerSystem.ConstructPath(keyName)), null);
        }
        
        public ComputerSystem(System.Management.ManagementScope mgmtScope, string keyName) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(ComputerSystem.ConstructPath(keyName)), null);
        }
        
        public ComputerSystem(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public ComputerSystem(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public ComputerSystem(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public ComputerSystem(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public ComputerSystem(System.Management.ManagementObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                PrivateLateBoundObject = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
                curObj = PrivateLateBoundObject;
            }
            else {
                throw new System.ArgumentException("Class name does not match.");
            }
        }
        
        public ComputerSystem(System.Management.ManagementBaseObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                embeddedObj = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(theObject);
                curObj = embeddedObj;
                isEmbedded = true;
            }
            else {
                throw new System.ArgumentException("Class name does not match.");
            }
        }
        
        // Property returns the namespace of the WMI class.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OriginatingNamespace {
            get {
                return "ROOT\\CIMV2";
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ManagementClassName {
            get {
                string strRet = CreatedClassName;
                if ((curObj != null)) {
                    if ((curObj.ClassPath != null)) {
                        strRet = ((string)(curObj["__CLASS"]));
                        if (((strRet == null) 
                                    || (strRet == string.Empty))) {
                            strRet = CreatedClassName;
                        }
                    }
                }
                return strRet;
            }
        }
        
        // Property pointing to an embedded object to get System properties of the WMI object.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementSystemProperties SystemProperties {
            get {
                return PrivateSystemProperties;
            }
        }
        
        // Property returning the underlying lateBound object.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementBaseObject LateBoundObject {
            get {
                return curObj;
            }
        }
        
        // ManagementScope of the object.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementScope Scope {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Scope;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    PrivateLateBoundObject.Scope = value;
                }
            }
        }
        
        // Property to show the commit behavior for the WMI object. If true, WMI object will be automatically saved after each property modification.(ie. Put() is called after modification of a property).
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoCommit {
            get {
                return AutoCommitProp;
            }
            set {
                AutoCommitProp = value;
            }
        }
        
        // The ManagementPath of the underlying WMI object.
        [Browsable(true)]
        public System.Management.ManagementPath Path {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Path;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    if ((CheckIfProperClass(null, value, null) != true)) {
                        throw new System.ArgumentException("Class name does not match.");
                    }
                    PrivateLateBoundObject.Path = value;
                }
            }
        }
        
        // Public static scope property which is used by the various methods.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static System.Management.ManagementScope StaticScope {
            get {
                return statMgmtScope;
            }
            set {
                statMgmtScope = value;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAdminPasswordStatusNull {
            get {
                if ((curObj["AdminPasswordStatus"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The AdminPasswordStatus property identifies the system-wide hardware security set" +
            "tings for Administrator Password Status.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AdminPasswordStatusValues AdminPasswordStatus {
            get {
                if ((curObj["AdminPasswordStatus"] == null)) {
                    return ((AdminPasswordStatusValues)(System.Convert.ToInt32(4)));
                }
                return ((AdminPasswordStatusValues)(System.Convert.ToInt32(curObj["AdminPasswordStatus"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticResetBootOptionNull {
            get {
                if ((curObj["AutomaticResetBootOption"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The AutomaticResetBootOption property determines whether the automatic reset boot" +
            " option is enabled, i.e. whether the machine will try to reboot after a system f" +
            "ailure.\nValues: TRUE or FALSE. If TRUE, the automatic reset boot option is enabl" +
            "ed.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool AutomaticResetBootOption {
            get {
                if ((curObj["AutomaticResetBootOption"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["AutomaticResetBootOption"]));
            }
            set {
                curObj["AutomaticResetBootOption"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticResetCapabilityNull {
            get {
                if ((curObj["AutomaticResetCapability"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The AutomaticResetCapability property determines whether the auto reboot feature " +
            "is available with this machine. This capability is available on Windows NT but n" +
            "ot on Windows 95.\nValues: TRUE or FALSE. If TRUE, the automatic reset is enabled" +
            ".")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool AutomaticResetCapability {
            get {
                if ((curObj["AutomaticResetCapability"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["AutomaticResetCapability"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBootOptionOnLimitNull {
            get {
                if ((curObj["BootOptionOnLimit"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Boot Option on Limit. Identifies the system action to be taken when the Reset Lim" +
            "it is reached.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public BootOptionOnLimitValues BootOptionOnLimit {
            get {
                if ((curObj["BootOptionOnLimit"] == null)) {
                    return ((BootOptionOnLimitValues)(System.Convert.ToInt32(4)));
                }
                return ((BootOptionOnLimitValues)(System.Convert.ToInt32(curObj["BootOptionOnLimit"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBootOptionOnWatchDogNull {
            get {
                if ((curObj["BootOptionOnWatchDog"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The BootOptionOnWatchDog Property indicates the type of re-boot action to be take" +
            "n after the time on the watchdog timer has elapsed.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public BootOptionOnWatchDogValues BootOptionOnWatchDog {
            get {
                if ((curObj["BootOptionOnWatchDog"] == null)) {
                    return ((BootOptionOnWatchDogValues)(System.Convert.ToInt32(4)));
                }
                return ((BootOptionOnWatchDogValues)(System.Convert.ToInt32(curObj["BootOptionOnWatchDog"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBootROMSupportedNull {
            get {
                if ((curObj["BootROMSupported"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The BootROMSupported property determines whether a boot ROM is supported.\nValues " +
            "are TRUE or FALSE. If BootROMSupported equals TRUE, then a boot ROM is supported" +
            ".")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool BootROMSupported {
            get {
                if ((curObj["BootROMSupported"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["BootROMSupported"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The BootupState property specifies how the system was started. Fail-safe boot (al" +
            "so called SafeBoot) bypasses the user\'s startup files. \nConstraints: Must have a" +
            " value.")]
        public string BootupState {
            get {
                return ((string)(curObj["BootupState"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Caption property is a short textual description (one-line string) of the obje" +
            "ct.")]
        public string Caption {
            get {
                return ((string)(curObj["Caption"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsChassisBootupStateNull {
            get {
                if ((curObj["ChassisBootupState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ChassisBootupState property indicates the enclosure\'s bootup state.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ChassisBootupStateValues ChassisBootupState {
            get {
                if ((curObj["ChassisBootupState"] == null)) {
                    return ((ChassisBootupStateValues)(System.Convert.ToInt32(0)));
                }
                return ((ChassisBootupStateValues)(System.Convert.ToInt32(curObj["ChassisBootupState"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The CreationClassName property indicates the name of the class or the subclass used in the creation of an instance. When used with the other key properties of this class, this property allows all instances of this class and its subclasses to be uniquely identified.")]
        public string CreationClassName {
            get {
                return ((string)(curObj["CreationClassName"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCurrentTimeZoneNull {
            get {
                if ((curObj["CurrentTimeZone"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The CurrentTimeZone property  indicates the amount of time the unitary computer s" +
            "ystem is offset from Coordinated Universal Time.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public short CurrentTimeZone {
            get {
                if ((curObj["CurrentTimeZone"] == null)) {
                    return System.Convert.ToInt16(0);
                }
                return ((short)(curObj["CurrentTimeZone"]));
            }
            set {
                curObj["CurrentTimeZone"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDaylightInEffectNull {
            get {
                if ((curObj["DaylightInEffect"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The DaylightInEffect property specifies if the daylight savings is in effect. \nVa" +
            "lues: TRUE or FALSE.  If TRUE, daylight savings is presently being observed.  In" +
            " most cases this means that the current time is one hour earlier than the standa" +
            "rd time.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool DaylightInEffect {
            get {
                if ((curObj["DaylightInEffect"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["DaylightInEffect"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Description property provides a textual description of the object. ")]
        public string Description {
            get {
                return ((string)(curObj["Description"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Domain property indicates the name of the domain to which the computer belong" +
            "s.")]
        public string Domain {
            get {
                return ((string)(curObj["Domain"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDomainRoleNull {
            get {
                if ((curObj["DomainRole"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The DomainRole property indicates the role this computer plays within its assigned domain-workgroup. The domain-workgroup is a collection of computers on the same network.  For example, the DomainRole property may show this computer is a ""Member Workstation"" (value of [1]).")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public DomainRoleValues DomainRole {
            get {
                if ((curObj["DomainRole"] == null)) {
                    return ((DomainRoleValues)(System.Convert.ToInt32(6)));
                }
                return ((DomainRoleValues)(System.Convert.ToInt32(curObj["DomainRole"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEnableDaylightSavingsTimeNull {
            get {
                if ((curObj["EnableDaylightSavingsTime"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The EnableDaylightSavingsTime property indicates whether Daylight Savings Time is" +
            " recognized on this machine.  FALSE - time does not move an hour ahead or behind" +
            " in the year.  NULL - the status of DST is unknown on this system")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool EnableDaylightSavingsTime {
            get {
                if ((curObj["EnableDaylightSavingsTime"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["EnableDaylightSavingsTime"]));
            }
            set {
                curObj["EnableDaylightSavingsTime"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFrontPanelResetStatusNull {
            get {
                if ((curObj["FrontPanelResetStatus"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The FrontPanelResetStatus property identifies the hardware security settings for " +
            "the reset button on the machine.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public FrontPanelResetStatusValues FrontPanelResetStatus {
            get {
                if ((curObj["FrontPanelResetStatus"] == null)) {
                    return ((FrontPanelResetStatusValues)(System.Convert.ToInt32(4)));
                }
                return ((FrontPanelResetStatusValues)(System.Convert.ToInt32(curObj["FrontPanelResetStatus"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInfraredSupportedNull {
            get {
                if ((curObj["InfraredSupported"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The InfraredSupported property determines whether an infrared (IR) port exists on" +
            " the computer system.\nValues are TRUE or FALSE. If InfraredSupported equals TRUE" +
            ", then an IR port exists.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool InfraredSupported {
            get {
                if ((curObj["InfraredSupported"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["InfraredSupported"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This object contains the data needed to find either the initial load device (its " +
            "key) or the boot service to request the operating system to start up. In additio" +
            "n, the load parameters (ie, a pathname and parameters) may also be specified.")]
        public string[] InitialLoadInfo {
            get {
                return ((string[])(curObj["InitialLoadInfo"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInstallDateNull {
            get {
                if ((curObj["InstallDate"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The InstallDate property is datetime value indicating when the object was install" +
            "ed. A lack of a value does not indicate that the object is not installed.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime InstallDate {
            get {
                if ((curObj["InstallDate"] != null)) {
                    return ToDateTime(((string)(curObj["InstallDate"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsKeyboardPasswordStatusNull {
            get {
                if ((curObj["KeyboardPasswordStatus"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The KeyboardPasswordStatus property identifies the system-wide hardware security " +
            "settings for Keyboard Password Status.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public KeyboardPasswordStatusValues KeyboardPasswordStatus {
            get {
                if ((curObj["KeyboardPasswordStatus"] == null)) {
                    return ((KeyboardPasswordStatusValues)(System.Convert.ToInt32(4)));
                }
                return ((KeyboardPasswordStatusValues)(System.Convert.ToInt32(curObj["KeyboardPasswordStatus"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This object contains the data identifying either the initial load device (its key" +
            ") or the boot service that requested the last operating system load. In addition" +
            ", the load parameters (ie, a pathname and parameters) may also be specified.")]
        public string LastLoadInfo {
            get {
                return ((string)(curObj["LastLoadInfo"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Manufacturer property indicates the name of the computer manufacturer.\nExampl" +
            "e: Acme")]
        public string Manufacturer {
            get {
                return ((string)(curObj["Manufacturer"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Model property indicates the product name of the computer given by the manufa" +
            "cturer.")]
        public string Model {
            get {
                return ((string)(curObj["Model"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Name property defines the label by which the object is known. When subclassed" +
            ", the Name property can be overridden to be a Key property.")]
        public string Name {
            get {
                return ((string)(curObj["Name"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The CIM_ComputerSystem object and its derivatives are Top Level Objects of CIM. They provide the scope for numerous components. Having unique CIM_System keys is required. A heuristic is defined to create the CIM_ComputerSystem name to attempt to always generate the same name, independent of discovery protocol. This prevents inventory and management problems where the same asset or entity is discovered multiple times, but can not be resolved to a single object. Use of the heuristic is optional, but recommended. 

 The NameFormat property identifies how the computer system name is generated, using a heuristic. The heuristic is outlined, in detail, in the CIM V2 Common Model specification. It assumes that the documented rules are traversed in order, to determine and assign a name. The NameFormat values list defines the precedence order for assigning the computer system name. Several rules do map to the same Value. 

 Note that the CIM_ComputerSystem Name calculated using the heuristic is the system's key value. Other names can be assigned and used for the CIM_ComputerSystem that better suit the business, using Aliases.")]
        public string NameFormat {
            get {
                return ((string)(curObj["NameFormat"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNetworkServerModeEnabledNull {
            get {
                if ((curObj["NetworkServerModeEnabled"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The NetworkServerModeEnabled property determines whether Network Server Mode is e" +
            "nabled.\nValues: TRUE or FALSE.  If TRUE, Network Server Mode is enabled.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool NetworkServerModeEnabled {
            get {
                if ((curObj["NetworkServerModeEnabled"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["NetworkServerModeEnabled"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNumberOfProcessorsNull {
            get {
                if ((curObj["NumberOfProcessors"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The NumberOfProcessors property indicates the number of processors currently available on the system. This is the number of processors whose status is ""enabled"" - versus simply the number of processors for the computer system. The former can be determined by enumerating the number of processor instances associated with the computer system object, using the Win32_ComputerSystemProcessor association.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint NumberOfProcessors {
            get {
                if ((curObj["NumberOfProcessors"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["NumberOfProcessors"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The OEMLogoBitmap array holds the data for a bitmap created by the OEM.")]
        public byte[] OEMLogoBitmap {
            get {
                return ((byte[])(curObj["OEMLogoBitmap"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This structure contains free form strings defined by the OEM. Examples of this ar" +
            "e: Part Numbers for Reference Documents for the system, contact information for " +
            "the manufacturer, etc.")]
        public string[] OEMStringArray {
            get {
                return ((string[])(curObj["OEMStringArray"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPartOfDomainNull {
            get {
                if ((curObj["PartOfDomain"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PartOfDomain property indicates whether the computer is part of a domain or w" +
            "orkgroup.  If TRUE, the computer is part of a domain.  If FALSE, the computer is" +
            " part of a workgroup.  If NULL, the computer is not part of a network group, or " +
            "is unknown.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool PartOfDomain {
            get {
                if ((curObj["PartOfDomain"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["PartOfDomain"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPauseAfterResetNull {
            get {
                if ((curObj["PauseAfterReset"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PauseAfterReset property identifies the time delay before the reboot is initi" +
            "ated.  It is used after a system power cycle, system reset (local or remote), an" +
            "d automatic system reset.  A value of -1 indicates that the pause value is unkno" +
            "wn")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public long PauseAfterReset {
            get {
                if ((curObj["PauseAfterReset"] == null)) {
                    return System.Convert.ToInt64(0);
                }
                return ((long)(curObj["PauseAfterReset"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Indicates the specific power-related capabilities of a computer system and its associated running operating system. The values, 0=""Unknown"", 1=""Not Supported"", and 2=""Disabled"" are self-explanatory. The value, 3=""Enabled"" indicates that the power management features are currently enabled but the exact feature set is unknown or the information is unavailable. ""Power Saving Modes Entered Automatically"" (4) describes that a system can change its power state based on usage or other criteria. ""Power State Settable"" (5) indicates that the SetPowerState method is supported. ""Power Cycling Supported"" (6) indicates that the SetPowerState method can be invoked with the PowerState parameter set to 5 (""Power Cycle""). ""Timed Power On Supported"" (7) indicates that the SetPowerState method can be invoked with the PowerState parameter set to 5 (""Power Cycle"") and the Time parameter set to a specific date and time, or interval, for power-on.")]
        public PowerManagementCapabilitiesValues[] PowerManagementCapabilities {
            get {
                System.Array arrEnumVals = ((System.Array)(curObj["PowerManagementCapabilities"]));
                PowerManagementCapabilitiesValues[] enumToRet = new PowerManagementCapabilitiesValues[arrEnumVals.Length];
                int counter = 0;
                for (counter = 0; (counter < arrEnumVals.Length); counter = (counter + 1)) {
                    enumToRet[counter] = ((PowerManagementCapabilitiesValues)(System.Convert.ToInt32(arrEnumVals.GetValue(counter))));
                }
                return enumToRet;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerManagementSupportedNull {
            get {
                if ((curObj["PowerManagementSupported"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Boolean indicating that the ComputerSystem, with its running OperatingSystem, supports power management. This boolean does not indicate that power management features are currently enabled, or if enabled, what features are supported. Refer to the PowerManagementCapabilities array for this information. If this boolean is false, the integer value 1 for the string, ""Not Supported"", should be the only entry in the PowerManagementCapabilities array.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool PowerManagementSupported {
            get {
                if ((curObj["PowerManagementSupported"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["PowerManagementSupported"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerOnPasswordStatusNull {
            get {
                if ((curObj["PowerOnPasswordStatus"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PowerOnPasswordStatus property identifies the system-wide hardware security s" +
            "ettings for Power On Password Status.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public PowerOnPasswordStatusValues PowerOnPasswordStatus {
            get {
                if ((curObj["PowerOnPasswordStatus"] == null)) {
                    return ((PowerOnPasswordStatusValues)(System.Convert.ToInt32(4)));
                }
                return ((PowerOnPasswordStatusValues)(System.Convert.ToInt32(curObj["PowerOnPasswordStatus"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerStateNull {
            get {
                if ((curObj["PowerState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Indicates the current power state of the computer system and its associated operating system. Regarding the power saving states, these are defined as follows: Value 4 (Unknown) indicates that the system is known to be in a power save mode, but its exact status in this mode is unknown; 2 (Low Power Mode) indicates that the system is in a power save state but still functioning, and may exhibit degraded performance; 3 (Standby) describes that the system is not functioning but could be brought to full power 'quickly'; and value 7 (Warning) indicates that the computerSystem is in a warning state, though also in a power save mode.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public PowerStateValues PowerState {
            get {
                if ((curObj["PowerState"] == null)) {
                    return ((PowerStateValues)(System.Convert.ToInt32(10)));
                }
                return ((PowerStateValues)(System.Convert.ToInt32(curObj["PowerState"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerSupplyStateNull {
            get {
                if ((curObj["PowerSupplyState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The PowerSupplyState identifies the state of the enclosure\'s power supply (or sup" +
            "plies) when last booted.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public PowerSupplyStateValues PowerSupplyState {
            get {
                if ((curObj["PowerSupplyState"] == null)) {
                    return ((PowerSupplyStateValues)(System.Convert.ToInt32(0)));
                }
                return ((PowerSupplyStateValues)(System.Convert.ToInt32(curObj["PowerSupplyState"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string that provides information on how the primary system owner can be reached" +
            " (e.g. phone number, email address, ...).")]
        public string PrimaryOwnerContact {
            get {
                return ((string)(curObj["PrimaryOwnerContact"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The name of the primary system owner.")]
        public string PrimaryOwnerName {
            get {
                return ((string)(curObj["PrimaryOwnerName"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsResetCapabilityNull {
            get {
                if ((curObj["ResetCapability"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"If enabled (value = 4), the unitary computer system can be reset via hardware (e.g. the power and reset buttons). If disabled (value = 3), hardware reset is not allowed. In addition to Enabled and Disabled, other values for the property are also defined - ""Not Implemented"" (5), ""Other"" (1) and ""Unknown"" (2).")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ResetCapabilityValues ResetCapability {
            get {
                if ((curObj["ResetCapability"] == null)) {
                    return ((ResetCapabilityValues)(System.Convert.ToInt32(0)));
                }
                return ((ResetCapabilityValues)(System.Convert.ToInt32(curObj["ResetCapability"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsResetCountNull {
            get {
                if ((curObj["ResetCount"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ResetCount property indicates the number of automatic resets since the last i" +
            "ntentional reset.  A value of -1 indicates that the count is unknown.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public short ResetCount {
            get {
                if ((curObj["ResetCount"] == null)) {
                    return System.Convert.ToInt16(0);
                }
                return ((short)(curObj["ResetCount"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsResetLimitNull {
            get {
                if ((curObj["ResetLimit"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ResetLimit property indicates the number of consecutive time the system reset" +
            " will be attempted. A value of -1 indicates that the limit is unknown")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public short ResetLimit {
            get {
                if ((curObj["ResetLimit"] == null)) {
                    return System.Convert.ToInt16(0);
                }
                return ((short)(curObj["ResetLimit"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"An array (bag) of strings that specify the roles this System plays in the IT-environment. Subclasses of System may override this property to define explicit Roles values. Alternately, a Working Group may describe the heuristics, conventions and guidelines for specifying Roles. For example, for an instance of a networking system, the Roles property might contain the string, 'Switch' or 'Bridge'.")]
        public string[] Roles {
            get {
                return ((string[])(curObj["Roles"]));
            }
            set {
                curObj["Roles"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The Status property is a string indicating the current status of the object. Various operational and non-operational statuses can be defined. Operational statuses are ""OK"", ""Degraded"" and ""Pred Fail"". ""Pred Fail"" indicates that an element may be functioning properly but predicting a failure in the near future. An example is a SMART-enabled hard drive. Non-operational statuses can also be specified. These are ""Error"", ""Starting"", ""Stopping"" and ""Service"". The latter, ""Service"", could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is on-line, yet the managed element is neither ""OK"" nor in one of the other states.")]
        public string Status {
            get {
                return ((string)(curObj["Status"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The SupportContactDescription property is an array that indicates the support con" +
            "tact information for the Win32 computer system.")]
        public string[] SupportContactDescription {
            get {
                return ((string[])(curObj["SupportContactDescription"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSystemStartupDelayNull {
            get {
                if ((curObj["SystemStartupDelay"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The SystemStartupDelay property indicates the time to delay before starting the o" +
            "perating system\n\nNote:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on " +
            "IA64bit machines. This privilege is not required for 32bit systems.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort SystemStartupDelay {
            get {
                if ((curObj["SystemStartupDelay"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["SystemStartupDelay"]));
            }
            set {
                curObj["SystemStartupDelay"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The SystemStartupOptions property array indicates the options for starting up the computer system. Note that this property is not writable on IA64 bit machines. 
Constraints: Must have a value.

Note:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on IA64bit machines. This privilege is not required for other systems.")]
        public string[] SystemStartupOptions {
            get {
                return ((string[])(curObj["SystemStartupOptions"]));
            }
            set {
                curObj["SystemStartupOptions"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSystemStartupSettingNull {
            get {
                if ((curObj["SystemStartupSetting"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The SystemStartupSetting property indicates the index of the default start profile. This value is 'calculated' so that it usually returns zero (0) because at write-time, the profile string is physically moved to the top of the list. (This is how Windows NT determines which value is the default.)

Note:  The SE_SYSTEM_ENVIRONMENT_NAME privilege is required on IA64bit machines. This privilege is not required for 32bit systems.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public byte SystemStartupSetting {
            get {
                if ((curObj["SystemStartupSetting"] == null)) {
                    return System.Convert.ToByte(0);
                }
                return ((byte)(curObj["SystemStartupSetting"]));
            }
            set {
                curObj["SystemStartupSetting"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The SystemType property indicates the type of system running on the Win32 compute" +
            "r.\nConstraints: Must have a value")]
        public string SystemType {
            get {
                return ((string)(curObj["SystemType"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsThermalStateNull {
            get {
                if ((curObj["ThermalState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The ThermalState property identifies the enclosure\'s thermal state when last boot" +
            "ed.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ThermalStateValues ThermalState {
            get {
                if ((curObj["ThermalState"] == null)) {
                    return ((ThermalStateValues)(System.Convert.ToInt32(0)));
                }
                return ((ThermalStateValues)(System.Convert.ToInt32(curObj["ThermalState"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTotalPhysicalMemoryNull {
            get {
                if ((curObj["TotalPhysicalMemory"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The TotalPhysicalMemory property indicates the total size of physical memory.\nExa" +
            "mple: 67108864")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong TotalPhysicalMemory {
            get {
                if ((curObj["TotalPhysicalMemory"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["TotalPhysicalMemory"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The UserName property indicates the name of the currently-logged-on user.\nConstra" +
            "ints: Must have a value. \nExample: johnsmith")]
        public string UserName {
            get {
                return ((string)(curObj["UserName"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsWakeUpTypeNull {
            get {
                if ((curObj["WakeUpType"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The WakeUpType property indicates the event that caused the system to power up.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public WakeUpTypeValues WakeUpType {
            get {
                if ((curObj["WakeUpType"] == null)) {
                    return ((WakeUpTypeValues)(System.Convert.ToInt32(9)));
                }
                return ((WakeUpTypeValues)(System.Convert.ToInt32(curObj["WakeUpType"])));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Workgroup property contains the name of the workgroup.  This value is only va" +
            "lid if the PartOfDomain property is FALSE.")]
        public string Workgroup {
            get {
                return ((string)(curObj["Workgroup"]));
            }
            set {
                curObj["Workgroup"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions OptionsParam) {
            if (((path != null) 
                        && (string.Compare(path.ClassName, this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                return CheckIfProperClass(new System.Management.ManagementObject(mgmtScope, path, OptionsParam));
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementBaseObject theObj) {
            if (((theObj != null) 
                        && (string.Compare(((string)(theObj["__CLASS"])), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                System.Array parentClasses = ((System.Array)(theObj["__DERIVATION"]));
                if ((parentClasses != null)) {
                    int count = 0;
                    for (count = 0; (count < parentClasses.Length); count = (count + 1)) {
                        if ((string.Compare(((string)(parentClasses.GetValue(count))), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        private bool ShouldSerializeAdminPasswordStatus() {
            if ((this.IsAdminPasswordStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutomaticResetBootOption() {
            if ((this.IsAutomaticResetBootOptionNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAutomaticResetBootOption() {
            curObj["AutomaticResetBootOption"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAutomaticResetCapability() {
            if ((this.IsAutomaticResetCapabilityNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeBootOptionOnLimit() {
            if ((this.IsBootOptionOnLimitNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeBootOptionOnWatchDog() {
            if ((this.IsBootOptionOnWatchDogNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeBootROMSupported() {
            if ((this.IsBootROMSupportedNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeChassisBootupState() {
            if ((this.IsChassisBootupStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeCurrentTimeZone() {
            if ((this.IsCurrentTimeZoneNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCurrentTimeZone() {
            curObj["CurrentTimeZone"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDaylightInEffect() {
            if ((this.IsDaylightInEffectNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeDomainRole() {
            if ((this.IsDomainRoleNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeEnableDaylightSavingsTime() {
            if ((this.IsEnableDaylightSavingsTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEnableDaylightSavingsTime() {
            curObj["EnableDaylightSavingsTime"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeFrontPanelResetStatus() {
            if ((this.IsFrontPanelResetStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeInfraredSupported() {
            if ((this.IsInfraredSupportedNull == false)) {
                return true;
            }
            return false;
        }
        
        // Converts a given datetime in DMTF format to System.DateTime object.
        static System.DateTime ToDateTime(string dmtfDate) {
            System.DateTime initializer = System.DateTime.MinValue;
            int year = initializer.Year;
            int month = initializer.Month;
            int day = initializer.Day;
            int hour = initializer.Hour;
            int minute = initializer.Minute;
            int second = initializer.Second;
            long ticks = 0;
            string dmtf = dmtfDate;
            System.DateTime datetime = System.DateTime.MinValue;
            string tempString = string.Empty;
            if ((dmtf == null)) {
                throw new System.ArgumentOutOfRangeException();
            }
            if ((dmtf.Length == 0)) {
                throw new System.ArgumentOutOfRangeException();
            }
            if ((dmtf.Length != 25)) {
                throw new System.ArgumentOutOfRangeException();
            }
            try {
                tempString = dmtf.Substring(0, 4);
                if (("****" != tempString)) {
                    year = int.Parse(tempString);
                }
                tempString = dmtf.Substring(4, 2);
                if (("**" != tempString)) {
                    month = int.Parse(tempString);
                }
                tempString = dmtf.Substring(6, 2);
                if (("**" != tempString)) {
                    day = int.Parse(tempString);
                }
                tempString = dmtf.Substring(8, 2);
                if (("**" != tempString)) {
                    hour = int.Parse(tempString);
                }
                tempString = dmtf.Substring(10, 2);
                if (("**" != tempString)) {
                    minute = int.Parse(tempString);
                }
                tempString = dmtf.Substring(12, 2);
                if (("**" != tempString)) {
                    second = int.Parse(tempString);
                }
                tempString = dmtf.Substring(15, 6);
                if (("******" != tempString)) {
                    ticks = (long.Parse(tempString) * ((long)((System.TimeSpan.TicksPerMillisecond / 1000))));
                }
                if (((((((((year < 0) 
                            || (month < 0)) 
                            || (day < 0)) 
                            || (hour < 0)) 
                            || (minute < 0)) 
                            || (minute < 0)) 
                            || (second < 0)) 
                            || (ticks < 0))) {
                    throw new System.ArgumentOutOfRangeException();
                }
            }
            catch (System.Exception e) {
                throw new System.ArgumentOutOfRangeException(null, e.Message);
            }
            datetime = new System.DateTime(year, month, day, hour, minute, second, 0);
            datetime = datetime.AddTicks(ticks);
            System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(datetime);
            int UTCOffset = 0;
            int OffsetToBeAdjusted = 0;
            long OffsetMins = ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)));
            tempString = dmtf.Substring(22, 3);
            if ((tempString != "******")) {
                tempString = dmtf.Substring(21, 4);
                try {
                    UTCOffset = int.Parse(tempString);
                }
                catch (System.Exception e) {
                    throw new System.ArgumentOutOfRangeException(null, e.Message);
                }
                OffsetToBeAdjusted = ((int)((OffsetMins - UTCOffset)));
                datetime = datetime.AddMinutes(((double)(OffsetToBeAdjusted)));
            }
            return datetime;
        }
        
        // Converts a given System.DateTime object to DMTF datetime format.
        static string ToDmtfDateTime(System.DateTime date) {
            string utcString = string.Empty;
            System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(date);
            long OffsetMins = ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)));
            if ((System.Math.Abs(OffsetMins) > 999)) {
                date = date.ToUniversalTime();
                utcString = "+000";
            }
            else {
                if ((tickOffset.Ticks >= 0)) {
                    utcString = string.Concat("+", ((System.Int64 )((tickOffset.Ticks / System.TimeSpan.TicksPerMinute))).ToString().PadLeft(3, '0'));
                }
                else {
                    string strTemp = ((System.Int64 )(OffsetMins)).ToString();
                    utcString = string.Concat("-", strTemp.Substring(1, (strTemp.Length - 1)).PadLeft(3, '0'));
                }
            }
            string dmtfDateTime = ((System.Int32 )(date.Year)).ToString().PadLeft(4, '0');
            dmtfDateTime = string.Concat(dmtfDateTime, ((System.Int32 )(date.Month)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((System.Int32 )(date.Day)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((System.Int32 )(date.Hour)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((System.Int32 )(date.Minute)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((System.Int32 )(date.Second)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ".");
            System.DateTime dtTemp = new System.DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 0);
            long microsec = ((long)((((date.Ticks - dtTemp.Ticks) 
                        * 1000) 
                        / System.TimeSpan.TicksPerMillisecond)));
            string strMicrosec = ((System.Int64 )(microsec)).ToString();
            if ((strMicrosec.Length > 6)) {
                strMicrosec = strMicrosec.Substring(0, 6);
            }
            dmtfDateTime = string.Concat(dmtfDateTime, strMicrosec.PadLeft(6, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, utcString);
            return dmtfDateTime;
        }
        
        private bool ShouldSerializeInstallDate() {
            if ((this.IsInstallDateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeKeyboardPasswordStatus() {
            if ((this.IsKeyboardPasswordStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeNetworkServerModeEnabled() {
            if ((this.IsNetworkServerModeEnabledNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeNumberOfProcessors() {
            if ((this.IsNumberOfProcessorsNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePartOfDomain() {
            if ((this.IsPartOfDomainNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePauseAfterReset() {
            if ((this.IsPauseAfterResetNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePowerManagementSupported() {
            if ((this.IsPowerManagementSupportedNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePowerOnPasswordStatus() {
            if ((this.IsPowerOnPasswordStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePowerState() {
            if ((this.IsPowerStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializePowerSupplyState() {
            if ((this.IsPowerSupplyStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeResetCapability() {
            if ((this.IsResetCapabilityNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeResetCount() {
            if ((this.IsResetCountNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeResetLimit() {
            if ((this.IsResetLimitNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetRoles() {
            curObj["Roles"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeSystemStartupDelay() {
            if ((this.IsSystemStartupDelayNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetSystemStartupDelay() {
            curObj["SystemStartupDelay"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetSystemStartupOptions() {
            curObj["SystemStartupOptions"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeSystemStartupSetting() {
            if ((this.IsSystemStartupSettingNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetSystemStartupSetting() {
            curObj["SystemStartupSetting"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeThermalState() {
            if ((this.IsThermalStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeTotalPhysicalMemory() {
            if ((this.IsTotalPhysicalMemoryNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeWakeUpType() {
            if ((this.IsWakeUpTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetWorkgroup() {
            curObj["Workgroup"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject() {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject(System.Management.PutOptions putOptions) {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put(putOptions);
            }
        }
        
        private void Initialize() {
            AutoCommitProp = true;
            isEmbedded = false;
        }
        
        private static string ConstructPath(string keyName) {
            string strPath = "ROOT\\CIMV2:Win32_ComputerSystem";
            strPath = string.Concat(strPath, string.Concat(".Name=", string.Concat("\"", string.Concat(keyName, "\""))));
            return strPath;
        }
        
        private void InitializeObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            Initialize();
            if ((path != null)) {
                if ((CheckIfProperClass(mgmtScope, path, getOptions) != true)) {
                    throw new System.ArgumentException("Class name does not match.");
                }
            }
            PrivateLateBoundObject = new System.Management.ManagementObject(mgmtScope, path, getOptions);
            PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
            curObj = PrivateLateBoundObject;
        }
        
        // Different overloads of GetInstances() help in enumerating instances of the WMI class.
        public static ComputerSystemCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static ComputerSystemCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static ComputerSystemCollection GetInstances(System.String [] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static ComputerSystemCollection GetInstances(string condition, System.String [] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static ComputerSystemCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\CIMV2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementPath pathObj = new System.Management.ManagementPath();
            pathObj.ClassName = "Win32_ComputerSystem";
            pathObj.NamespacePath = "root\\CIMV2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new ComputerSystemCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static ComputerSystemCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static ComputerSystemCollection GetInstances(System.Management.ManagementScope mgmtScope, System.String [] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static ComputerSystemCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, System.String [] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\CIMV2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Win32_ComputerSystem", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new ComputerSystemCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static ComputerSystem CreateInstance() {
            System.Management.ManagementScope mgmtScope = null;
            if ((statMgmtScope == null)) {
                mgmtScope = new System.Management.ManagementScope();
                mgmtScope.Path.NamespacePath = CreatedWmiNamespace;
            }
            else {
                mgmtScope = statMgmtScope;
            }
            System.Management.ManagementPath mgmtPath = new System.Management.ManagementPath(CreatedClassName);
            System.Management.ManagementClass tmpMgmtClass = new System.Management.ManagementClass(mgmtScope, mgmtPath, null);
            return new ComputerSystem(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public uint JoinDomainOrWorkgroup(string AccountOU, uint FJoinOptions, string Name, string Password, string UserName) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("JoinDomainOrWorkgroup");
                inParams["AccountOU"] = ((System.String )(AccountOU));
                inParams["FJoinOptions"] = ((System.UInt32 )(FJoinOptions));
                inParams["Name"] = ((System.String )(Name));
                inParams["Password"] = ((System.String )(Password));
                inParams["UserName"] = ((System.String )(UserName));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("JoinDomainOrWorkgroup", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint Rename(string Name, string Password, string UserName) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("Rename");
                inParams["Name"] = ((System.String )(Name));
                inParams["Password"] = ((System.String )(Password));
                inParams["UserName"] = ((System.String )(UserName));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("Rename", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint SetPowerState(ushort PowerState, System.DateTime Time) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetPowerState");
                inParams["PowerState"] = ((System.UInt16 )(PowerState));
                inParams["Time"] = ToDmtfDateTime(((System.DateTime)(Time)));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetPowerState", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint UnjoinDomainOrWorkgroup(uint FUnjoinOptions, string Password, string UserName) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("UnjoinDomainOrWorkgroup");
                inParams["FUnjoinOptions"] = ((System.UInt32 )(FUnjoinOptions));
                inParams["Password"] = ((System.String )(Password));
                inParams["UserName"] = ((System.String )(UserName));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("UnjoinDomainOrWorkgroup", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public enum AdminPasswordStatusValues {
            
            Disabled = 0,
            
            Enabled = 1,
            
            Not_Implemented = 2,
            
            Unknown0 = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        public enum BootOptionOnLimitValues {
            
            Reserved = 0,
            
            Operating_system = 1,
            
            System_utilities = 2,
            
            Do_not_reboot = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        public enum BootOptionOnWatchDogValues {
            
            Reserved = 0,
            
            Operating_system = 1,
            
            System_utilities = 2,
            
            Do_not_reboot = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        public enum ChassisBootupStateValues {
            
            Other0 = 1,
            
            Unknown0 = 2,
            
            Safe = 3,
            
            Warning = 4,
            
            Critical = 5,
            
            Non_recoverable = 6,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum DomainRoleValues {
            
            Standalone_Workstation = 0,
            
            Member_Workstation = 1,
            
            Standalone_Server = 2,
            
            Member_Server = 3,
            
            Backup_Domain_Controller = 4,
            
            Primary_Domain_Controller = 5,
            
            NULL_ENUM_VALUE = 6,
        }
        
        public enum FrontPanelResetStatusValues {
            
            Disabled = 0,
            
            Enabled = 1,
            
            Not_Implemented = 2,
            
            Unknown0 = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        public enum KeyboardPasswordStatusValues {
            
            Disabled = 0,
            
            Enabled = 1,
            
            Not_Implemented = 2,
            
            Unknown0 = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        public enum PowerManagementCapabilitiesValues {
            
            Unknown0 = 0,
            
            Not_Supported = 1,
            
            Disabled = 2,
            
            Enabled = 3,
            
            Power_Saving_Modes_Entered_Automatically = 4,
            
            Power_State_Settable = 5,
            
            Power_Cycling_Supported = 6,
            
            Timed_Power_On_Supported = 7,
            
            NULL_ENUM_VALUE = 8,
        }
        
        public enum PowerOnPasswordStatusValues {
            
            Disabled = 0,
            
            Enabled = 1,
            
            Not_Implemented = 2,
            
            Unknown0 = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        public enum PowerStateValues {
            
            Unknown0 = 0,
            
            Full_Power = 1,
            
            Power_Save_Low_Power_Mode = 2,
            
            Power_Save_Standby = 3,
            
            Power_Save_Unknown = 4,
            
            Power_Cycle = 5,
            
            Power_Off = 6,
            
            Power_Save_Warning = 7,
            
            Power_Save_Hibernate = 8,
            
            Power_Save_Soft_Off = 9,
            
            NULL_ENUM_VALUE = 10,
        }
        
        public enum PowerSupplyStateValues {
            
            Other0 = 1,
            
            Unknown0 = 2,
            
            Safe = 3,
            
            Warning = 4,
            
            Critical = 5,
            
            Non_recoverable = 6,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum ResetCapabilityValues {
            
            Other0 = 1,
            
            Unknown0 = 2,
            
            Disabled = 3,
            
            Enabled = 4,
            
            Not_Implemented = 5,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum ThermalStateValues {
            
            Other0 = 1,
            
            Unknown0 = 2,
            
            Safe = 3,
            
            Warning = 4,
            
            Critical = 5,
            
            Non_recoverable = 6,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum WakeUpTypeValues {
            
            Reserved = 0,
            
            Other0 = 1,
            
            Unknown0 = 2,
            
            APM_Timer = 3,
            
            Modem_Ring = 4,
            
            LAN_Remote = 5,
            
            Power_Switch = 6,
            
            PCI_PME_ = 7,
            
            AC_Power_Restored = 8,
            
            NULL_ENUM_VALUE = 9,
        }
        
        // Enumerator implementation for enumerating instances of the class.
        public class ComputerSystemCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public ComputerSystemCollection(ManagementObjectCollection objCollection) {
                privColObj = objCollection;
            }
            
            public virtual int Count {
                get {
                    return privColObj.Count;
                }
            }
            
            public virtual bool IsSynchronized {
                get {
                    return privColObj.IsSynchronized;
                }
            }
            
            public virtual object SyncRoot {
                get {
                    return this;
                }
            }
            
            public virtual void CopyTo(System.Array array, int index) {
                privColObj.CopyTo(array, index);
                int nCtr;
                for (nCtr = 0; (nCtr < array.Length); nCtr = (nCtr + 1)) {
                    array.SetValue(new ComputerSystem(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new ComputerSystemEnumerator(privColObj.GetEnumerator());
            }
            
            public class ComputerSystemEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public ComputerSystemEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new ComputerSystem(((System.Management.ManagementObject)(privObjEnum.Current)));
                    }
                }
                
                public virtual bool MoveNext() {
                    return privObjEnum.MoveNext();
                }
                
                public virtual void Reset() {
                    privObjEnum.Reset();
                }
            }
        }
        
        // TypeConverter to handle null values for ValueType properties
        public class WMIValueTypeConverter : TypeConverter {
            
            private TypeConverter baseConverter;
            
            private System.Type baseType;
            
            public WMIValueTypeConverter(System.Type inBaseType) {
                baseConverter = TypeDescriptor.GetConverter(inBaseType);
                baseType = inBaseType;
            }
            
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type srcType) {
                return baseConverter.CanConvertFrom(context, srcType);
            }
            
            public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) {
                return baseConverter.CanConvertTo(context, destinationType);
            }
            
            public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
                return baseConverter.ConvertFrom(context, culture, value);
            }
            
            public override object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary dictionary) {
                return baseConverter.CreateInstance(context, dictionary);
            }
            
            public override bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetCreateInstanceSupported(context);
            }
            
            public override PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributeVar) {
                return baseConverter.GetProperties(context, value, attributeVar);
            }
            
            public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetPropertiesSupported(context);
            }
            
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValues(context);
            }
            
            public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesExclusive(context);
            }
            
            public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesSupported(context);
            }
            
            public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) {
                if ((baseType.BaseType == typeof(System.Enum))) {
                    if ((value.GetType() == destinationType)) {
                        return value;
                    }
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return  "NULL_ENUM_VALUE" ;
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((baseType == typeof(bool)) 
                            && (baseType.BaseType == typeof(System.ValueType)))) {
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return "";
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((context != null) 
                            && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                    return "";
                }
                return baseConverter.ConvertTo(context, culture, value, destinationType);
            }
        }
        
        // Embedded class to represent WMI system Properties.
        [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
        public class ManagementSystemProperties {
            
            private System.Management.ManagementBaseObject PrivateLateBoundObject;
            
            public ManagementSystemProperties(System.Management.ManagementBaseObject ManagedObject) {
                PrivateLateBoundObject = ManagedObject;
            }
            
            [Browsable(true)]
            public int GENUS {
                get {
                    return ((int)(PrivateLateBoundObject["__GENUS"]));
                }
            }
            
            [Browsable(true)]
            public string CLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__CLASS"]));
                }
            }
            
            [Browsable(true)]
            public string SUPERCLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__SUPERCLASS"]));
                }
            }
            
            [Browsable(true)]
            public string DYNASTY {
                get {
                    return ((string)(PrivateLateBoundObject["__DYNASTY"]));
                }
            }
            
            [Browsable(true)]
            public string RELPATH {
                get {
                    return ((string)(PrivateLateBoundObject["__RELPATH"]));
                }
            }
            
            [Browsable(true)]
            public int PROPERTY_COUNT {
                get {
                    return ((int)(PrivateLateBoundObject["__PROPERTY_COUNT"]));
                }
            }
            
            [Browsable(true)]
            public string[] DERIVATION {
                get {
                    return ((string[])(PrivateLateBoundObject["__DERIVATION"]));
                }
            }
            
            [Browsable(true)]
            public string SERVER {
                get {
                    return ((string)(PrivateLateBoundObject["__SERVER"]));
                }
            }
            
            [Browsable(true)]
            public string NAMESPACE {
                get {
                    return ((string)(PrivateLateBoundObject["__NAMESPACE"]));
                }
            }
            
            [Browsable(true)]
            public string PATH {
                get {
                    return ((string)(PrivateLateBoundObject["__PATH"]));
                }
            }
        }
    }
}
