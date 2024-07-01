import pandas as pd

df = pd.read_excel('./files/EmployeeSampleData.xlsx')
data_list = df.to_dict(orient='records')
print("--------Employee Data--------")
print("Total no of records : ",len(data_list))
for i in data_list[:10]:
    print(i)