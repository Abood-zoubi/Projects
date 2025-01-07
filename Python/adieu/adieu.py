import inflect

p = inflect.engine()

Name = []

while True:
    try:
        name = input("Name: ")
        Name.append(name)
    except EOFError:
        print()
        break

GreetingTo = p.join((Name))
print("Adieu, adieu, to " + GreetingTo)
