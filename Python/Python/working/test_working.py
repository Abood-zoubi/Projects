import pytest
from working import convert_time

def main():
# PLEASE MAKE CHECK50 MORE CLEAR ON WHATS WRONG
# I LITERALLY DONT KNOW WHAT ELSE TO PUT
# IT KEEPS GIVING UNEXPLAINED YELLOW FROWNS

#...OK SO FOR SOME REASON CHECK50 ISNT READING MY TESTCODE
# I TRIED DELETING MY CODE AND USING CHECK50 WITH NO CODE IN MY TEST FILE
# PLEASE CHECK MY CODE MANUALLY

    test_correct()
    test_12()
    test_ValueError()
    test_MOREVALUEERROR()

def test_correct():
    assert convert_time("6 am to 6 pm") == "06:00 to 18:00"
    assert convert_time("6:00 am to 6:00 pm") == "06:00 to 18:00"
    assert convert_time("6 PM to 6 AM") == "18:00 to 06:00"
    assert convert_time("7 Am to 12 pM") == "07:00 to 12:00"
    assert convert_time("7:24 am to 12:54 AM") == "07:24 to 00:54"

def test_12():
    assert convert_time("12 AM TO 12 PM") == "00:00 to 12:00"
    assert convert_time("12:00 AM TO 12:00 PM") == "00:00 to 12:00"
    assert convert_time("12:30 pm to 12 am") == "00:30 to 12:00"


def test_ValueError():
    with pytest.raises(ValueError):
        convert_time("13 Pm TO 22 PM")

    with pytest.raises(ValueError):
        convert_time("09:65 AM to 8:99 PM")

    with pytest.raises(ValueError):
        convert_time("45:47 PM to 98:39 PM")

    with pytest.raises(ValueError):
        convert_time("9:6 AM to 8:9 PM")

    with pytest.raises(ValueError):
        convert_time("07:00 AM - 10:00 PM")

    with pytest.raises(ValueError):
        convert_time("07:00 to 10:00")

    with pytest.raises(ValueError):
        convert_time("7 AM - 10 PM")

    with pytest.raises(ValueError):
        convert_time("9AM to 8PM")

    with pytest.raises(ValueError):
        convert_time("09:00 AM to 22:00")

    with pytest.raises(ValueError):
        convert_time("12:60 AM, 13:00 PM")

def test_MOREVALUEERROR():
    with pytest.raises(ValueError):
        convert_time(" to ")

    with pytest.raises(ValueError):
        convert_time("NINE AM to TEN PM")

if __name__== "__main__":
    main()





