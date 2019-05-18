$( document ).ready(function() {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "API/UserWillPrepareRecipe/Index", false);
    xhttp.send();
    var result = JSON.parse(xhttp.responseText);
    
    var events = [];
    result.forEach(function (element) {
        var array = element.split(',');
        var i = {};
        i['id'] = array[0];
        i['title'] = array[1];
        i['start'] = moment(array[2]);
        i['end'] = moment(array[2]).add(array[3], "seconds");
        events.push(i);
    });
    
    $('#calendar').fullCalendar({
        header: {
            center: 'My Meal Calendar'
        },
        events: events,
        dayClick: function(date) {
            if(moment().isAfter(date)) {
                Swal.fire({
                    title: 'Choose a present or future date',
                    type: 'error'
                })
            } else {
                chooseRecipe(date)
            }
        },
        defaultView: 'agendaWeek',
        agendaEventMinHeight: 20,
        allDaySlot: false,
        selectable: true,
        eventClick: function(info) {
            eventClick(info);
        }

    });
});

function chooseRecipe(date) {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "API/Recipes", false);
    xhttp.send();
    var result = JSON.parse(xhttp.responseText);
    
    var select = "<div class='form-group'><select id='recipe' class='form-control'>";
    result.forEach(function(element) {
        select += "<option value='" + element.id + "'>" + element.name + "</option>"
    });
    select += "</select></div>";
    
    Swal.fire({
        title: 'Schedule recipe',
        html: "<form><div class='form-group'>" +
            "<input id='date' class='form-control' type='datetime-local' min='" + moment().format('YYYY-MM-DD[T]HH:MM') + "' value='" + date.format('YYYY-MM-DD[T]HH:MM') + "'>" +
            "</div>" + select + "</form>", 
        type: 'info',
        showCancelButton: true,
        confirmButtonText: 'Schedule',
        showLoaderOnConfirm: true,
        preConfirm: function() {
            return fetch("API/UserWillPrepareRecipe/Create/" + $('#recipe').val() + "/" + $('#date').val())
                .then(function (response) {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.text()
                })
                .catch(function(error) { Swal.showValidationMessage("Request failed") })
        }
    })
    .then(function(result) {
        var r = result.value;
        if (r.includes("Error")) {
            Swal.fire({
                title: r,
                type: "error"
            });
        } else {
            Swal.fire({
                title: "Recipe Scheduled",
                type: "success"
            });
            addEvent(r);
        }
    });
}

function addEvent(r) {
    var array = r.split(',');
    $('#calendar').fullCalendar('renderEvent', {
        id: array[0],
        title: array[1],
        start: moment(array[2]),
        end: moment(array[2]).add(array[3], "seconds")
    });
}

function eventClick(info) {
    Swal.fire({
        title: info.title + " - " + info.start.format('YYYY-MM-DD HH:MM'),
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'View Recipe',
        cancelButtonText: 'Delete Schedule'
    }).then(function(result) {
        if (result.value) {
            window.location.replace("Recipes/Details/" + info.id);
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "API/UserWillPrepareRecipe/Delete/" + info.id.replace("\"", "") + "/" + info.start.format('YYYY-MM-DD[T]HH:MM'), false);
            xhttp.send();
            $('#calendar').fullCalendar("removeEvents", info._id);
            Swal.fire({
                title: 'Deleted!',
                type: 'success'
            })
        }
    });
}