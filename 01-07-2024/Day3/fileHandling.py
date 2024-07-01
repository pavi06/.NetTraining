#reading a file
#open() -> open a file
#modes - > r(read), w(write), a(append), x(create file and throw error if already exits)
#
# file = open('./demo_text_file.txt','r')
# # print(file.read()) #display whole content
# print(file.read(10)) #read 10 characters
# print(file.readline()) #single line, continue from the cursor position
# file.close()

#a -> appends at the end of the file
# file = open('./demo_text_file.txt','a')
# file.write("New text added")
# file.close()
# file = open('./demo_text_file.txt','r')
# print(file.read())
# file.close()

#w -> override the text
# file = open('./demo_text_file.txt','w')
# file.write("Old text is removed and New text added")
# file.close()
# file = open('./demo_text_file.txt','r')
# print(file.read())
# file.close()

#to delete a file
# import os
# os.remove('./demo_text_file.txt')

#x -> create file
file = open('./demo_text_file.txt','x')
file.write("Old text is removed and New text added")
file.close()
file = open('./demo_text_file.txt','r')
print(file.read())
file.close()