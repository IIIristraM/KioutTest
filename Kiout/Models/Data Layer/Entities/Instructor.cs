using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kiout.Models
{
    public class Instructor
    {
        private ICollection<Group> _groups;
        private ICollection<Organization> _organizations;
        public virtual int Id { get; set; }

        [DisplayName("Преподаватель")]
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual ICollection<Group> Groups
        {
            get
            {
                return _groups ?? (_groups = (new HashSet<Group>()));
            }
        }
        public virtual ICollection<Organization> Organizations
        {
            get
            {
                return _organizations ?? (_organizations = (new HashSet<Organization>()));
            }
        }
    }
}
