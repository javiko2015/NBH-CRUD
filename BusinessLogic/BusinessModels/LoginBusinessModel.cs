using BusinessLogic.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessModels
{
    public class LoginBusinessModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public int UserType { get; set; }

        public long UserId { get; set; }

        public string CompanyName { get; set; }

        public UserTypeEnum UserTypeEnumerator
        {
            get
            {
                return (UserTypeEnum)UserType;
            }
        }
    }
}
