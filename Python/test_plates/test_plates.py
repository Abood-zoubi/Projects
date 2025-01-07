from plates import is_valid



def test_start_with_two_letters():

    assert is_valid("PC6000") == True
    assert is_valid("p6000") == False


def test_no_letters_at_end():

    assert is_valid("AB500Z") == False
    assert is_valid("EH695G") == False
    assert is_valid("FHX809") == True


def test_max_char():

    assert is_valid("TJ3482") == True
    assert is_valid("EH6300") == True
    assert is_valid("ETB27490") == False


def test_min_char():

    assert is_valid("AA") == True
    assert is_valid("A") == False
    assert is_valid("4") == False


def test_first_not_zero():

    assert is_valid("ABC090") == False
    assert is_valid("TEN007") == False


def test_no_punctuations():

    assert is_valid("!@$%&$") == False
    assert is_valid("AR7!58") == False


def test_no_space():

    assert is_valid("AH8 256") == False
    assert is_valid("A T375") == False


def test_no_periods():

    assert is_valid("GE.9781") == False
    assert is_valid("HR7.910") == False