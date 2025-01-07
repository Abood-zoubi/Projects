groceries = {}

while True:
    try:
        items = input().lower()

        if items in groceries:
            groceries[items] += 1

        else:
            groceries[items] = 1


    except EOFError:

        # ???????????????
        for key in sorted(groceries.keys()):
            print(groceries[key], key.upper())

        break