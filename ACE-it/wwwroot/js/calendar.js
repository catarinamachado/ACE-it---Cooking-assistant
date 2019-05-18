$( document ).ready(function() {
    $('#calendar').fullCalendar({
        header: {
            center: 'My Meal Calendar'
        },
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
        height: 750,
        allDaySlot: false,
        selectable: true
    });
});

function chooseRecipe(date) {
    Swal.fire({
        title: 'Schedule recipe',
        html: "<input type='datetime-local' min='" + moment().format('YYYY-MM-DD[T]HH:MM') + "' value='" + date.format('YYYY-MM-DD[T]HH:MM') + "'>", 
        type: 'info',
        showCancelButton: true,
        confirmButtonText: 'Look up'
    })
}
