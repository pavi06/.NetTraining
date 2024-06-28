#methods - block of code , executed when it is called
#method without arg.
def greet():
    print("Hello python programmer!")

greet()

#fun with arg
def calculate_sum(a,b):
    return a+b
print("Sum : ",calculate_sum(2,3))

#arbitrary arg
def sum_all(*nums):
    total=0
    for i in nums:
        total+=i
    return total
print(sum_all(2))
print(sum_all(2,3,4))

#lambda function
def lambda_func(n):
    return lambda a: a*n #returns func
res = lambda_func(2)
print(res(2))

