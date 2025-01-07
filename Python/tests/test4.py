import time
from time import sleep
import random


def main():

        Hangman()



def Hangman():
    name = input("Enter Your Name:")

    print("Hello " + name)
    print("Get ready!!")

    print("")

    time.sleep(1)

    print("Let us play Hangman!!")
    time.sleep(0.5)

    word = "flower"

    wrd = ""

    chance = 10

    while chance > 0:
        failed = 0

        for char in word:
            if char in wrd:
                print(char, end="")

            else:
                print(" _ ", end="")

                failed += 1

        if failed == 0:
            print("You Won!!Congratulations!!")

            break

        guess = input("Guess a Letter:")

        wrd = wrd + guess

        if guess not in word:
            chance -= 1

            print("Wrong Guess! Try Again")

            print("You have", +chance, "more turn")

            if chance == 0:
                print("You Lose! Better Luck Next Time")
                print(f"The word was {word}")




if __name__ == "__main__":
    main()