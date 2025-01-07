import sys
import csv
from tabulate import tabulate


if len(sys.argv) == 1:
    sys.exit("Too few command-line arguments")

elif len(sys.argv) >= 3:
    sys.exit("Too many command-line arguments")

else:
    table = []
    try:
        if sys.argv[1].endswith(".csv"):
            with open(sys.argv[1], "r") as csvfile:
                reader = csv.reader(csvfile)
                for row in reader:
                    table.append(row)
            print(tabulate(table[1:], headers=table[0], tablefmt="grid"))

        else:
            sys.exit("Not a CSV file")

    except FileNotFoundError:
        sys.exit("File does not exist")
