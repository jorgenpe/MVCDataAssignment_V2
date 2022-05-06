// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


function getPeoples(url) {
    console.log("hej");
    $.get(url, function (response) {
        console.log(response);
        document.getElementById("PeoplesList").innerHTML = response;
    })
};

function infoById(url, inputId) {
    
    let inputElement = $("#" + inputId);
    
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    console.log(data);
    $.post(url,data, function (response) {
        console.log(response);
        document.getElementById("PeoplesList").innerHTML = response;
    })

};


function deleteById(url, inputDeleteId) {
    console.log("hej");
    let inputElement = $("#" + inputDeleteId);

    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    console.log(data);
    $.post(url, data, function (response) {
        console.log(response);
        document.getElementById("PeoplesList").innerHTML = response;
    })

};
