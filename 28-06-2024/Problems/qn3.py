student_and_scores = {"H" : 98,"B" : 45, "N" : 56, "D":30, "T":98,"F":50,"O":88,"Y":99,"I":20,"J":50,"K":39,"P":100}
sorted_scores = dict(sorted(student_and_scores.items(), key=lambda item: (-item[1], item[0])))

top_ten_scores = dict(list(sorted_scores.items())[:10])
print("Student | score")
for i,j in top_ten_scores.items():
    print(f"{i}\t| {j}")