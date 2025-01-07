months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
]

while True:
    date = input("Date: ").strip()

    try:
        # y = months and x = days and z = years
        y, x, z = date.split("/")

        y = y.replace(" ", "")
        z = z.replace(" ", "")

        if int(y) >= 1 and int(y) <= 12:
            break

        elif int(x) >= 1 and int(x) <= 31:
            break

    except:
        try:
            old_y, old_x, z = date.split(" ")

            for i in range(len(months)):
                if old_y == months[i]:
                    y = i + 1

            for i in range(len(months[i])):
                if old_y == months:
                    y = i + 1

            x = old_x.replace(",", "")

            if (int(y) >= 1 and int(y) <= 12) and (int(x) >= 1 and int(x) <= 31):
                break

        except:
            print()
            pass



print(f"{z}-{int(y):02}-{int(x):02}")


## First encounter

# date = input("Date: ")

# x , y ,z = date.split(" " or ", " or "/")

# print(x)
# months = [
#   "January",
#   "February",
#   "March",
#   "April",
#   "May",
#   "June",
#   "July",
#   "August",
#   "September",
#   "October",
#   "November",
#   "December"
# ]

# while True:
#   try:
#      if date == x + y +z:
#         print(z , x, y)

#       elif
