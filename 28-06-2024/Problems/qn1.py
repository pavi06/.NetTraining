#longest substring without repeating characters
def substring_without_repeating_char(string):
    l=0
    max_length=0
    substringWithIndex = {}
    for r in range(len(string)):
        if string[r] in substringWithIndex and l<= substringWithIndex[string[r]]:
            l=substringWithIndex[string[r]]+1
        else:
            max_length = max(max_length,r-l+1)
        substringWithIndex[string[r]]=r
    return max_length

string_value = "abcabcd" 
res = substring_without_repeating_char(string_value)
print("Longest substring without repeating char : ",res)

