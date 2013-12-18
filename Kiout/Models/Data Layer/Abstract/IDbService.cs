using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kiout.Models
{
    public interface IDbService : IDisposable
    {
        Task AddGroup(Group group);
        Task AddStudent(Group group, Employee employee);
        Task DeleteGroup(Group group);
        Task<Employee> GetEmployee(object id);
        Task<IEnumerable<Employee>> GetEmployees(Expression<Func<Employee, bool>> where, Expression<Func<Employee, object>>[] includs);
        Task<Group> GetGroup(object id);
        Task<IEnumerable<Group>> GetGroups(Expression<Func<Group, bool>> where, Expression<Func<Group, object>>[] includs);
        Task<IEnumerable<Instructor>> GetInstructors(Expression<Func<Instructor, bool>> where, Expression<Func<Instructor, object>>[] includs);
        Task<IEnumerable<Organization>> GetOrganizations(Expression<Func<Organization, bool>> where, Expression<Func<Organization, object>>[] includs);
        Task<IEnumerable<Сourse>> GetСourses(Expression<Func<Сourse, bool>> where, Expression<Func<Сourse, object>>[] includs);
        Task RemoveStudent(Group group, Employee employee);
        Task UpdateGroup(Group group);
    }
}
