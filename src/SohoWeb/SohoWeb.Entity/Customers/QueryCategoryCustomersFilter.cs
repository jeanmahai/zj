using System;
using System.Runtime.Serialization;

using SohoWeb.Entity.Enums;

namespace SohoWeb.Entity.Customers
{
    [Serializable]
    [DataContract]
    public class QueryCategoryCustomersFilter : FilterBase
    {
        [DataMember]
        public CustomerQueryCategory Category { get; set; }
    }
}
