using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kiout.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Kiout.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        private IDbService _service;

        public OrganizationController(IDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> GetPossibleStudents(int organizationId, int groupId)
        {
            var group = (await _service.GetGroups(g => g.Id == groupId,
                                                  new Expression<Func<Group, object>>[] { 
                                                      g => g.Emoployees 
                                                  })
                        ).FirstOrDefault();

            if (group == null)
            {
                return HttpNotFound();
            }

            var organization = (await _service.GetOrganizations(o => o.Id == organizationId,
                                                                new Expression<Func<Organization, object>>[] {
                                                                    g => g.Emoployees
                                                                })
                               ).FirstOrDefault();

            if (organization == null)
            {
                return HttpNotFound();
            }

            return Json(organization.Emoployees.Where(e => !group.Emoployees.Contains(e)).Select(e => new { id = e.Id, fullName = e.FullName }));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}