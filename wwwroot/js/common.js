window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Correct operation", {timeOut: 5000});
    }
    if (type === "error") {
        toastr.error(message, "Failed operation", { timeOut: 5000 });
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        );
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        );
    }
}

function ShowModalConfirmDelete() {
    $('#modalConfirmDeletion').modal('show');
}

function HideModalConfirmDelete() {
    $('#modalConfirmDeletion').modal('hide');
}
