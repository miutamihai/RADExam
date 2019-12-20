using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rad301Semester1fe2019.MVC.Controllers
{
    public class LibrarianController : Controller
    {
        private List<BusinessDomain.Classes.Classes.Loan> get_general_overdues()
        {
            DateTime today = DateTime.Today;
            List<BusinessDomain.Classes.Classes.Loan> loans = new BusinessDomain.Classes.Context().Loans.ToList();
            foreach(var loan in loans)
            {
                if (loan.LoanIssueDate < today)
                    loans.Remove(loan);
            }
            return loans;
        }
        public ActionResult ListOverdueBooks()
        {
            return View(get_general_overdues());
        }
    }
}