import time
import random


def main():

    greet = input("Do you want to greet the staff? ")
    if greet.title() == "Yes" or greet.title() == "Y":
        name = input("What staff member do you want to greet? ")
        print(greetstaff(name))

    else:
        games = ["Hangman", "Tic-Tac-Toe", "Rock-Paper-Scissors"]
        for game in games:
            print(game)

        x = input("Enter a game: ")
        game = is_game(x)

        if game == "Hangman":
            Hangman()


def greetstaff(name):
    if name.title() == "David Malan":
        return "Proffesor David, thank you for giving and explaining the course perfectly, it was very useful and knowledgeable, you are the best :)"

    else:
        return f"Hello {name}. Welcome to my project, hope you have fun"


# def choose_game():
#     games = ["Hangman", "Tic-Tac-Toe", "Rock-Paper-Scissors"]
#     for game in games:
#         print(f"{game}")

#     while True:
#         try:
#             user_game = input("Choose a game: ").title()
#             if (user_game in games) or (
#                 user_game == "H" or user_game == "T" or user_game == "R"
#             ):
#                 break

#         except:
#             pass

#     return user_game



# def is_game(game):

#     games = ["Hangman", "Tic-Tac-Toe", "Rock-Paper-Scissors"]

#     while True:
#         try:
#             x = input("Choose game: ")
#             if game.title() in games:
#                 return True
#             break


#         except:
#             pass

def is_game(game):
    allowed = ["Hangman", "Tic-Tac-Toe", "Rock-Paper-Scissors", "H", "T", "R"]

    while True:
        try:
            if game.title() not in allowed:
                print("Invalid game. Please enter a game from the list.")
                game = input("Enter a valid game: ")

            else:
                print("Game is valid.")
                if game.title() == "Hangman" or game.title() == "H":
                    game = "Hangman"
                    return game

                elif game.title() == "Tic-Tac-Toe" or game.title() == "T":
                    return "Tic-Tac-Toe"

                elif game.title() == "Rock-Paper-Scissors" or game.title() == "R":
                    return "Rock-Paper-Scissors"

                break

        except:
            pass


# def play_game(game):
#     if game == "Hangman":
#         return "Hangman"


#     elif game == "Tic-Tac-Toe":
#         return "Tic-Tac-Toe"

#     elif game == "Rock-Paper-Scissors":
#         return "Rock-Paper-Scissors"


def Hangman():
    name = input("Enter Your Name:").title()

    print("Hello " + name)
    print("Get ready!!")

    print("")

    time.sleep(1)

    print("Let us play Hangman!!")
    print("")
    time.sleep(0.5)

    # Opens words database and chooses a random word from it
    with open("words.txt", "r") as file:
        allText = file.read()
        wd = list(map(str, allText.split()))
        word = random.choice(wd)

    wrd = ""

    # Gives the user a ability to get as many chances to beat the game as he wants
    try:
        get_chance = int(input("How many chances do you want to have? "))

    except:
        print("Please Insert a Valid Integer")

    chance = get_chance

    while chance > 0:
        failed = 0

        for letter in word:
            if letter in wrd:
                print(letter.upper(), end="")

            else:
                print(" _ ", end="")

                failed += 1

        if failed == 0:
            print("")
            print(f"You Won !!Congratulations {name}!!")

            break
        print("")
        print("")
        guess = input("Guess a Letter:")

        wrd = wrd + guess

        if guess not in word:
            chance -= 1

            if chance != 0:
                if chance == 1:
                    print("Wrong Guess! Try Again")
                    print(f"You have {chance}, more turn")
                else:
                    print("Wrong Guess! Try Again")
                    print(f"You have {chance} more turns")

            elif chance == 0:
                print(f"You Lose! Better Luck Next Time {name}")
                print(f"The word was {word}")


def Grid(board):
    print("")
    print(board["7"] + "|" + board["8"] + "|" + board["9"])
    print("-+-+-")
    print(board["4"] + "|" + board["5"] + "|" + board["6"])
    print("-+-+-")
    print(board["1"] + "|" + board["2"] + "|" + board["3"])
    print("")


