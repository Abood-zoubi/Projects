from twttr import shorten


def test_normal():

    assert shorten("hello") == "hll"
    assert shorten("The weather is good today") == "Th wthr s gd tdy"


def test_integers():

    assert shorten("2") == "2"
    assert shorten("-1") == "-1"
    assert shorten("0") == "0"


def test_correct():

    assert shorten("hll") == "hll"
    assert shorten("CS50P") == "CS50P"



def test_upper_and_mixed_case():

    assert shorten("HELLO") == "HLL"
    assert shorten("HeLlO") == "HLl"


def test_punctuations():
    assert shorten("][:)!@") == "][:)!@"





