import re
# Used the https://regex101.com website to test regexes before implementing
# It not cheating


def main():

    HTML = parse(input("HTML: "))
    print(HTML)

def parse(s):
    ...
    if iframe := re.search(r"<iframe(.*)><\/iframe>", s.lower()):
        if matches := re.search(r"(https?:\/{2})(?:www\.)?(youtu)(be)\.com\/embed\/(\w+)\"(?:.*)", s, re.IGNORECASE):
            return "https://" + matches.group(2)+ "." + matches.group(3) + "/" + matches.group(4)

if __name__ == "__main__":
    main()