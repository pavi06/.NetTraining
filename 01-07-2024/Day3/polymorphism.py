class PythonDisplay:
    def display_info(self): #polymorphism
        print("Print() is used to display content to the user")

class CDisplay:
    def display_info(self):
        print("Printf() is used to display content to the user")

class CSharpDisplay:
    def display_info(self):
        print("Console.WriteLine() is used to display content to the user")

class DemoCSharp(CSharpDisplay):
    pass #use parent method

python = PythonDisplay()
python.display_info()

c = CDisplay()
c.display_info()

c_sharp = DemoCSharp()
c_sharp.display_info()


