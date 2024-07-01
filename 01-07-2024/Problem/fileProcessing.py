import pandas as pd
from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas
from reportlab.platypus import SimpleDocTemplate, Table, TableStyle
from reportlab.lib import colors
persons = []

def choice_to_add_content(choice, person):
    persons.append(person)
    if choice == 1:
        text_file = open('./files/personData.txt','a')
        text_file.write(str(person))
        text_file.close()
    elif choice == 2:
        df = pd.read_excel('./files/personData.xlsx')
        new_data = pd.DataFrame({'Name': [person.name], 
                                'DaateOfBirth': [person.dob],
                                'Age': [person.age], 
                                'Phone':[person.phone],
                                'Email':[person.email]})

        df = pd.concat([df, new_data], ignore_index=True)
        df.to_excel('./files/personData.xlsx', index=False)
    elif choice == 3:
        doc = SimpleDocTemplate("./files/personData.pdf", pagesize=letter)
        table_data = [['Name', 'DOB', 'Age', 'Phone', 'Email']]
        for person in persons:
            table_data.append([person.name, str(person.dob), str(person.age), person.phone , person.email])
        table = Table(table_data)
        style = TableStyle([
            ('BACKGROUND', (0, 0), (-1, 0), colors.grey),  # Header row background color
            ('TEXTCOLOR', (0, 0), (-1, 0), colors.white),  # Header row text color
            ('ALIGN', (0, 0), (-1, -1), 'CENTER'),        # Center align all cells
            ('GRID', (0, 0), (-1, -1), 1, colors.black),  # Add grid lines
        ])
        table.setStyle(style)
        elements = [table]
        doc.build(elements)
    



