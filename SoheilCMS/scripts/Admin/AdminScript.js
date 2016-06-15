/// <reference path="jquery-1.10.2.min.js" />
$(function() {
    $(".deleteBtn").click(function(e) {
        var result = confirm("ایا از حذف مطمین هستید");
        if (!result) {
            
            e.preventDefault();
        }

    });


});