using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
namespace Rad301Semester1fe2019.BusinessDomain.Classes.Classes
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        public int MemberID { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
        public int LoanIssueDate { get; set; }
    }
}
