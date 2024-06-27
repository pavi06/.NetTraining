#list
fruits = ["apple","banana","mango"]
print(fruits)
#accessed through index -> starts from 0
print(fruits[0])
print(fruits[-1]) #reverse indexing -> starts from -1, -2,..

#slicing
print(fruits[1:2]) #start index and goes till end-1
#if no value is given for start and end, default value will be taken, start ->0, end -> length
print(fruits[:2]) #start from first
print(fruits[2:]) #goes till end
print(fruits[:]) 
print(fruits[-3:-1])


#insert an ele
#position, value
fruits.insert(2,"orange")
print(fruits)

#remove an ele
print(fruits.pop()) #remove last ele
print(fruits)

#insert 
#single ele
fruits.append("pineapple")
#multiple ele at the same time
#can extend any iterable not list alone
#if dict takes only the key
fruits.extend(["mango","papaya"])
print(fruits)

#split and add to the list
fruits += "strawberry"
print(fruits)

fruits+=["kiwi"]
print(fruits)



