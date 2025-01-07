from um import count


# sorry for yelling
def test_UPPERCASE_UM():
    assert count("UM") == 1
    assert count("UM, HI MY NAME IS ABDULRAHMAN") == 1
    assert count("UM, HEY, UM , YOU") == 2


def test_lowercase_um():
    assert count("um") == 1
    assert count("um, hi my name is abdulrahman") == 1
    assert count("um, hey, um, you") == 2

def test_um_with_words():
    assert count("yummy") == 0
    assert count("yum") == 0