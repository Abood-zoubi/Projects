from django.contrib import admin
from .models import User, Auction, Bid, Comments, Category, Watchlist

# Register your models here.

admin.site.register(User)
admin.site.register(Auction)
admin.site.register(Bid)
admin.site.register(Comments)
admin.site.register(Category)
admin.site.register(Watchlist)