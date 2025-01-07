from datetime import date
import sys
import inflect


def main():
    DOB = input("Date of Birth: ")
    print(num_to_words(get_time(DOB)).capitalize().strip() + " minutes")



def get_time(s):


    try:
        year,month,day = s.split("-")
        today = date.today()
        if int(year) > today.year:
            return "Invalid date"

        elif int(month) > 12:
            return "Invalid date"

        elif int(day) > 31:
            return "Invalid date"

        birthday = date(int(year),int(month),int(day))

        time_from_birth = today - birthday
        time_in_minutes = time_from_birth.days * 1440

        return time_in_minutes

    except:
        sys.exit("Invalid date")


def num_to_words(s):
    p = inflect.engine()

    words = p.number_to_words(s,andword="")

    return words.strip()


if __name__ == "__main__":
    main()