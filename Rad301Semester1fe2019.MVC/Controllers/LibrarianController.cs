using Rad301Semester1fe2019.MVC.Models;
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
        public ActionResult LoanBook()
        {
            return View(new CreateLoanModel());
        }
        [HttpPost]
        public ActionResult Create(CreateLoanModel loan)
        {
            var context = new BusinessDomain.Classes.Context();
            int memberID = context.Members.ToList().Find(member => member.FirstName == loan.FirstName && member.LastName == loan.LastName).MemberID;
            int bookID = context.Books.ToList().Find(book => book.Title == loan.BookTitle).BookID;
            context.Loans.Add(new BusinessDomain.Classes.Classes.Loan
            {
                MemberID = memberID,
                BookID = bookID,
                LoanIssueDate = DateTime.Today
            });
            context.SaveChanges();
            return RedirectToAction("LoanBook");
        }
    }
}