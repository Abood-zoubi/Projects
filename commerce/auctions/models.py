from django.contrib.auth.models import AbstractUser
from django.db import models


class User(AbstractUser):
    pass


class Category(models.Model):
    category = models.CharField(max_length = 64)

    def __str__(self):
        return self.category
    
class Bid(models.Model):
    bidder = models.ForeignKey(User, on_delete = models.CASCADE, null = True, related_name= "bidder_name")
    bid = models.IntegerField(default = 0)

   # def __str__(self):
    #  return self.bid


class Auction(models.Model):
    title = models.CharField(max_length = 64)
    image = models.CharField(max_length = 2000, null = True, blank = True)
    description = models.CharField(max_length = 255)
    price = models.ForeignKey(Bid, on_delete = models.CASCADE, null = True, related_name= "BidPrice")
    itemOwner = models.ForeignKey(User, on_delete = models.CASCADE, null = True, related_name= "ITEM_OWNER")
    category = models.ForeignKey(Category, on_delete = models.CASCADE, null = True)
    active = models.BooleanField(default=True)
    bid = models.IntegerField(default = price, blank = True)
    isInWatchlist = models.BooleanField(default = False)

    def __str__(self):
        return self.title


class Comments(models.Model):
    author = models.CharField(max_length = 64)
    auction = models.ForeignKey(Auction, on_delete = models.CASCADE, null = True,related_name = "auction_comment")
    comment = models.CharField(max_length = 500)


class Watchlist(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)
    auction = models.ForeignKey(Auction, on_delete=models.CASCADE)

    def __str__(self):
        return f"{self.user.username}'s watchlist for {self.auction.title}"