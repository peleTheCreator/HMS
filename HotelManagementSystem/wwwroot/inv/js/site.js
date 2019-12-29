
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover({
        html: true,
        placement: 'auto',
        content: function () {
            return $("#message-content").html();
        },
    });
});