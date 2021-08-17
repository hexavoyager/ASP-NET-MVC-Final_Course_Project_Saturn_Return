
function displayStopover(select) {
    let stopoverDiv = document.getElementById("stopover");

    if (select.value == "0") {
        $("#atmosphere").hide();
        $("#infoJupiter").hide();
    }
    else {
        
        $.ajax({
            url: "GetPlanetInfo/" + select.value,
            dataType: "html",
            type: "get",
            success: function (data) {
                $("#atmosphere").show();
                $("#atmosphere").html(data);
            },
            error: function (data) {
                $("#atmosphere").html("<p class=\"alert - danger\">Bad request...</p>");
            }
        });
    }

    if (select.value == "1")
        stopoverDiv.style.display = "block";
    else {
        stopoverDiv.style.display = "none";
        document.getElementById("stopoverInput").checked = false;


    }
        
}

function onStopoverChange() {
    if ($("#stopoverInput").prop("checked") == true) {
        $.ajax({
            url: "GetPlanetInfo/2",
            dataType: "html",
            type: "get",
            success: function (data) {
                $("#infoJupiter").show();
                $("#infoJupiter").html(data);
            },
            error: function (data) {
                $("#infoJupiter").html("<p class=\"alert - danger\">Bad request...</p>");
            }
        });
    } else {
        $("#infoJupiter").hide();
    }
}

