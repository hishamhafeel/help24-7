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

        
        public enum TicketStatus : byte
        {
            [Description("Ticket not placed")]
            None = 0,
            [Description("Ticket has been reqested")]
            TicketRequest = 1,
            [Description("Ticket has been approved")]
            TicketApproval = 2,
            [Description("Ticket has been terminated")]
            TicketTerminate = 3
        }

        public enum UserType : int
        {
            Admin = 1,
            Helper = 2,
            Customer = 3
        }

        public enum HelpCentre : int
        {
            TermsAndConditions = 1,
            PrivacyPolicy = 2,
            FAQ = 3
        }
    }
}
