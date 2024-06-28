#seq of ele within ()
#immutable
#allow duplicate
fruits = ("apple", "mango", "banana")
print(fruits)
print(type(fruits))

#not allowed
# fruits[0]="orange"
# print(fruits)

#can convert a list into tuple wiht list()
listItems = tuple(["oops","java","python"])
print(listItems)
print(type(listItems))

greets = ("hi") #considered as string, shld place , at the end
print(type(greets))
greets = ("hi",)
print(type(greets))

#accessed through index , loops
#slicing allowed
#can convert tuple to list


#can concat 2 tuples
t1 =(1,2,3)
t2=(4,5,6)
print(t1+t2)

#not allowed with other type
# t1=[1,2]
# print(t1+t2)

del t1 #delete tuple
# print(t1)

#tuple unpack
fruits = ("apple", "mango", "papaya", "pineapple", "cherry")
(green, *tropic, red) = fruits #* will take any no of val left over
print(green)
print(tropic)
print(red)

#count occurance of an item
print("Apple Count : ",fruits.count('apple'))

#return index
print(fruits.index('pineapple'))