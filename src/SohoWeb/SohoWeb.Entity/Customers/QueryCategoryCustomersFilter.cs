using SohoWeb.Entity.Enums;

namespace SohoWeb.Entity.Customers
{
    public class QueryCategoryCustomersFilter : FilterBase
    {
        public CustomerQueryCategory Category { get; set; }
    }
}
