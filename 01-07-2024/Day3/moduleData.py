#used to store data/functions and use it later
#file containing definitions and statements.
person = {
    "name":"Pavi",
    "age":22,
    "dob":"yyyy-mm-dd",
    "grade":"A+"
}


def display_language(function_used):
    if(function_used == "Printf()"):
        print("C")
    elif(function_used == "Print()"):
        print("Python")
    elif(function_used == "Console.log()"):
        print("Javascript")
    else:
        print("Sorry! I Couldn't recognize")

