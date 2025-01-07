import sys
from PIL import Image
from PIL import ImageOps


if len(sys.argv) <= 2:
    sys.exit("Too few command-line arguments")

elif len(sys.argv) >= 4:
    sys.exit("Too many command-line arguments")

else:
    try:
        if (sys.argv[1].endswith(".png") and sys.argv[2].endswith(".png")) or (sys.argv[1].endswith(".jpg") and sys.argv[2].endswith(".jpg")) or (sys.argv[1].endswith(".jpeg") and sys.argv[2].endswith(".jpeg")):
            image = Image.open(sys.argv[1])
            shirt = Image.open("shirt.png")
            size= shirt.size
            photo = ImageOps.fit(image, size, bleed=0.0, centering=(0.5, 0.5))
            photo.paste(shirt, shirt)
            photo.save(sys.argv[2], format=None)

        else:
            sys.exit("Input and output have different extensions")

    except FileNotFoundError:
        sys.exit("Input does not exist")

