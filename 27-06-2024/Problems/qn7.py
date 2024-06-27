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

nums =[]
for i in range(10):
    nums.append(int(input("Enter a number : ")))
total=0
count=0
for i in nums:
    if isPrime(i):
        print(i)
        total+=i
        count+=1
if(count==0):
    print("No prime number present in the list!")
else:
    print(f"Average of prime numbers : {total/count:.2f}")