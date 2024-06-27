#arithmetic operators
a=5
b=2
print("sum : "+str(a+b))
print("sub : "+str(a-b))
print(f"Multiplication : {a*b}")
print(f"Division : {a/b}")
print(f"Modulus : {a//b}")
print(f"Exponent : {a**b}")

print("-----------Comparison Operator----------------")
#comparison operators
print(f"Equal : {a==b}") #checks both equal
print(f"Equal : {5==5}")
print("Greaterthan : "+str(a>b)) #check 1st num greater than 2nd
print("Lesserthan : "+str(a<b))
print("Greaterthan Or equalto : "+str(a>=b))
print("lessthan Or equalto : "+ str(a<=b))
print("Not equalTo : "+ str(a!=b))

print("-----------Logical Operator----------------")
#logical operators
#and -> both condition should be true
print("---logical and---")
print(5>2 and 3<2) 
print(5>2 and 3>2) 

#or -> any one condition should be true
print("---logical or---")
print(5>2 or 3<2) 
print(5>2 or 3>2) 

#not -> logical reverse : true->false, false->true
#takes one argument
print("---logical not---")
print(not(5>2)) 
print(not(5>2 and 3>2)) 

print("--------Identity operator--------")
#identity operator
#is , is not -> check both var points to the same obj 
x=[1,2,3]
y=[4,5,6]
z=y #points same obj
if(z is y):
    print("Both points to the same obj")
else:
    print("Diff ref")
print(z is not y)


print("\n--------Membership operator--------")
#identity operator
#in , not in (iterate over a seq of ele and check that particular ele is available or not)
x=[1,2,3]
if(5 in x):
    print("3 - present in x list")
else:
    print("not present")
print(3 not in x) #present in x

#bitwise operator -> works with each bit
a=5
b=6
#and
print(a&b)
#or
print(a|b)
#left shift
print(a<<2)
#right shift
print(a>>2)