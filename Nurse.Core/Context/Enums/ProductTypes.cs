namespace Nurse.Core.Context.Enums
{
	public enum ProductTypes : uint
	{
		// Windows Client Editions
		WINDOWS_ULTIMATE = 0x00000001,               // Windows Ultimate Edition
		WINDOWS_HOME_BASIC = 0x00000002,             // Windows Home Basic Edition
		WINDOWS_HOME_PREMIUM = 0x00000003,           // Windows Home Premium Edition
		WINDOWS_ENTERPRISE = 0x00000004,             // Windows Enterprise Edition
		WINDOWS_HOME_BASIC_N = 0x00000005,           // Windows Home Basic N Edition
		WINDOWS_BUSINESS = 0x00000006,               // Windows Business Edition
		WINDOWS_STANDARD_SERVER = 0x00000007,        // Windows Standard Server Edition
		WINDOWS_DATACENTER_SERVER = 0x00000008,      // Windows Datacenter Server Edition
		WINDOWS_SMALLBUSINESS_SERVER = 0x00000009,   // Windows Small Business Server
		WINDOWS_ENTERPRISE_SERVER = 0x0000000A,      // Windows Enterprise Server
		WINDOWS_STARTER = 0x0000000B,                // Windows Starter Edition

		// Windows Client - Professional, Enterprise, Education
		WINDOWS_CLIENT_PROFESSIONAL = 0x00000030,           // Windows 10/11 Pro Edition
		WINDOWS_CLIENT_ENTERPRISE_N = 0x0000001B,           // Windows Enterprise N Edition
		WINDOWS_CLIENT_EDUCATION = 0x00000079,              // Windows 10/11 Education Edition
		WINDOWS_CLIENT_PROFESSIONAL_N = 0x00000031,         // Windows 10/11 Pro N Edition
		WINDOWS_CLIENT_PROFESSIONAL_WMC = 0x00000067,       // Windows Professional with Media Center
		WINDOWS_CLIENT_PRO_WORKSTATION = 0x000000A1,        // Windows 10/11 Pro for Workstations Edition
		WINDOWS_CLIENT_PRO_EDUCATION = 0x0000007A,          // Windows 10/11 Pro Education Edition
		WINDOWS_CLIENT_EDUCATION_N = 0x0000007C,            // Windows 10/11 Education N Edition
		WINDOWS_CLIENT_PRO_WORKSTATION_N = 0x000000A2,      // Windows 10/11 Pro for Workstations N Edition
		WINDOWS_CLIENT_PRO_EDUCATION_N = 0x0000007B,        // Windows 10/11 Pro Education N Edition

		// Windows Enterprise LTSB/LTSC
		WINDOWS_CLIENT_ENTERPRISE_LTSB = 0x0000007F,        // Windows 10 Enterprise LTSB (Long-Term Servicing Branch)
		WINDOWS_CLIENT_ENTERPRISE_LTSB_N = 0x00000081,      // Windows 10 Enterprise LTSB N (Long-Term Servicing Branch)
		WINDOWS_CLIENT_ENTERPRISE_LTSC = 0x00000087,        // Windows 10/11 Enterprise LTSC (Long-Term Servicing Channel)
		WINDOWS_CLIENT_ENTERPRISE_LTSC_N = 0x00000088,      // Windows 10/11 Enterprise LTSC N (Long-Term Servicing Channel)

		// Windows Server Editions
		WINDOWS_DATACENTER_SERVER_CORE = 0x0000000C, // Windows Server Datacenter Edition (Core installation)
		WINDOWS_STANDARD_SERVER_CORE = 0x0000000D,   // Windows Server Standard Edition (Core installation)
		WINDOWS_WEB_SERVER = 0x00000011,             // Windows Web Server Edition
		WINDOWS_STORAGE_SERVER_ENTERPRISE = 0x00000017, // Windows Storage Server Enterprise Edition
		WINDOWS_SERVER_2016_DATACENTER = 0x00000050, // Windows Server 2016 Datacenter Edition
		WINDOWS_SERVER_2016_STANDARD = 0x00000051,   // Windows Server 2016 Standard Edition
		WINDOWS_SERVER_2022_DATACENTER = 0x000000B3, // Windows Server 2022 Datacenter Edition
		WINDOWS_SERVER_2022_STANDARD = 0x000000B4,   // Windows Server 2022 Standard Edition

		// Other Windows Editions
		WINDOWS_CLIENT_HOME = 0x00000002,                   // Windows 10/11 Home Edition
		WINDOWS_CLIENT_HOME_N = 0x00000082,                 // Windows 10/11 Home N Edition
		WINDOWS_CLIENT_S = 0x000000B2,                  // Windows 10/11 S Mode (Cloud)
		WINDOWS_CLIENT_S_N = 0x000000B3,                // Windows 10/11 S Mode N (Cloud)
		WINDOWS_MULTIPOINT_STANDARD_SERVER = 0x0000004D, // Windows MultiPoint Server Standard
		WINDOWS_MULTIPOINT_PREMIUM_SERVER = 0x0000004E, // Windows MultiPoint Server Premium

		// Older Editions (for reference)
		WINDOWS_HOME_PREMIUM_N = 0x0000001A,         // Windows Home Premium N Edition (older)
		WINDOWS_BUSINESS_N = 0x00000010,             // Windows Business N Edition (older)
		WINDOWS_STARTER_N = 0x0000002F,              // Windows Starter N Edition (older)
		WINDOWS_ULTIMATE_N = 0x0000001C,             // Windows Ultimate N Edition (older)
		WINDOWS_HOME_SERVER = 0x00000013,            // Windows Home Server Edition
	}
}
