def main():

    text = input("Input: ")
    txt = text.lower()

    print("Output: ",shorten(txt))


def shorten(k):

    k_no_vowels = ""
    try:
        for letter in k:
            if not letter.lower() in ["a" ,"e" , "i", "o", "u"]:

                k_no_vowels += letter

        return k_no_vowels

    except TypeError:
        pass

if __name__ == "__main__":
    main()