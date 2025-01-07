import pytest
from jar import Jar


def test_init():
    jar = Jar()
    assert jar.capacity == 12

def test_str():
    jar = Jar()
    assert str(jar) == ""
    jar.deposit(1)
    assert str(jar) == "🍪"
    jar.deposit(11)
    assert str(jar) == "🍪🍪🍪🍪🍪🍪🍪🍪🍪🍪🍪🍪"


def test_deposit():
    jar = Jar()
    with pytest.raises(ValueError):
        jar.deposit(35)

    jar.deposit(2)
    assert jar.size == 2


def test_withdraw():
    jar = Jar()
    jar.deposit(5)
    jar.withdraw(5)
    assert jar.size == 0

    jar.deposit(6)
    jar.withdraw(3)
    assert jar.size == 3

    jar.deposit(10)
    with pytest.raises(ValueError):
        jar.withdraw(35)
