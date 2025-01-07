input = input("input: ")

print("Output: ", end="")

for letter in input:
    if not letter.lower() in ["a" ,"e" , "i", "o", "u"]:
        print(letter, end="")


print()