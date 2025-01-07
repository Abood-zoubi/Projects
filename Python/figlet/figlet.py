from pyfiglet import Figlet
import random
import sys


figlet = Figlet()

# To check if user inputed anything after program name
if len(sys.argv) == 1:
    x = True

# to check if user inputed the correct type required
elif len(sys.argv) == 3 and (sys.argv[1] == "-f" or sys.argv[1] == "--font"):
    x = False

# to exit program if none of the requirments are met
else: sys.exit(1)


# to get font types
figlet.getFonts()



# to select the type of font user asked for
if x == False:
   try:
     figlet.setFont(font=sys.argv[2])

# to output error message if user inputed an invalid type of font
   except:
    print("Invalid usage")
    sys.exit(1)

# to select random type of font 
else:
    font = random.choice(figlet.getFonts())


#gets input from user
y = input("Input: ")



# To output edited text
print("output: " + figlet.renderText(y))