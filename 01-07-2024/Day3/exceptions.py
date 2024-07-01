import sys
import os
# # #exception handling
# # #try except block
while True:
    try:
        x = int(input("Please enter a number: "))
        break
    except ValueError: #handles specific exception - value error 
        print("Oops!  That was no valid number.  Try again...")

# # #can have any no of except block or can also use it by combined
try:
    divide = 5/2
    print(f"{divide:.2f}")
except ZeroDivisionError:
    print("Divide by zero is not allowed")
finally: #always get exected
    print('EXIT')

# # #generalized term -> except Exception
try:
    n1=int(input("Enter a number : "))
    n2=int(input("Enter a number : "))
    res = n1/n2
    print(res)
except (ZeroDivisionError, ValueError): #cannot have specific info about the error X
    print("Error occured!")


# #raise exception
# #sys.exit() -> clean , freeup memory, calls SystemExit(exit interpreter)
try:
    n=5/0
except ZeroDivisionError:
    print("Error: Division by zero!")
    sys.exit(1) #error code 1 specifies that /0 error
finally:
    print("--finally block--")
print("Hello")
print("These lines are not getting executed")
# #exit(0) -> successful
# #exit(1-127) -> errors
# #custom code above 127 

# #os.exit() -> stop abruptly
try:
    n=5/0
except ZeroDivisionError:
    print("Error: Division by zero!")
    os._exit(0) #doesn't execute remaining lines
finally:
    print("--finally block--")
print("These lines are not getting executed")

#raise exception
try:
    raise ValueError('Value Error')
except ValueError as e:
    print(e)