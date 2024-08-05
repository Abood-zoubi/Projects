from django.urls import path

from . import views

urlpatterns = [
    path("", views.index, name="index"),
    path("login", views.login_view, name="login"),
    path("logout", views.logout_view, name="logout"),
    path("register", views.register, name="register"),
    path("new", views.new, name="new"),
    path("auction/<int:id>", views.auction, name="auction"),
    path("bid/<int:id>", views.bid, name="bid"),
    path("watchlist", views.watchlist, name="watchlist"),
    path("addWatchlist/<int:id>/", views.addWatchlist, name="addWatchlist"),
    path("removeWatchlist/<int:id>/", views.removeWatchlist, name="removeWatchlist"),
    path("close/<int:id>/", views.closeAuction, name="close"),
    path("categories", views.categories, name="categories"),
    path("comment/<int:id>/", views.comment, name="addComment"),
    
]
            