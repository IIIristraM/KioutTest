using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kiout.Models
{
    public class Group
    {
        private ICollection<Employee> _emoployees;
        public virtual int Id { get; set; }

        [DisplayName("Учебная группа"), Required(AllowEmptyStrings = false)]
        public virtual string Title { get; set; }
        public virtual int InstructorId { get; set; }
        public virtual int CourseId { get; set; }
        public virtual Сourse Сourse { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Employee> Emoployees
        {
            get
            {
                return _emoployees ?? (_emoployees = (new HashSet<Employee>()));
            }
        }
    }
}