import sys
import requests



if len(sys.argv) == 1:
    sys.exit("Missing command-line argument")

elif len(sys.argv) == 2:
    try:
        secondargument = float(sys.argv[1])
    except:
        sys.exit("Command-line argument is not a number")
else:
    pass


try:
    r = requests.get('https://api.coindesk.com/v1/bpi/currentprice.json', auth=('user', 'pass'))
    bitcoin_value_USD = r.json()["bpi"]["USD"]["rate_float"]

    value = bitcoin_value_USD * secondargument

    print(print(f"${value:,.4f}"))


except requests.RequestException:
    sys.exit(2)











