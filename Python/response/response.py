from validator_collection import validators, checkers, errors

email = input("Whats ur email ? ")

try:
    email_address = validators.email(email)
    print("Valid")
except:
    print("Invalid")