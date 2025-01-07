import sys

def main():

    if len(sys.argv) < 2:
        sys.exit("Too few command-line arguments")

    elif len(sys.argv) > 2:
        sys.ext("Too many command-line arguments")

    else:
        try:
            if sys.argv[1].endswith(".py"):
                file = open(sys.argv[1], "r")
                lines = file.readlines()
                counter = 0
                for line in lines:
                    if comment_or_empty(line) == True:
                        counter += 1
                print(counter)

            else:
                sys.exit("Not a Python file")

        except FileNotFoundError:
            sys.exit("File does not exist")

def comment_or_empty(line):
    if line.isspace():
        return False

    elif line.lstrip().startswith("#"):
        return False

    elif line.lstrip().startswith("'''"):
        return False

    else:
        return True

if __name__ == "__main__":
    main()