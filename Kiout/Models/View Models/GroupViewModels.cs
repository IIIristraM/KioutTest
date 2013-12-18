using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kiout.Models
{
    public class GroupInfoViewModel
    {
        public Group Group { get; set; }

        [DisplayName("Количество студентов")]
        public int StudentsCount { get; set; }
    }

    public class AddStudent
    {
        public Group Group { get; set; }
         
        [Required()]
        public int? OrganizationId { get; set; }

        [Required()]
        public int? NewStudentId { get; set; }
    }
}