using RequestTrackerBLLLibrary.CustomExceptions;
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
            var departmentList = _departmentRepository.GetAll();
            if(departmentList != null)
            {
                foreach (var department in departmentList)
                {
                    if (department.Name.Equals(departmentOldName))
                    {
                        department.Name = departmentNewName;
                        return UpdateDepartment(department);
                    }
                }
                throw new DepartmentNotFoundException();
            }            
            throw new NoDepartmentsAvailableException();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var departmentList = _departmentRepository.GetAll();
            if (departmentList != null) {
                foreach (var department in departmentList)
                {
                    if (department.Name.Equals(departmentName))
                    {
                        return department;
                    }
                }
                throw new DepartmentNotFoundException();
            }
            throw new NoDepartmentsAvailableException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if (department != null) {
                var departmentHeadId = department.Department_Head;
                if (departmentHeadId != null) {
                    return departmentHeadId;
                }
                throw new NullValueException();                
            }             
            throw new DepartmentNotFoundException();
        }

        public List<Department> GetAllDepartments()
        {
            var departmentList = _departmentRepository.GetAll();
            if (departmentList != null)
            {
                return departmentList;
            }
            throw new NoDepartmentsAvailableException();
        }

        public Department UpdateDepartment(Department department)
        {
            var updatedDepartment = _departmentRepository.Update(department);
            if (updatedDepartment != null)
            {
                return updatedDepartment;
            }
            throw new DepartmentNotFoundException();
        }

        public Department DeleteDepartmentById(int departmentId)
        {
            var department = _departmentRepository.Delete(departmentId);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }
    }
}
