import random

# Open the file in read mode
    with open("words.txt", "r") as file:
        allText = file.read()
        words = list(map(str, allText.split()))

        # print random string
        print(random.choice(words))