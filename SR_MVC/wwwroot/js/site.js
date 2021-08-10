// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function displayStopover(select) {
    let stopoverDiv = document.getElementById("stopover");

    if (select.value == "1")
        stopoverDiv.style.display = "block";
    else {
        stopoverDiv.style.display = "none";
        document.getElementById("stopoverInput").checked = false;
    }
        
}