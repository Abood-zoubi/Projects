import csv
import sys


if len(sys.argv) < 3:
    sys.exit("Too few command-line arguments")

elif len(sys.argv) > 3:
    sys.exit("Too many command-line arguments")

else:
    list = []

    try:
        with open(sys.argv[1], "r") as csvfile:
            reader = csv.DictReader(csvfile)

            for row in reader:
                splited_name = row["name"].split(",")

                list.append(
                    {
                        "first": splited_name[1].lstrip(),
                        "last": splited_name[0],
                        "house": row["house"],
                    }
                )

    except FileNotFoundError:
        sys.exit("Could not read", sys.argv[1])

    with open(sys.argv[2], "w") as csvfile:
        writer = csv.DictWriter(csvfile, fieldnames=["first", "last", "house"])
        writer.writerow({"first": "first", "lacst": "last", "house": "house"})
        for row in list:
            writer.writerow(
                {"first": row["first"], "last": row["last"], "house": row["house"]}
            )
