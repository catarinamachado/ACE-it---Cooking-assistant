function error(s) {
    Swal.fire({
        title: 'Error!',
        text: s,
        type: 'error',
        confirmButtonText: 'Close'
    });
}

function success(s) {
    Swal.fire({
        title: 'Success!',
        text: s,
        type: 'success',
        confirmButtonText: 'Close'
    });
}