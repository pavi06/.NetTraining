# 1.Double every second digit from right to left. If this “doubling” results in a two-digit number, subtract 9 from it get a single digit.
# 2.Now add all single digit numbers from step 1.
# 3.Add all digits in the odd places from right to left in the credit card number.
# 4.Sum the results from steps 2 & 3.
# 5.If the result from step 4 is divisible by 10, the card number is valid; otherwise, it is invalid.

number = ''.join(input("Enter your credit card number : ").split(' '))[::-1]

total = 0
for i in range(len(number)):
    if(i%2==0):
        total+=int(number[i])
    else:
        if((int(number[i])*2) > 9):
            total+=int(number[i])*2-9
        else:
            total+=int(number[i])*2

if(total%10 == 0):
    print("Valid!")
else:
    print("Invalid!")