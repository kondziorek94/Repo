$(window).on("load", function () {
    $("#apiTest").keypress(function (e) {
        if (e.which === 13) {
            $.ajax({
                url: "http://numbersapi.com/" + $("#apiTest").val(),
                
                success: function (result, status, xhr) {

                    $("#apiSampleOutput").text(result);
                },
                error: function (result, status, xhr) {
                    
                }
            });
        }

    });
});
$(window).trigger("onload");
//Wykorzystaj numbersapi do wyswietlenia informacji w twojej aplikacji o wpisanej liczbie przez uzytkownika

//PRACA DOMOWA, wybierz sobie ciekawe API np. cos z mapa a'la google, mapami z pogoda, botem odpowiadajacym w stylu Yody lub cos innego i uzyj tego API tak jak Twoim zdaniem jest najciekawiej


