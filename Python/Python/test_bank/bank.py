def main():


    welcome = input("Greeting: ").lower()

    print("$", value(welcome))

def value(Greeting):

    if "hello" in Greeting :
        return 0
    # elif "h" in Greeting also works but not accurate
    elif Greeting.startswith("h") :
        return 20

    else : return 100



if __name__ == "__main__":
    main()

