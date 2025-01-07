from seasons import get_time, num_to_words



def test_get_time():
    assert get_time("1990-01-01") == 17714880
    assert get_time("2020-01-01") == 1936800
    assert get_time("2011-11-11") == 6217920


def test_num_to_words():
    assert num_to_words(17714880) == "seventeen million, seven hundred fourteen thousand, eight hundred eighty"
    assert num_to_words(1936800) == "one million, nine hundred thirty-six thousand, eight hundred"
    assert num_to_words(6217920) == "six million, two hundred seventeen thousand, nine hundred twenty"