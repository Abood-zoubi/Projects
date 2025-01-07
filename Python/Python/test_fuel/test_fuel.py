from fuel import convert
from fuel import gauge
import pytest




def test_normal_convert():

    assert convert("2/4") == 50
    assert convert("3/4") == 75


def test_normal_gauge():

    assert gauge(75) == "75%"
    assert gauge(25) == "25%"


def test_ZeroDivisionError():

    with pytest.raises(ZeroDivisionError):
        convert("76/00")


def test_ValueError():

    with pytest.raises(ValueError):
        convert("he/him")



