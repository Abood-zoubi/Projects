from bank import value


def test_hello():

    assert value("hello") == 0
    assert value("HELLO") == 0


def test_start_with_h():

    assert value("hi") == 20
    assert value("howdy") == 20


def test_none_h():

    assert value("welcome") == 100
    assert value("") == 100

