def main():

    fraction = input("Fraction: ")
    print(gauge(convert(fraction)))



def convert(fraction):
        while True:
            try:
                x, y = fraction.split("/")
                x_new = int(x)
                y_new = int(y)
                z = x_new / y_new

                if z <= 1:
                    p = int(z * 100)
                    return p

                else:
                     fraction = input("Fraction: ")
                     pass

            except ( ValueError , ZeroDivisionError):
                raise


def gauge(percentage):

        if percentage >= 0 and percentage <= 1:
            return "E"

        elif percentage >= 99 and percentage <= 100:
            return "F"

        else: return str(percentage) + "%"



if __name__ == "__main__":
    main()


