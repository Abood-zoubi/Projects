import re


def main():
    text = input("Text: ")
    print(count(text))


def count(s):
    ...
    words = re.findall(r"\b\W*(um)\W*\b",s.lower(), re.IGNORECASE)
    count = 0
    for word in words:
        if "um" in word:
            count += 1

    return count

...


if __name__ == "__main__":
    main()