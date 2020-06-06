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
            None = 0,
            [Description("Help has been reqested")]
            HelpRequest = 1,
            [Description("Help is under process")]
            HelpProcess = 2,
            [Description("Help has been completed successfully")]
            HelpComplete = 3,
            [Description("Help has been cancelled")]
            HelpCancel = 4
        }

        public enum UserType : int
        {
            Admin = 1,
            Helper = 2,
            Customer = 3,
            SuperAdmin = 4

        }

        public enum HelpCentre : int
        {
            TermsAndConditions = 1,
            PrivacyPolicy = 2,
            FAQ = 3
        }
    }
}
