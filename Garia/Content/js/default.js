$(function () {

});

function onReportingComplete() {
    ShowMessage("Report Added");
}

function onSocialPostComplete() {
    location.reload(true);
}

function ShowMessage(message) {
    var $msg = $('<div>', { 'class': 'toast' });
    $('<span>', { text: message }).appendTo($msg);
    $msg.on('click', function () {
        $msg.remove();
    });

    $('body').append($msg);
    setTimeout(function () {
        $msg.remove();
    }, 3000);
}