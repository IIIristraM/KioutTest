using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kiout.Models
{
    public class Organization
    {
        private ICollection<Employee> _emoployees;
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Inn { get; set; }
        public virtual int? InstructorId { get; set; }
        public virtual Instructor Instrictor { get; set; }
        public virtual ICollection<Employee> Emoployees
        {
            get
            {
                return _emoployees ?? (_emoployees = (new HashSet<Employee>()));
            }
        }
    }
}