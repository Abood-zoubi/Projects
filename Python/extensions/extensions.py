Name = input("File name: ").lower().strip()

if Name.endswith(".jpg") or Name.endswith(".jpeg"):
    print("image/jpeg")

elif Name.endswith(".gif"):
    print("image/gif")

elif Name.endswith(".png"):
    print("image/png")

elif Name.endswith(".pdf"):
    print("application/pdf")

elif Name.endswith(".txt"):
    print("text/plain")

elif Name.endswith(".zip"):
    print("application/zip")

else : print("application/octet-stream")
