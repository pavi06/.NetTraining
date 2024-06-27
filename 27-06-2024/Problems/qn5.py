import re

name = input("Enter your name : ")
while(not name.isalpha()):
    name = input("Please provide a valid name : ")
age = input("Enter your age : ")
while(not age.isnumeric()):
    age = input("please provide a valid age : ")
dob = input("Enter your date of birth in YYYY/MM/DD format : ")
while(not re.match(r'^\d{4}/(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1])$', dob)):
    dob=input("Please provide a valid dob : ")
phone = input("Enter your phone number : ")
while(phone.isalpha() or len(phone)!=10):
    phone = input("Please provide a valid phone number : ")
print(f"Name : {name}\nAge : {age}\nDate of birth : {dob}\nPhone number : {phone}")