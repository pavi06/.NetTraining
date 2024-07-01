import re
from datetime import datetime
import data as d
import fileProcessing as fp

while(True):
    #name
    name = input("Enter your name : ")
    while(not name.isalpha()):
        name = input("Please provide a valid name : ")
    #dob
    dob = input("Enter your date of birth in YYYY-MM-DD format : ")
    while(not re.match(r'^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$', dob)):
        dob=input("Please provide a valid dob : ")
    #phone
    phone = input("Enter your phone number : ")
    while(phone.isalpha() or len(phone)!=10):
        phone = input("Please provide a valid phone number : ")
    #email
    email = input("Enter your email : ")
    while(not re.match(r'^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$',email)):
        phone = input("Please provide a valid email : ")

    dob = datetime.strptime(dob, '%Y-%m-%d').date()
    today = datetime.now().date()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))

    print("\n-----------Data you provided-------------")
    person = d.Person(name,dob,phone,email,age)
    print(person)
    print("\n---------Choose the file to store the data--------")
    d.display_menu()
    choice = int(input("Enter your choice : "))
    while(choice != 1 and choice != 2 and choice != 3):
        print("Invalid choice")
    fp.choice_to_add_content(choice,person)
    ch = input("Want to continue Y/N ? ")
    while(ch.lower()!="n" and ch.lower()!="y"):
        ch = input("Invalid choice, provide again : ")
    if ch.lower() == 'n':
        break
    
