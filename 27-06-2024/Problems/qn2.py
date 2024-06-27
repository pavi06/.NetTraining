#get name from user and then greet
name = input("Enter your name : ")
while(not name.isalpha()):
    name = input("Please provide a valid name : ")
print("Hello "+name+"!")