print("What is the Answer to the Great Question of Life, the Universe, and Everything? ")

x = input()

if x.strip() == "42" :
    result = "Yes"

elif x.lower() == "forty-two":
    result = "Yes"

elif x.lower() == "forty two":
    result = "Yes"

else :result = "No"

print(result)