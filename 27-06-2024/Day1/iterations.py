#for loop
#iterates over a seq 
for i in range(3):
    print(i)

#iterates over a list
for i in ["c","python","java","c#"]:
    print(i)

#enumerate -> provide key value pairs (index, value) of all ele in a seq
for i, j in enumerate({"apple","banana","mango"}):
    print("Index : "+str(i)+", Value : "+j)



#while loop
i=1
while (i<3):
    print(i)
    i+=1

#while with else
#else will get executed when the loop ends
print()
i=1
while(i<3):
    print(i)
    i+=1
else:
    print("i value is 3")

#break statement -> stop the execution
i=1
while(i<3):
    print(i)
    if(i==1):
        break
    i+=1
print("loop ended")

#continue -> skip the remaining code for that particular iteration 
i=0
while(i<3):
    i+=1
    if(i==2):
        continue
    print(i)