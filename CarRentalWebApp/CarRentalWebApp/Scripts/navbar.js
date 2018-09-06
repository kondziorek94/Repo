$(window).load(function () {
    $("#romanButton").click(function () {
        //alert("c;licked");
        let button = $(this);
        if (button.hasClass("btn-primary")) {
            button.removeClass("btn-primary");
            button.addClass("btn-danger");
        } else {
            button.removeClass("btn-danger");
            button.addClass("btn-primary");
        }
    });
});