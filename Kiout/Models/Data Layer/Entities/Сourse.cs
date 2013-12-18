using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kiout.Models
{
    public class Сourse
    {
        private ICollection<Group> _groups;
        public virtual int Id { get; set; }

        [DisplayName("Курс")] 
        public virtual string Title { get; set; }
        public virtual ICollection<Group> Groups
        {
            get
            {
                return _groups ?? (_groups = (new HashSet<Group>()));
            }
        }
    }
}