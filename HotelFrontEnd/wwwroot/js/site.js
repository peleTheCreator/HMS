    function jQueryAjaxPost(form) {
        $.validator.unobtrusive.parse(form);
          if ($(form).valid()) {
            var ajaxConfig = {
                type: 'POST',
                url: "/Contact/Create",
                data: new FormData(form),
                success: function (response) {
                    if (response.success) {
                     //   $("#contactdiv").html(response.html);
                       // refreshContactForm($(form).attr('data-restUrl'), true);
                           $.notify(response.message, "success");
                         }
                    else {
                            $.notify(response.message, "error");
                    }
                }
            }
             $.ajax(ajaxConfig);
          }
        return false;
    }

     function refreshContactForm(resetUrl, showViewTab) {
        $.ajax({
            type: 'GET',
            url: resetUrl,
            success: function (response) {
                $("#contactdiv").html(response);
                if (showViewTab)
                    $("#contactdiv").tab('show');
            }
        });
     }
