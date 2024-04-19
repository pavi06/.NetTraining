using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Department UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
