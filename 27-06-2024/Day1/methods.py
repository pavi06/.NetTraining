#methods - block of code , executed when it is called
#method without arg.
def greet():
    print("Hello python programmer!")

greet()

#method with return type and positional arg
#takes value by position by default
def printLen(name):
    count=0
    for i in name:
        count+=1
    return count
print(printLen("Pavi"))

#can also be specified with ,/ at the end
def positional_arg(name, age):
    print(f"name : {name}, age : {age}")
positional_arg(23,"pavi")

#can also be specified with *, at the start
def keyword_arg(name, age):
    print(f"name : {name}, age : {age}")
keyword_arg(age=23,name="pavi")

#default arg shld be placed at the end
def default_arg(age,name="Pavi"):
    print(f"Name : {name}, Age : {age}")
default_arg(22)