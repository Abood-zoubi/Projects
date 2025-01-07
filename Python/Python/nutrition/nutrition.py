fruits = {
    "apple": 130,
    "avocado": 50,
    "banana": 110,
    "cantaloupe": 50,
    "grapefruit": 60,
    "grapes": 90,
    "honeydew melon": 50,
    "kiwifruit": 90,
    "lemon": 15,
    "lime": 60,
    "nectarine": 80,
    "orange": 60,
    "peach": 100,
    "pear": 100,
    "pineapple": 70,
    "plums": 130,
    "strawberries": 50,
    "sweet cherries": 100,
    "tangerine": 50,
    "watermelon": 80
}


item = input("Item: ")

for i in fruits:
    if i == item.lower():
        print("calories:", fruits[i])