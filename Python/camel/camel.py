camel = input("camelCase: ")

print("snake_case: ", end="")

for letter in camel:

    if letter.isupper() == True:
        print("_" + letter.lower(), end="")

    else: print(letter, end="")

print()


 # print("snake_case:", letter)