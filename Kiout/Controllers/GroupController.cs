using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kiout.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kiout.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private IDbService _service;

        public GroupController(IDbService service)
        {
            _service = service;
        }

        // GET: /Group/
        public async Task<ActionResult> Index()
        {
            var groups = (await _service.GetGroups(null, new Expression<Func<Group,object>>[] { g => g.Instructor, g => g.Сourse})).Select(g => new GroupInfoViewModel() { 
                Group = g,
                StudentsCount = g.Emoployees.Count
            });
            return View(groups);
        }

        // GET: /Group/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await _service.GetGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: /Group/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.InstructorId = new SelectList(await _service.GetInstructors(null, null), "Id", "FullName");
            ViewBag.CourseId = new SelectList(await _service.GetСourses(null, null), "Id", "Title");
            return View();
        }

        // POST: /Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Title,InstructorId,CourseId")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _service.AddGroup(group);
                return RedirectToAction("Edit", new { id = group.Id });
            }

            ViewBag.InstructorId = new SelectList(await _service.GetInstructors(null, null), "Id", "FullName", group.InstructorId);
            ViewBag.CourseId = new SelectList(await _service.GetСourses(null, null), "Id", "Title", group.CourseId);
            return View(group);
        }

        // GET: /Group/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbService service = new DbService();
            Group group = (await service.GetGroups(
                g => g.Id == id.Value,
                new Expression<Func<Group, object>>[] {
                    g => g.Instructor, 
                    g => g.Emoployees.Select(e => e.Organization)
                })).FirstOrDefault();
                //await db.Groups.Include(g => g.Instructor).Include(g => g.Emoployees.Select(e => e.Organization)).FirstOrDefaultAsync(g => g.Id == id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorId = new SelectList(await service.GetInstructors(null, null), "Id", "FullName", group.InstructorId);
            ViewBag.CourseId = new SelectList(await service.GetСourses(null, null), "Id", "Title", group.CourseId);
            return View(group);
        }

        // POST: /Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Title,InstructorId,CourseId")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateGroup(group);
                return RedirectToAction("Index");
            }
            ViewBag.InstructorId = new SelectList(await _service.GetInstructors(null, null), "Id", "FullName", group.InstructorId);
            ViewBag.CourseId = new SelectList(await _service.GetСourses(null, null), "Id", "Title", group.CourseId);
            return View(group);
        }

        // GET: /Group/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await _service.GetGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: /Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Group group = await _service.GetGroup(id);
            await _service.DeleteGroup(group);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddStudent(int groupId)
        {
            var group = await _service.GetGroup(groupId);
            if (group == null)
            {
                return HttpNotFound();
            }

            ViewBag.GroupTitle = group.Title;
            ViewBag.InstructorFullName = group.Instructor.FullName;

            var organizations = await _service.GetOrganizations(o => o.InstructorId == group.InstructorId, null);
            var model = new AddStudent() { Group = group };
            if (organizations.Count() != 0) model.OrganizationId = organizations.First().Id;

            ViewBag.OrganizationId = new SelectList(organizations, "Id", "Title");

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(AddStudent model)
        {
            if (ModelState.IsValid)
            {
                var employee = (await _service.GetEmployees(e => e.Id == model.NewStudentId.Value, null)).First();               
                await _service.AddStudent(model.Group, employee);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteStudent(int groupId, int employeeId)
        {
            var group = await _service.GetGroup(groupId);
            var employee = await _service.GetEmployee(employeeId);
            if ((group == null) || (employee == null))
            {
                return HttpNotFound();
            }
            await _service.RemoveStudent(group, employee);
            return RedirectToAction("Edit", new { id = groupId });
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
