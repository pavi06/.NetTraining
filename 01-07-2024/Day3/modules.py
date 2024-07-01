# import moduleData

# personName = moduleData.person["name"] #accessing module data
# print(personName)

#can also provide alias as m
#m.person["name"]
#can also import a specifc function or variable from the module as,
from moduleData import display_language

display_language("Print()")
