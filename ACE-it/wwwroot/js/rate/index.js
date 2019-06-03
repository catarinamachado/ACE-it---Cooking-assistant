$( document ).ready(function() {
    var reviews       = $("#reviews");
    var reviewSent    = reviews.data("review-sent");
    var $_promocode   = $("#promocode");
    var $_skillExists = $("#skillExits");
    var $_skill       =  $_skillExists.closest("#skill");

    if(reviewSent === "True") {
        success("Review updated.")
    }

    $_promocode.modal('show');

    $_promocode.on('hidden.bs.modal', function () {
        if($_skillExists.length !== 0) {
            setTimeout(function (){
                $_skill.modal('show');
            }, 500);
        }
    });

    $('#up').click(function () {
        var xhttp = new XMLHttpRequest();
        xhttp.open("GET", "/API/UserRank/Up", false);
        xhttp.send();
        $_skill.modal('hide');
    });
    $('#down').click(function () {
        var xhttp = new XMLHttpRequest();
        xhttp.open("GET", "/API/UserRank/Down", false);
        xhttp.send();
        $_skill.modal('hide');
    });
});

function success(s) {
    Swal.fire({
        title: 'Success!',
        text: s,
        type: 'success',
        confirmButtonText: 'Close'
    });
}
