#base class
class Person:
    def __init__(self,name,age):
        self.name = name
        self.age = age

    def person_details(self):
        return f"Name : {self.name}, Age : {self.age}"

#child class
class Student(Person):
    def __init__(self, name, age,grade):
        super().__init__(name, age)
        self.grade = grade

    def print_student_details(self):
        print(super().person_details())
        print(f"Grade : {self.grade}")

s1 = Student("Pavi",22,"A")
s1.print_student_details()
print(isinstance(s1,Student)) #to check instance of something
print(issubclass(Student,Person)) #to check if its a subclass of another class
