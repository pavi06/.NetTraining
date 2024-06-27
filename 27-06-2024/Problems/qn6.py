def isPrime(num):
    if num<=1:
        return False
    if num==2:
        return True
    if num%2==0:
        return False
    for i in range(3,num//2+1,2):
        if num%i==0 and num!=i:
            return False
    return True

num = int(input("Provide a number :"))
if(isPrime(num)):
    print(f"{num} is a prime number")
else:
    print(f"{num} is not a prime number")