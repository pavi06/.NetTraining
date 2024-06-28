person = {
    "name":"Pavi",
    "age":22
}

print(person)
print(type(person))


#with dict function
demo = dict(name = "Pavi", age = 36, language = "Python")
print(demo)

for i in demo:
    print(i) #keys alone

#index, key
for i, j in enumerate(demo):
    print(i, j)

#can update value through update, assignment
demo.update({"name":"Pavithra"})
print(demo)

#can add new item
demo["Salary"] = 1200000
print(demo)

# demo.clear()

demo.pop("Salary")
print(demo)