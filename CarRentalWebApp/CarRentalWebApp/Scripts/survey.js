$(window).on("load", function () {
    $(".answer-button").click(function (e) {
        $.ajax({
            type: "POST",
            url: "/Survey/EvaluateExpressionAJAX",
            contentType: "application/json; charset=utf-8",
            data: '{"expression":"' + 'roman' + '"}',
            dataType: "html",
            success: function (result, status, xhr) {
                alert(result);
            },
            error: function (xhr, status, error) {
                alert("Error:" + error);
            }
        });
        return false;
    });
});
$(window).trigger("load");