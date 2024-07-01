class Greetings:
    print("Hello")


class Scopes:
    # global x
    x=20
    def local_scope():
        x=10
        print(x)
    local_scope()
    print("Global x value : ",x)

#attribute reference
Scopes.local_scope() #toaccess data and functions through class
print(Scopes.x)

#__init__(), is always executed when the class is being initiated.
#assign values to object properties
#self -> current instance ref
class Student:
    def __init__(self,name, age,mark): #similar to constructor
        self.name = name
        self.age = age
        self.mark = mark

#instantiation
s1 = Student("Pavi",22,95)
print(s1.mark) 
#can modify and del object
del s1.mark
#__str__() function controls what should be returned when the class object is represented as a string.
#similar to tostring method
class Student:
    def __init__(self,name, age,mark): #similar to constructor
        self.name = name
        self.age = age
        self.mark = mark

    def __str__(self) -> str: #returns string representation
        return f"Student Details:\nName : {self.name}\nAge: {self.age}\nMarks : {self.mark}"

s1 = Student("Pavi",22,95)
print(s1)


#dataclasses