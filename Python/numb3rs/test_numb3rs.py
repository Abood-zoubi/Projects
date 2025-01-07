from numb3rs import validate




def test_correct():
    assert validate("1.2.3.4") == True
    assert validate("125.125.125.125") == True
    assert validate("3456.435.678.457") == False
    assert validate("13431.6.7.32") == False
    assert validate("2550.255.255.256") == False


def test_Alphabet():
    assert validate("cat") == False
    assert validate("this is cs50") == False
    assert validate("cwe542") == False


