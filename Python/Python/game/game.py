import random


while True:
    try:
        level = int(input("Level: "))

        if level > 0:
            break

    except:
        pass


answer = random.randint(1, level)

while True:
    try:
        Guess = int(input("Guess: "))

        if Guess > 0:
            if Guess == answer:
                print("Just right!")
                break

            elif Guess < answer:
                print("Two small!")

                break

            elif Guess == 0:
                print("Two small!")

            else:
                print("Too large!")

                break

    except:
        pass
