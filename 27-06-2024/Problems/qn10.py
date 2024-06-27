#pattern problem
n=int(input("Enter a number : "))
for i in range(n):
    for space in range(n-i-1):
        print(" ",end="")
    for j in range(i*2+1):
        print("*",end="")
    print()
 
