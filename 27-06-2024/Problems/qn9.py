#to find permutation of a string
# from itertools import permutations

value = input("Enter a string : ")
# stringPermutation = permutations(value)
# for i in stringPermutation:
#     print(''.join(i))

def permute(string, start, end): 
    if start == end-1: 
        print(''.join(string) ) 
    else: 
        for i in range(start, end): 
            string[start], string[i] = string[i], string[start] 
            permute(string, start+1, end) 
            string[start], string[i] = string[i], string[start]

n = len(value)  
permute(list(value), 0, n) 
