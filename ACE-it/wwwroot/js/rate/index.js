$( document ).ready(function() {
    var reviews = $("#reviews");
    var reviewSent = reviews.data("review-sent");
    if(reviewSent === "True") {
        success("Review updated.")
    }
});

function success(s) {
    Swal.fire({
        title: 'Success!',
        text: s,
        type: 'success',
        confirmButtonText: 'Close'
    });
}