// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var alertObject = new Object();

alertObject.ScreenAlert = function (type, message) {
    $("#AlertJavaScript").html("");
    var alertTypeClass = "";
    switch (type) {
        case 1:
            alertTypeClass = "alert alert-success";
            break;
        case 2:
            alertTypeClass = "alert alert-warning";
            break;
        case 3:
            alertTypeClass = "alert alert-danger";
            break;
    }
    var divAlert = $("<div>", { class: alertTypeClass });
    divAlert.append('<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>');
    divAlert.append('<strong>"' + message + '"</strong>');
    $("#AlertJavaScript").html(divAlert);
    window.setTimeout(function () {
        $('.alert').fadeTo(1500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);
}
