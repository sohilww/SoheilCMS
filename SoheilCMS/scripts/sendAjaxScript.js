/// <reference path="jquery-1.10.2.min.js" />
function SendAjax(url,data,type,callback) {
    $.ajax({
        url: url,
        data: data,
        type: type,
        success:callback
    });


}

var AjaxOption= {
    Post: "Post",
    Get:"Get"
}