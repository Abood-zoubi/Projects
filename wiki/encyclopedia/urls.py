from django.urls import path

from . import views

urlpatterns = [
    path("", views.index, name="index"),
    path("<str:title>", views.open, name="open"),
    path("search/", views.search, name="search"), # type: ignore
    path("new/", views.new, name="new"),
    path("edit/", views.edit, name="edit"),
    path("/", views.random, name="random")
    ]

