def main():
    time = input("what time is it? ")

    time2 = convert(time)

    if time2 >= 7 and time2 <= 8 :
        print("breakfast time")

    elif time2 >= 12 and time2 <= 13 :
        print("lunch time")

    elif time2 >= 18 and time2 <= 19 :
        print("dinner time")

def convert(time):
    hours, minutes = time.split(":")

    new_minutes = float(minutes) / 60

    return float(hours) + new_minutes

if __name__ == "__main__":
    main()