def check_bulls_and_cows(secret, guess):
    bulls=0
    numArray = [0]*10
    for i in range(len(guess)):
        if(secret[i] == guess[i]):
            bulls+=1
        else:
            numArray[int(secret[i])-1]+=1
            numArray[int(guess[i])-1]-=1
    cows = len(secret)-bulls
    for i in numArray:
        if i>0:
            cows-=i
    return (bulls,cows)


print("-------Bulls - Cows ----------")
secret = input("Enter the secret code : ")
print("Secre code : ",secret)
bulls=cows=0
count=0
while(bulls<len(secret) and cows<len(secret)):
    guess = input("Provide your guess : ")
    bulls,cows = check_bulls_and_cows(secret, guess)
    print("Bulls : ",bulls,"Cows : ",cows)
    count+=1
print(f"Congrats...You found the secret word within {count} guesses!")
