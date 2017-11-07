using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Enumerators
{
    public enum UserTypeEnum
    {
        [Description("Applicant User Type")]
        Applicant = 1,
        [Description("Company Manager User Type")]
        CompanyManager = 2
    }
}
