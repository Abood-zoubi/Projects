from django.shortcuts import render
from . import util
from markdown2 import Markdown
from random import choice
from django.utils.safestring import mark_safe


def index(request):
    return render(request, "encyclopedia/index.html", {
        "entries": util.list_entries()
    })

def open(request, title):
    content = convert_markdown(title)
    if content == None:    
        return render(request, "encyclopedia/error.html",{
            "error": f'No Such Entry As "{title.title()}"', "title": "Page Not Found"
        })
    
    else:
        return render(request, "encyclopedia/title.html",{
            "data": mark_safe(content), "title": title
        })
    
def search(request):
    if request.method == "POST":
        search_data = request.POST["q"]
        search_result = []
        if convert_markdown(search_data) == None:
            entries = util.list_entries()
            for item in entries:
                if search_data.lower() in item.lower():
                    search_result.append(item)
                    
            return render(request, "encyclopedia/search.html", {
                "title": "Search Results",  "data": search_result, "no_result": search_data.title()
            }) 

        else: 
            return render(request, "encyclopedia/title.html", {
                "title": search_data.title(), "data": convert_markdown(search_data)
        })


def new(request):
    if request.method == "GET":
        return render(request, "encyclopedia/new.html")
    
    else:
        title = request.POST["title"]
        description = request.POST["description"] 
        exist = util.get_entry(title)
        if exist is not None:
            return render(request, "encyclopedia/error.html", {
                "title": "Error", "error": "Page Already Exist"
            })
        else:
            Page = util.save_entry(title, description)
            return render(request, "encyclopedia/title.html", {
                "title": title, "data": convert_markdown(title)
            })

def edit(request):
    if request.method == "POST":
        if 'page_title' in request.POST:
            title = request.POST["page_title"]
            description = util.get_entry(title)
            return render(request, "encyclopedia/edit.html", {
                "title": title, "description": description
            })
        
    new_title = request.POST["title"]
    new_description = request.POST["description"]

    util.save_entry(new_title, new_description)
    return render(request, "encyclopedia/title.html", {
        "title": new_title, "data": convert_markdown(new_title)
    })

def random(request):
    list = util.list_entries()
    empty = []
    for item in list:
        empty.append(item)

    rand = choice(empty)

    return render(request, "encyclopedia/title.html", {
        "title": rand, "data": convert_markdown(rand)
    })

def convert_markdown(title):
    topic = util.get_entry(title)
    markdowner = Markdown()
    if topic == None:
        return None
    else:
        return mark_safe(markdowner.convert(topic))