﻿var image_number = 0;
var max_page = 0;
function reqListener() {
    var data = JSON.parse(this.responseText);
    
    document.getElementById('image').setAttribute("src", data["path"]);
}
function countListener() {
    var data = JSON.parse(this.responseText);
    max_page = data['count'];
    var button_prev = document.getElementById("previous");
    var button_next = document.getElementById("next");
    if (image_number == 0) {
        button_prev.setAttribute("disabled", "true");
    }
    else {
        button_prev.removeAttribute("disabled");
    }
    if (image_number == max_page) {
        button_next.setAttribute("disabled", "true");
    }
    else {
        button_next.removeAttribute("disabled");
    }
    load_image(image_number);
}
function load_max(page: any) {
    var oReq = new XMLHttpRequest();
    oReq.onload = countListener;
    oReq.open("GET", "http://localhost:3035/Home/Count", true);
    oReq.send();
}
function load_image(page: any) {
    var oReq = new XMLHttpRequest();
    oReq.onload = reqListener;
    oReq.open("GET", "http://localhost:3035/Home/ForType/" + page, true);
    oReq.send();
}
function change_page(page: any) {
    image_number = page;
    load_max(image_number);
}
change_page(image_number);
var elems = document.getElementsByTagName('button');
for (var i = 0, il = elems.length; i < il; i++) {
    elems[i].onclick = change_page;
}

