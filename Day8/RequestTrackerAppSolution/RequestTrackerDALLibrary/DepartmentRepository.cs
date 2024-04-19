using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        //readonly for faster access and create a single ref. and the values can be changed.
        //dictionary of departments are created. (id and item)
        readonly Dictionary<int, Department> _departments;

        //Default constructor
        public DepartmentRepository()
        {
            _departments = new Dictionary<int, Department>();
        }
        int GenerateId()
        {
            if (_departments.Count == 0)
                return 1;
            int id = _departments.Keys.Max();
            return ++id;
        }

        //adding an item to dict
        //containsValue will loop over the objects and check whether the obj with same depart name is available.(checked for depart name)
        public Department Add(Department item)
        {
            if (_departments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _departments.Add(item.Id, item);
            return item;
        }

        //deleting an item
        public Department Delete(int key)
        {
            if (_departments.ContainsKey(key))
            {
                var department = _departments[key];
                _departments.Remove(key);
                return department;
            }
            return null;
        }

        //reading an item with id
        //check if the item with that key is available or not, if so return it.
        public Department Get(int key)
        {
            return _departments.ContainsKey(key) ? _departments[key] : null;
        }

        //reading all items
        //list of objects
        public List<Department> GetAll()
        {
            if (_departments.Count == 0)
                return null;
            return _departments.Values.ToList();
        }

        //updating an item by accepting the obj
        public Department Update(Department item)
        {
            if (_departments.ContainsKey(item.Id))
            {
                _departments[item.Id] = item;
                return item;
            }
            return null;
        }

    }
}
