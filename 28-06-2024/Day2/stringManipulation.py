#string -> specified within single or double quotes
#array -> accessed with index
name = "Pavithra"
print(name)

#multiline 
longText = """
    Hi there..I'm Pavithra!!
    How may I assist you??
"""
print(longText)

#string slicing
print(name[:4])

#to find length
print("Length : "+ str(len(name)))

#capitalize first char
greet = "hello"
print("\nOriginal string : "+ greet)
print("Capitalize : "+ greet.capitalize())

#replace -> replace all occurance of a char 
print("Replace : "+greet.replace('e','a'))

#to check all char are in uppercase
print("IsUpper : "+ str(greet.isupper()))
#to check all char are in lowercase
print("IsLower : "+ str(greet.islower()))

#to check if the string contains only alphabets and numerics
print("IsAlnum : "+ str(greet.isalnum()))
text = "Hi@06" #returns false
print("IsAlnum : "+ str(text.isalnum()))
#to check if the string contains only alphabets
print("\nIsAlpha : "+ str(greet.isalpha()))
#to check if the string contains only numerics
print("IsDigit : "+ str(greet.isdigit()))


stringWithSpace = "  Hello Buddy!  "
print("\nOriginal string : "+ stringWithSpace)
print("Strip : "+ stringWithSpace.strip()) #remove white spaces from both side
print("Right Strip : "+ stringWithSpace.rstrip()) #remove white spaces in the right
print("Left strip : "+ stringWithSpace.lstrip()) #remove white spaces in the left


print("\nUpper : "+greet.upper())
print("Lower : "+greet.lower())

print(longText.partition("Pavithra")) #partition based on the keyword provided, return 3 parts before, word and after

#split string based on the space
print(stringWithSpace.split())

#find 
print(stringWithSpace)
print(stringWithSpace.strip().find('B'))