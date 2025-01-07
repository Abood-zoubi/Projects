while True:
    fraction = input("Fraction: ")
    try:
        x, y = fraction.split("/")
        x_new = int(x)
        y_new = int(y)
        z = x_new / y_new

        if z <= 1:
            break

    except ( ValueError , ZeroDivisionError):
        pass

k = int(round(z * 100))
if k >= 0 and k <= 1:
    print("E")

elif k >= 99 and k <= 100:
    print("F")

else: print(f"{k}%")


