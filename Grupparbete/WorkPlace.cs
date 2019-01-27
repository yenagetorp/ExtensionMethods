using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete
{
    class WorkPlace
    {
        public WorkPlace(string companyName, int workPlaceID)
        {
            CompanyName = companyName;
            WorkPlaceID = workPlaceID;
        }

        public string CompanyName { get; set; }
        public int WorkPlaceID { get; set; }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
