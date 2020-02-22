using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Help247.Common.Utility
{
    public class Enums
    {
        public enum RecordState : byte
        {
            Active = 1,
            Inactive = 2
        }

        public enum HelperCategory : byte
        {
            [Description("Category not assigned")]
            None = 0,
            [Description("CCTV Installation and Fixing")]
            Cctv = 1,
            [Description("Network Planning and Troubleshooting")]
            NetworkPlanning = 2,
            [Description("PABX - Private Automatic Issues")]
            Pabx = 3,
            [Description("Cisco Routing - Service Maintenance")]
            Cisco = 4,
            [Description("IT and other projects")]
            IT = 5,
            [Description("Office Relocation IT Setup")]
            OfficeRelocation = 6,
            [Description("Office New IT Setup")]
            OfficeNewSetup = 7,
            [Description("Basic Hardware Repairing")]
            HardwareRepair = 8,

        }

        public enum TicketStatus : byte
        {
            [Description("Ticket not placed")]
            None = 0,
            [Description("Customer has requested a help")]
            HelpRequest = 1,
            [Description("Helper has accepted the help")]
            HelpAccepted = 2,
            [Description("Help is completed successfully")]
            HelpCompleted = 3
        }

        public enum UserType : byte
        {
            Admin = 1,
            Helper = 2,
            Customer = 3
        }

    }
}
