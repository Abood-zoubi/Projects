from random import randint


def main():
    level = get_level()
    score = game_and_score(level)

    print("Score: ", score)


# gets level from the user and restricts it to levels 1 ,2, 3 only
def get_level():
    while True:
        try:
            level = int(input("Level: "))

            if level == 1 or level == 2 or level == 3:
                break
        except:
            pass
    return level


# generates integers for each level
def generate_integer(level):
    if level == 1:
        RandomNumber1 = randint(0, 9)
        RandomNumber2 = randint(0, 9)

    elif level == 2:
        RandomNumber1 = randint(10, 99)
        RandomNumber2 = randint(10, 99)

    else:
        RandomNumber1 = randint(100, 999)
        RandomNumber2 = randint(100, 999)

    return RandomNumber1, RandomNumber2


# detects wrong answers and breaks after 3 tries
def correct_answer(RandomNumber1, RandomNumber2):
    count = 0
    while count <= 2:
        try:
            answer = int(input(f"{RandomNumber1} + {RandomNumber2} = "))
            if answer == (RandomNumber1 + RandomNumber2):
                return True

            else:
                count += 1
                print("EEE")
        except:
            count += 1
            print("EEE")

    print(f"{RandomNumber1} + {RandomNumber2} = {RandomNumber1 + RandomNumber2}")
    return False


# plays the game for 10 rounds and calculates score
def game_and_score(level):
    round = 1
    score = 0
    while round <= 10:
        RandomNumber1, RandomNumber2 = generate_integer(level)
        user_input = correct_answer(RandomNumber1, RandomNumber2)

        if user_input == True:
            score += 1
            round += 1
    return score


if __name__ == "__main__":
    main()
