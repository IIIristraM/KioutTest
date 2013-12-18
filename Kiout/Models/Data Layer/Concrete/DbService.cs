using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Kiout.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Kiout.Models
{
    public class DbService : IDbService
    {
        private ApplicationDbContext _db;
        public DbService()
        {
            _db = new ApplicationDbContext();
        }

        #region Groups
        public async Task<IEnumerable<Group>> GetGroups(Expression<Func<Group, bool>> where, Expression<Func<Group, object>>[] includs)
        {
            var query = _db.Groups.AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.ToListAsync();
        }

        public async Task<Group> GetGroup(object id)
        {
            return await _db.Groups.FindAsync(id);
        }

        public async Task DeleteGroup(Group group)
        {
            _db.Groups.Remove(group);
            await _db.SaveChangesAsync();
        }

        public async Task AddGroup(Group group)
        {
            _db.Groups.Add(group);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateGroup(Group group)
        {
            var entry = _db.Entry(group);
            if (entry.State == EntityState.Unchanged)
            {
                _db.Set<Group>().Attach(group);
            }
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task AddStudent(Group group, Employee employee)
        {
            var groupEntry = _db.Entry(group);
            if (groupEntry.State == EntityState.Detached)
            {
                _db.Set<Group>().Attach(group);
            }
            var employeeEntry = _db.Entry(employee);
            if (employeeEntry.State == EntityState.Detached)
            {
                _db.Set<Employee>().Attach(employee);
            }
            group.Emoployees.Add(employee);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveStudent(Group group, Employee employee)
        {
            var groupEntry = _db.Entry(group);
            if (groupEntry.State == EntityState.Detached)
            {
                _db.Set<Group>().Attach(group);
            }
            var employeeEntry = _db.Entry(employee);
            if (employeeEntry.State == EntityState.Detached)
            {
                _db.Set<Employee>().Attach(employee);
            }
            group.Emoployees.Remove(employee);
            await _db.SaveChangesAsync();
        }

        #endregion

        #region Employees

        public async Task<IEnumerable<Employee>> GetEmployees(Expression<Func<Employee, bool>> where, Expression<Func<Employee, object>>[] includs)
        {
            var query = _db.Employees.AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> GetEmployee(object id)
        {
            return await _db.Employees.FindAsync(id);
        }

        #endregion

        #region Instructors

        public async Task<IEnumerable<Instructor>> GetInstructors(Expression<Func<Instructor, bool>> where, Expression<Func<Instructor, object>>[] includs)
        {
            var query = _db.Instructors.AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.ToListAsync();
        }

        #endregion

        #region Courses

        public async Task<IEnumerable<Сourse>> GetСourses(Expression<Func<Сourse, bool>> where, Expression<Func<Сourse, object>>[] includs)
        {
            var query = _db.Сourses.AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.ToListAsync();
        }

        #endregion

        #region Organizations

        public async Task<IEnumerable<Organization>> GetOrganizations(Expression<Func<Organization, bool>> where, Expression<Func<Organization, object>>[] includs)
        {
            var query = _db.Organizations.AsQueryable();
            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.ToListAsync();
        }

        #endregion

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}