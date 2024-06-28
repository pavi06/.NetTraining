def is_prime(num):
    if num<=1:
        return False
    if num==2:
        return True
    if num%2==0:
        return False
    for i in range(3,num//2+1,2):
        if num%i==0:
            return False
    return True

num = int(input("Enter a number : "))
flag=False
for i in range(1,num+1):
    if is_prime(i):
        flag=True
        print(i,end=" ")
if(not flag):
    print(f"No prime numbers available till {num}")
    
