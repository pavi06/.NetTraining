#specified within quotes
name = "Pavithra"
age = "26" #string
print(type(age))

#int
age = 35
print(type(age))

#float
cgpa = 9.9
print(type(cgpa))

#complex -> 'j'
n=2j
print(n)

#range -> start from 0 and goes till n-1
print(range(3))
print(list(range(3))) #list of this range(0-2)
print(list(range(-3,3)))
print(list(range(-3))) #empty list

#list -> mutable
fruits = ["apple", "banana", "Mango"]
print(type(fruits))
fruits[1]="orange"
print(fruits)
print("Length : "+str(len(fruits)))

demoList = [1,"two",3.0]
print(demoList)

#dict -> mutable
fruitsDict = {1:"apple", 2:"banana", 3:"Mango"}
print(type(fruitsDict))
fruitsDict[1]="orange"
print(fruitsDict)

#set - unordered
alphabets = {"a","b","c","d","a"}
print(alphabets)
