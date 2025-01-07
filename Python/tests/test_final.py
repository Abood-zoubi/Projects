from FinalProjectDevelopment import greetstaff
from FinalProjectDevelopment import choose_game
from FinalProjectDevelopment import repeat





def test_greetstaff():
    assert greetstaff("David Malan") == "Proffesor David, thank you for giving and explaining the course perfectly, it was very useful and knowledgeable, you are the best :)"
    assert greetstaff("John Harvard") == "Hello John Harvard. Welcome to my project, hope you have fun"


def test_choose_game():
    assert choose_game("Hangman") == "Hangman"
    assert choose_game("Tic-Tac-Toe") == "Tic-Tac-Toe"
    assert choose_game("Rock-Paper-Scissors") == "Rock-Paper-Scissors"
    assert choose_game("h") == "Hangman"
    assert choose_game("t") == "Tic-Tac-Toe"
    assert choose_game("r") == "Rock-Paper-Scissors"

def test_repeat():
    assert repeat("Yes") == "Yes"
    assert repeat("Y") == "Y"
    assert repeat("HI") == False
    assert repeat("yes") == "yes"
    assert repeat("y") == "y"

