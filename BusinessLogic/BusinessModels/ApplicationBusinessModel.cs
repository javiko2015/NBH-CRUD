using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessModels
{
    class ApplicationBusinessModel
    {
        public string EmailManager { get; set; }

        public string PositionHired { get; set; }        
       
        public Nullable<System.DateTime> TodayDate { get; set; }
       
        public Nullable<System.DateTime> StartDate { get; set; }

        public string Services { get; set; }

        public string AditionalServices { get; set; }

        public string AccessLevel { get; set; }

        public string AditionalInformation { get; set; }


    }
}