def Tic_Tac_Toe():
    player1 = input("What's your name player1 ? ")
    player2 = input("What's your name player2 ? ")

    # Where the characters will be placed
    # Gives each square in the grid a number where X or O will be placed
    Playable_Place = {
        "7": " ",
        "8": " ",
        "9": " ",
        "4": " ",
        "5": " ",
        "6": " ",
        "1": " ",
        "2": " ",
        "3": " ",
    }

    board_keys = []

    for key in Playable_Place:
        board_keys.append(key)

    turn = "X"
    count = 0

    for i in range(10):
        Grid(Playable_Place)
        print("It's your turn, " + turn + ". Move to which place?")

        print("")
        Play = input()

        print("")

        # Checks to see if input is a number between 1-9
        if Play.isnumeric():
            move = int(Play)
            if move >= 1 and move <= 9:
                if Playable_Place[Play] == " ":
                    Playable_Place[Play] = turn
                    count += 1
                else:
                    print("That place is already filled.")
                    print("Move to which place?")
                    if turn == "X":
                        turn = "O"
                    else:
                        turn = "X"
                        Playable_Place[Play] = turn
            else:
                print("Please insert a number from 1-9")
                if turn == "X":
                    turn = "O"
                else:
                    turn = "X"
                    Playable_Place[Play] = turn

        else:
            print("Please insert a number from 1-9")

        # Checks for a winner.
        if count >= 5:
            if Playable_Place["7"] == Playable_Place["8"] == Playable_Place["9"] != " ":
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["4"] == Playable_Place["5"] == Playable_Place["6"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["1"] == Playable_Place["2"] == Playable_Place["3"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["1"] == Playable_Place["4"] == Playable_Place["7"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["2"] == Playable_Place["5"] == Playable_Place["8"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["3"] == Playable_Place["6"] == Playable_Place["9"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["7"] == Playable_Place["5"] == Playable_Place["3"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

            elif (
                Playable_Place["1"] == Playable_Place["5"] == Playable_Place["9"] != " "
            ):
                Grid(Playable_Place)
                print("Game Over.")
                if turn == "X":
                    print(f"X Won !!Congratulations {player1.title()}!!")
                    break
                else:
                    print(f"X Won !!Congratulations {player2.title()}!!")
                    break

        # Checks for tie.
        if count == 9:
            print("Game Over.")
            print("It's a Tie!!")
            break

        # Loops Between X and O to allow both players to play.
        if Play.isnumeric():
            if turn == "X":
                turn = "O"
            else:
                turn = "X"


def Rock_Paper_Scissors():
    Computer_characters = ["🪨", "📃", "✂️"]
    Human_characters = ["Rock", "Paper", "Scissors"]
    count = 0
    # Number of wins for players either one or two and the wins of the computer
    P1wins = 0
    P2wins = 0
    Cwins = 0
    players = input("Single Player Or Multiplayer? ")

    # Makes the player play as much times as he/she wishes
    try:
        plays = int(input("How many times do you want to play? "))
    except:
        print("Insert a Number Please")
    if (
        players.lower() == "single player"
        or players.lower() == "single"
        or players.lower() == "s"
    ):
        while count < plays:
            try:
                human = input("What character do you want to play? ")
                if human.title() in Human_characters:
                    print("Human: ", human.title())
                    computer = random.choice(Computer_characters)
                    print("Computer: ", computer)

                    if human.lower() == "rock" and computer == "🪨":
                        print("Draw")
                        print("")
                        count += 1

                    elif human.lower() == "paper" and computer == "📃":
                        print("Draw")
                        print("")
                        count += 1

                    elif human.lower() == "scissors" and computer == "✂️":
                        print("Draw")
                        print("")
                        count += 1

                    elif human.lower() == "rock" and computer == "📃":
                        print("Computer Wins This Round")
                        print("")
                        count += 1
                        Cwins += 1

                    elif human.lower() == "rock" and computer == "✂️":
                        print("Human Wins This Round")
                        print("")
                        count += 1
                        P1wins += 1

                    elif human.lower() == "paper" and computer == "✂️":
                        print("Computer Wins This Round")
                        print("")
                        count += 1
                        Cwins += 1

                    elif human.lower() == "paper" and computer == "🪨":
                        print("Human Wins This Round")
                        print("")
                        count += 1
                        P1wins += 1

                    elif human.lower() == "scissors" and computer == "🪨":
                        print("Computer Wins This Round")
                        print("")
                        count += 1
                        Cwins += 1

                    elif human.lower() == "scissors" and computer == "📃":
                        print("Human Wins This Round")
                        print("")
                        count += 1
                        P1wins += 1
            except:
                print("Please insert a valid input")

        if P1wins == Cwins:
            print("Its a Draw!! ")

        elif P1wins < Cwins:
            print("Bad Luck")
            print("Computer Wins The Game")

        else:
            print("Player Wins !! Congratulations")

    # Code for multiplayer games
    # I know people can cheat in multiplayer but if you want a fair game put something on screen to cover terminal
    # when both players type their characters remove it
    elif (
        players.lower() == "multiplayer"
        or players.lower() == "multi"
        or players.lower() == "m"
    ):
        name1 = input("What is your name player1? ")
        name2 = input("What is your name player2? ")
        while count < plays:
            try:
                player1 = input(f"What character do you want to play {name1}? ")
                player2 = input(f"What character do you want to play {name2}? ")
                if (
                    player1.title() in Human_characters
                    and player2.title() in Human_characters
                ):
                    print("Player1: ", player1.title())
                    print("Player2: ", player2.title())

                    if player1 == "rock" and player2 == "rock":
                        print("Draw")
                        print("")
                        count += 1

                    elif player1 == "paper" and player2 == "paper":
                        print("Draw")
                        print("")
                        count += 1

                    elif player1 == "scissors" and player2 == "scissors":
                        print("Draw")
                        print("")
                        count += 1

                    elif player1 == "rock" and player2 == "paper":
                        print(f"{name2} Wins This Round")
                        print("")
                        count += 1
                        P2wins += 1

                    elif player1 == "rock" and player2 == "scissors":
                        print(f"{name1} Wins This Round")
                        print("")
                        count += 1
                        P1wins += 1

                    elif player1 == "paper" and player2 == "scissors":
                        print("Computer Wins This Round")
                        print("")
                        count += 1
                        P2wins += 1

                    elif player1 == "paper" and player2 == "rock":
                        print(f"{name1} Wins This Round")
                        print("")
                        count += 1
                        P1wins += 1

                    elif player1 == "scissors" and player2 == "rock":
                        print(f"{name2} Wins This Round")
                        print("")
                        count += 1
                        P2wins += 1

                    elif human.lower() == "scissors" and player2 == "paper":
                        print(f"{name1} Wins This Round")
                        print("")
                        count += 1
                        P1wins += 1

            except:
                print("Please insert a valid input")

        if P1wins == P2wins:
            print("Its a Draw")

        elif P1wins < P2wins:
            print(f"{name2} Wins The Game !!Congratulations!!")

        else:
            print(f"{name2} Wins The Game !!Congratulations!!")


if __name__ == "__main__":
    main()





































































































# def main():



#     x = input("Choose game: ")


#     print(is_game(x))



# def is_game(game):

#     games = ["Hangman", "Tic-Tac-Toe", "Rock-Paper-Scissors"]

#     while True:
#         try:
#             x = input("Choose game: ")
#             if game.title() in games:
#                 return True
#             break


#         except:
#             pass


# if __name__=="__main__":
#     main()












# def choose_game():
#     games = ["Hangman", "Tic-Tac-Toe", "Rock-Paper-Scissors"]
#     for game in games:
#         print(f"{game}")

#     while True:
#         try:
#             user_game = input("Choose a game: ").title()
#             if (user_game in games) or (
#                 user_game == "H" or user_game == "T" or user_game == "R"
#             ):
#                 break

#         except:
#             pass

#     return user_game
