from django.contrib.auth import authenticate, login, logout
from django.db import IntegrityError
from django.http import HttpResponse, HttpResponseRedirect
from django.shortcuts import render
from django.urls import reverse
from django.contrib.auth.decorators import login_required
from .models import User, Auction, Bid, Comments, Category, Watchlist

def index(request):
    listing = Auction.objects.filter(active=True)
    categories = Category.objects.all()
    
    return render(request, "auctions/index.html", {
        "auction": listing, "categories": categories
    })

def categories(request):
    if request.method == "GET":
        category_name = request.GET.get("category")
        category = Category.objects.get(category=category_name)
        auctionCategory = Auction.objects.filter(active=True, category=category)
        return render(request, "auctions/categories.html", {
            "auctions": auctionCategory, "category": category
        })

def new(request):
    if request.method == "GET":
        allcategories = Category.objects.all()
        return render(request, "auctions/new.html", {
            "category": allcategories
        })
    
    else:
        title = request.POST["title"]
        description = request.POST["description"]
        price = request.POST["bid"]
        URL = request.POST["imgURL"]
        category = request.POST["category"]
        user = request.user

        newbid = Bid(bidder = user, bid = price)
        newbid.save()

        currentCategory = Category.objects.get(category = category)

        auction = Auction(title = title, image = URL, description = description, price = newbid, category = currentCategory, itemOwner = user, bid = newbid.bid)
        auction.save()

        return HttpResponseRedirect(reverse(index))
    
def auction(request, id):
    auctionId = Auction.objects.get(pk=id)
    allcomments = Comments.objects.filter(auction=auctionId)
    watchlist = False
    if request.method == "GET":
        return render(request, "auctions/auction.html", {
            "auction": auctionId, "comments": allcomments
        })

@login_required  
def bid(request, id):
    auctionId = Auction.objects.get(pk=id)
    if request.method == "POST":
        bid = request.POST["bids"]
        bidder = request.user
        if int(bid) > auctionId.price.bid:
            allBid = Bid.objects.create(bidder = bidder, bid = bid)
            allBid.save()
            auctionId.bid = bid
            auctionId.save()
            bidder = request.user.username
            return render(request, "auctions/auction.html", {
             "auction": auctionId, "Bid": allBid
            })
        else:
            return render(request, "auctions/auction.html", {
                "auction": auctionId
            })

@login_required
def addWatchlist(request, id):
    auctionId = Auction.objects.get(pk=id)
    if request.method == "POST":
        watchlist = Watchlist(user = request.user, auction= auctionId)
        watchlist.save()
        auctionId.isInWatchlist = True
        auctionId.save()
    watchlist1 = True
    return render(request, "auctions/auction.html",{
        "auction": auctionId, "watchlist": watchlist1
    })

@login_required
def removeWatchlist(request, id):
    auctionId = Auction.objects.get(pk=id)
    if request.method == "POST":
        watchlist = Watchlist.objects.filter(user= request.user, auction=auctionId)
        if watchlist:
            watchlist.delete()
        auctionId.isInWatchlist = False
        auctionId.save()
    watchlist1 = False
    return render(request, "auctions/auction.html",{
        "auction": auctionId, "watchlist": watchlist1
    })

@login_required       
def watchlist(request):
    watchlist = Watchlist.objects.filter(user=request.user)
    return render(request, "auctions/watchlist.html",{
        "watchlist": watchlist
    })

@login_required
def closeAuction(request, id):
    auctionId = Auction.objects.get(pk=id)
    if request.user == auctionId.itemOwner:
        auctionId.active = False 
        auctionId.save()
        auctions = Auction.objects.filter(active=True, itemOwner=request.user)
        return render(request, "auctions/index.html", {
            "auctions": auctions, 
        })
    
def comment(request, id):
    user = request.user
    auction = Auction.objects.get(pk=id)
    comment = request.POST["comment"]
    Comment = Comments(author=user, auction=auction, comment=comment)
    Comment.save()

    return HttpResponseRedirect(reverse("auction", args=(id, )))

def login_view(request):
    if request.method == "POST":

        # Attempt to sign user in
        username = request.POST["username"]
        password = request.POST["password"]
        user = authenticate(request, username=username, password=password)

        # Check if authentication successful
        if user is not None:
            login(request, user)
            return HttpResponseRedirect(reverse("index"))
        else:
            return render(request, "auctions/login.html", {
                "message": "Invalid username and/or password."
            })
    else:
        return render(request, "auctions/login.html")

def logout_view(request):
    logout(request)
    return HttpResponseRedirect(reverse("index"))

def register(request):
    if request.method == "POST":
        username = request.POST["username"]
        email = request.POST["email"]

        # Ensure password matches confirmation
        password = request.POST["password"]
        confirmation = request.POST["confirmation"]
        if password != confirmation:
            return render(request, "auctions/register.html", {
                "message": "Passwords must match."
            })

        # Attempt to create new user
        try:
            user = User.objects.create_user(username, email, password)
            user.save()
        except IntegrityError:
            return render(request, "auctions/register.html", {
                "message": "Username already taken."
            })
        login(request, user)
        return HttpResponseRedirect(reverse("index"))
    else:
        return render(request, "auctions/register.html")