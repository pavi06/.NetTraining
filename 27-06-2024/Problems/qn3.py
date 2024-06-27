name = input("Enter your name : ")
while(not name.isalpha()):
    name = input("Please provide a valid name : ")
age = int(input("Enter your age : "))
print(f"Hello {name}, \n\tYou're {age} years old.")