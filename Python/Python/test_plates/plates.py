def main():
    plate = input("Plate: ")
    if is_valid(plate):
        print("Valid")
    else:
        print("Invalid")


def is_valid(s):
    if len(s) < 2 or len(s) > 6 :
        return False

    if s[0].isalpha() == False or s[1].isalpha() == False:
        return False

    i = 0
    while i < len(s):
        # i = counter for characters if s
        #if not all characters of s is alphabetical
        if s[i].isalpha() == False:
            # if the value of i is 0 return false
            # first number should not be 0
            if s[i] == "0":
                return False
            else: break
        i += 1


    for i in range(len(s)):
      if s[i].isdigit():
         if not s[i:].isdigit():
            return False


    for j in s:
        if j == ["." , " " , "!" , "?"]:
            return False

        else: return True


if __name__ == "__main__":
    main()






















        #i = 0
   # for i in s:
    #    if i.isdigit():
     #       index = s.index(i)
      #  if not s[index:].isdigit():
       #     return False
   # i += 1