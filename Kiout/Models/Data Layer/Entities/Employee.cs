using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kiout.Models
{
    public class Employee
    {
        private ICollection<Group> _groups;
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Group> Groups
        {
            get
            {
                return _groups ?? (_groups = (new HashSet<Group>()));
            }
        }
    }
}