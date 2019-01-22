$(window).on("load", function () {
    function getURLParameter(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
    //DZIALAJACE NIE USUWAC, pyta sie o kazda odpowiedz czy powinna byc zaznaczona, zastapione przez efektywniejszy mechanizm
    //(function () {
    //    //kod ktory przechodzi petla po radio buttonach i je zaznacza jezeli backend zwroci ze powinny byc  zaznaczone
    //    $(".answer-button").each(function () {
    //        var answerId = this.id;
    //        var addressId = getURLParameter("addressId");
    //        var radioButtonId = this.id;
    //        $.ajax({
    //            url: "/Survey/CheckAnswer?addressId=" + addressId + "&answerId=" + answerId,
    //            success: function (response) {
    //                $("#" + radioButtonId).prop('checked', true);
    //            }
    //        });
    //    });
    //})();


    $(".answer-button").on('load', function () {
        var answerId = this.id;
        var name = this.name;
        var addressId = getURLParameter("addressId");
        $.post({
            url: "/Survey/CheckAnswer?addressId=" + addressId + "&answerId=" + answerId,
            success: function (response) {
                alert(response);
                $("input[name'" + name + "'][value='" + answerId + "']").prop('checked', true);
            }
        });
    });

    $(".answer-button").click(function () {
        var answerId = this.id;
        var name = this.name;
        var addressId = getURLParameter("addressId");
        $.ajax({
            //Fill?id=4929a366-7568-4e49-aa98-21916a09d01d&addressId=3711051f-368c-407f-b460-06d01bf7ca17
            url: "/Survey/SaveAnswer?addressId=" + addressId + "&answerId=" + answerId,
            success: function (result, status, xhr) {
                alert("ok");
                $("input[name='" + name + "'][value='" + answerId + "']").prop('checked', true);
            },
            error: function (xhr, status, error) {
                alert("AddressId:" + addressId + "\nanswerId:" + answerId + "\nresult: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            }
        });
        return false;
    });
    
});
