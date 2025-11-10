using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public static class PageFactory
    {

        public static UserControl CreatePage(string pageType)
        {
            switch (pageType.ToLower())
            {
                case "dashboard":
                    return new DashboardPage();
                case "products":
                    return new ProductsPage();
                case "employees":
                    return new EmployeesPage();
                case "transactions":
                    return new TransactionsPage();
                default:
                    throw new ArgumentException("Invalid page type");
            }
        }
    }
}
