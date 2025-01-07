import re


def main():

    IPv4Address = validate(input("IPv4 Address: "))
    print(IPv4Address)


def validate(ip):
    ...
    if matches := re.search(r"^([0-9])+\.([0-9])+\.([0-9])+\.([0-9])+$", ip):
        numbers = ip.split(".")
        for number in numbers:
            if int(number) > 255 or int(number) < 0:
                return False

        return True

    else:
        return False
...


if __name__ == "__main__":
    main()