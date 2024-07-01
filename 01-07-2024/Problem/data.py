class Person:
    def __init__(self, name,dob,phone,email,age):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email
        self.age = age
    
    def __str__(self) -> str:
        return f"Name : {self.name} , Dob : {self.dob} , Age : {self.age} , Phone : {self.phone} , Email : {self.email}"
    

def display_menu():
    print("1. TextFile\n2. Excel\n3. Pdf")

