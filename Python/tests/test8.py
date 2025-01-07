from test7 import is_game



def test_play_game():

    assert is_game("Hangman") == "Hangman"
    assert is_game("Tic-Tac-Toe") == "Tic-Tac-Toe"
    assert is_game("R") == "Rock-Paper-Scissors"



