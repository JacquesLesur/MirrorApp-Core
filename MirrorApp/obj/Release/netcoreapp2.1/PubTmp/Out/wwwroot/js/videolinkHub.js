"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/videolinkHub").build();


connection.on("ChangeLinkJs", function (videoLink) {
    //console.log(videoLink);
    document.getElementById('linkYoutube').src = videoLink;
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

 function call () {
     connection.invoke("ChangeVideoLink").catch(function (err) {
         console.log("refresh");
        return console.error(err.toString());
    });
    event.preventDefault();
};

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    connection.invoke("ChangeVideoLink", "test").catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});