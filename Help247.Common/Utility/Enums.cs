using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public enum HelperCategory 
        {
            [Description("Category not assigned")]
            Nonee,
            [Description("CCTV Installation and Fixing")]
            Cctv,
            [Description("Network Planning and Troubleshooting")]
            NetworkPlanning,
            [Description("PABX - Private Automatic Issues")]
            Pabx,
            [Description("Cisco Routing - Service Maintenance")]
            Cisco,
            [Description("IT and other projects")]
            IT,
            [Description("Office Relocation IT Setup")]
            OfficeRelocation,
            [Description("Office New IT Setup")]
            OfficeNewSetup,
            [Description("Basic Hardware Repairing")]
            HardwareRepair,

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
