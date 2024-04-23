using RequestTrackerBLLLibrary;
using RequestTrackerBLLLibrary.CustomExceptions;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLTest
{
    public class DepartmentBLTest
    {
        IRepository<int, Department> repository;
        IDepartmentService departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            //department = new Department() { Name = "Admin", Department_Head = 102 };
            //repository.Add(department);
            departmentService = new DepartmentBL(repository);
        }

        [Test]
        public void GetDepartmentByNameTest()
        {
            var department = departmentService.GetDepartmentByName("IT");
            //Assert
            Assert.AreEqual(1, department.Id);
        }

        [Test]
        public void GetDepartmentById()
        {
            var department = departmentService.GetDepartmentById(1);
            //Assert
            Assert.AreEqual(1, department.Id);
        }

        [Test]
        public void GetDepartmentHeadId()
        {
            var departmentHead = departmentService.GetDepartmentHeadId(1);
            //Assert
            Assert.AreEqual(103, departmentHead);
        }

        [Test]
        public void UpdateDepartment()
        {
            Department department = departmentService.GetDepartmentById(1);
            department.Department_Head = 103;
            var depart = departmentService.UpdateDepartment(department);
            //Assert
            Assert.IsNotNull(depart);
        }

        [Test]
        public void DeleteDepartment()
        {
            var depart = departmentService.DeleteDepartmentById(1);
            //Assert
            Assert.IsNotNull(depart);
        }

        [Test]
        public void GetDepartmnetByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DepartmentNotFoundException>(() => departmentService.GetDepartmentByName("Admin"));
            //Assert
            Assert.AreEqual("Department is not available", exception.Message);
        }

        [Test]
        public void AddDuplicateDepartmnetExceptionTest()
        {
            Department department = new Department() { Name = "IT", Department_Head = 103};
            //Action
            var exception = Assert.Throws<DuplicateDepartmentNameException>(() => departmentService.AddDepartment(department));
            //Assert
            Assert.AreEqual("Department name already exists", exception.Message);
        }

    }
}