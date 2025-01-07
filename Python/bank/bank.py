Greeting = input("Greeting: ").lower()

if "hello" in Greeting :
    print("$0")

# elif "h" in Greeting also works but not accurate
elif Greeting.startswith("h") :
    print("$20")

else : print("$100")