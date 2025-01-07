def main():
    Tic_Tac_Toe()


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


if __name__ == "__main__":
    main()
