import re
import sys

def main():
    time = input("Hours: ")
    print(convert_time(time))


def convert_time(t):
    if matches := re.search(r"^(\d{1,2}):?(\d{2})? (AM|PM) to (\d{1,2}):?(\d{2})? (AM|PM)$",t.upper(), re.IGNORECASE,):
        if matches.group(2):
            if int(matches.group(2)) > 59:
                raise ValueError

        if matches.group(5):
            if int(matches.group(5)) > 59:
                raise ValueError

        first = int(matches.group(1))
        if "PM" in matches.group(3):
            if first > 12:
                raise ValueError

            elif first == 12:
                first = 12

            else:
                first += 12

        elif "AM" in matches.group(3) and int(matches.group(1)) == 12:
            first -= 12

        if matches.group(2) == None:
            hm1 = f"{first:02}:00"

        else:
            hm1 = f"{first:02}:{matches.group(2):02}"

        second = int(matches.group(4))
        if "PM" in matches.group(6):
            if second > 12:
                raise ValueError
            elif second == 12:
                second = 12

            else:
                second += 12

        elif "AM" in matches.group(6) and int(matches.group(4)) == 12:
            second -= 12


        if matches.group(5) == None:
            hm2 = f"{second:02}:00"

        else:
            hm2 = f"{second:02}:{matches.group(5):02}"


        times = hm1 + " to " + hm2
        return times

    else:
        raise ValueError



if __name__ == "__main__":
    main()


