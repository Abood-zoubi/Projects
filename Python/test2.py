import cv2

img_location = "C:\Users\zoubi\Desktop\my stuff\data"
filename = "333923286_767270178101525_2728013072840416972_n"

img = cv2.imread(img_location + filename)

cv2.imshow('Original Image', img)
cv2.waitKey(0)
