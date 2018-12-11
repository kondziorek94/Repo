$(window).on("load", function () {
    function getURLParameter(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
    $(".answer-button").click(function () {
        var answerId = this.id;
        var addressId = getURLParameter("addressId");
        $.ajax({
            type: "POST",
            url: "/Survey/SaveAnswer",
            contentType: "application/json; charset=utf-8",
            data: {
                addressId: addressId,
                answerId: answerId
            },
            dataType: "html",
            success: function (result, status, xhr) {
                alert("ok");
            },
            error: function (xhr, status, error) {
                alert("AddressId:" + addressId + "\nanswerId:" + answerId+"\nresult: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            }
        });
        return false;
    });
});
$(window).trigger("load");