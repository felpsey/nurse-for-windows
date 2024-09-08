namespace Nurse.Core.Context.Enums
{
	public enum ProductTypes : uint
	{
		// Windows Client Editions
		PRODUCT_ULTIMATE = 0x00000001,               // Windows Ultimate Edition
		PRODUCT_HOME_BASIC = 0x00000002,             // Windows Home Basic Edition
		PRODUCT_HOME_PREMIUM = 0x00000003,           // Windows Home Premium Edition
		PRODUCT_ENTERPRISE = 0x00000004,             // Windows Enterprise Edition
		PRODUCT_HOME_BASIC_N = 0x00000005,           // Windows Home Basic N Edition
		PRODUCT_BUSINESS = 0x00000006,               // Windows Business Edition
		PRODUCT_STANDARD_SERVER = 0x00000007,        // Windows Standard Server Edition
		PRODUCT_DATACENTER_SERVER = 0x00000008,      // Windows Datacenter Server Edition
		PRODUCT_SMALLBUSINESS_SERVER = 0x00000009,   // Windows Small Business Server
		PRODUCT_ENTERPRISE_SERVER = 0x0000000A,      // Windows Enterprise Server
		PRODUCT_STARTER = 0x0000000B,                // Windows Starter Edition

		// Windows Client - Professional, Enterprise, Education
		PRODUCT_PROFESSIONAL = 0x00000030,           // Windows 10/11 Pro Edition
		PRODUCT_ENTERPRISE_N = 0x0000001B,           // Windows Enterprise N Edition
		PRODUCT_EDUCATION = 0x00000079,              // Windows 10/11 Education Edition
		PRODUCT_PROFESSIONAL_N = 0x00000031,         // Windows 10/11 Pro N Edition
		PRODUCT_PROFESSIONAL_WMC = 0x00000067,       // Windows Professional with Media Center
		PRODUCT_PRO_WORKSTATION = 0x000000A1,        // Windows 10/11 Pro for Workstations Edition
		PRODUCT_PRO_EDUCATION = 0x0000007A,          // Windows 10/11 Pro Education Edition
		PRODUCT_EDUCATION_N = 0x0000007C,            // Windows 10/11 Education N Edition
		PRODUCT_PRO_WORKSTATION_N = 0x000000A2,      // Windows 10/11 Pro for Workstations N Edition
		PRODUCT_PRO_EDUCATION_N = 0x0000007B,        // Windows 10/11 Pro Education N Edition

		// Windows Enterprise LTSB/LTSC
		PRODUCT_ENTERPRISE_LTSB = 0x0000007F,        // Windows 10 Enterprise LTSB (Long-Term Servicing Branch)
		PRODUCT_ENTERPRISE_LTSB_N = 0x00000081,      // Windows 10 Enterprise LTSB N (Long-Term Servicing Branch)
		PRODUCT_ENTERPRISE_LTSC = 0x00000087,        // Windows 10/11 Enterprise LTSC (Long-Term Servicing Channel)
		PRODUCT_ENTERPRISE_LTSC_N = 0x00000088,      // Windows 10/11 Enterprise LTSC N (Long-Term Servicing Channel)

		// Windows Server Editions
		PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C, // Windows Server Datacenter Edition (Core installation)
		PRODUCT_STANDARD_SERVER_CORE = 0x0000000D,   // Windows Server Standard Edition (Core installation)
		PRODUCT_WEB_SERVER = 0x00000011,             // Windows Web Server Edition
		PRODUCT_STORAGE_SERVER_ENTERPRISE = 0x00000017, // Windows Storage Server Enterprise Edition
		PRODUCT_WINDOWS_SERVER_2016_DATACENTER = 0x00000050, // Windows Server 2016 Datacenter Edition
		PRODUCT_WINDOWS_SERVER_2016_STANDARD = 0x00000051,   // Windows Server 2016 Standard Edition
		PRODUCT_WINDOWS_SERVER_2022_DATACENTER = 0x000000B3, // Windows Server 2022 Datacenter Edition
		PRODUCT_WINDOWS_SERVER_2022_STANDARD = 0x000000B4,   // Windows Server 2022 Standard Edition

		// Other Windows Editions
		PRODUCT_HOME = 0x00000002,                   // Windows 10/11 Home Edition
		PRODUCT_HOME_N = 0x00000082,                 // Windows 10/11 Home N Edition
		PRODUCT_CLOUD = 0x000000B2,                  // Windows 10/11 S Mode (Cloud)
		PRODUCT_CLOUD_N = 0x000000B3,                // Windows 10/11 S Mode N (Cloud)
		PRODUCT_MULTIPOINT_STANDARD_SERVER = 0x0000004D, // Windows MultiPoint Server Standard
		PRODUCT_MULTIPOINT_PREMIUM_SERVER = 0x0000004E, // Windows MultiPoint Server Premium

		// Older Editions (for reference)
		PRODUCT_HOME_PREMIUM_N = 0x0000001A,         // Windows Home Premium N Edition (older)
		PRODUCT_BUSINESS_N = 0x00000010,             // Windows Business N Edition (older)
		PRODUCT_STARTER_N = 0x0000002F,              // Windows Starter N Edition (older)
		PRODUCT_ULTIMATE_N = 0x0000001C,             // Windows Ultimate N Edition (older)
		PRODUCT_HOME_SERVER = 0x00000013,            // Windows Home Server Edition
	}
}
