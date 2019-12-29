﻿// Write your JavaScript code.
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover({
        html: true,
        placement: 'auto',
        content: function () {
            return $("#notification-content").html();
        },
    });
    $('body').append(`<div id="notification-content" class="hide" ></div>`)


    function getNotification() {              
        var res = "<ul class='list-group'>";
        $.ajax({
            url: "/Notification/getNotification",
            method: "GET",
            success: function (result) {
                
                if (result.count != 0) {
                    $("#notificationCount").html(result.count);
                    $("#notificationCount").show('slow');
                } else {
                    $("#notificationCount").html();
                    $("#notificationCount").hide('slow');
                    $("#notificationCount").popover('hide');
                }
                var notifications = result.userNotification;
                notifications.forEach(element => {
                    res = res + "<li class='list-group-item notification-text' style='color:black' data-id='" + element.notification.id + "'>" + element.notification.text + "</li>";
                    
                });

                res = res + "</ul>";
                //$("#notification-content").html(res);
                $("#notification-content").html(res);

            },
            error: function (error) {
                console.log(error);
            }  
        });
    }
    $("ul").on('click', 'li.notification-text', function (e) {
        var target = e.target;
        var id = $(target).data('id');

        readNotification(id, target);
    })

    function readNotification(id, target) {
        $.ajax({
            url: "/Notification/ReadNotification",
            method: "GET",
            data: { notificationId: id },
            success: function (result) {
                getNotification();
                $(target).fadeOut('slow');
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

    getNotification();

    const connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();

    connection.on('displayNotification', function(){
        getNotification();
    });

    connection.start();

});

