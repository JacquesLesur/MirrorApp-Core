"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/videolinkHub").build();


connection.on("ChangeLinkJs", function (videoLink) {
    //console.log(videoLink);
    var actualLink = document.getElementById('linkYoutube').src;
    if (videoLink != actualLink) {
        document.getElementById('linkYoutube').src = videoLink;
    }
    
});

connection.on("ChangeCitationJs", function (citation) {
    console.log(citation);
    var actualCitation = document.getElementById('citation').src;
    if (citation != actualCitation) {
        document.getElementById('citation').innerHTML  = citation;
    }

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
     connection.invoke("ChangeCitation").catch(function (err) {
         console.log("refresh");
         return console.error(err.toString());
     });
   
};

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    connection.invoke("ChangeVideoLink", "test").catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});