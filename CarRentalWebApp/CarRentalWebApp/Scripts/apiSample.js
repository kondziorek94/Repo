$(window).on("load", function () {
    function trim(result) {
        result = result.replace("{\"success\":{\"total\":1},\"contents\":{\"translated\":", "");
        result = result.replace(",\"text\":\"" + $("#YodaInput").val() + "\",\"translation\":\"yoda\"}}", "");
        return result;
    }
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
    $("#YodaInput").keypress(function (e) {
        if (e.which === 13) {
            $.ajax({
                url: "https://api.funtranslations.com/translate/yoda.json?text=" + $("#YodaInput").val(),

                success: function (result, status, xhr) {
                    result = JSON.stringify(result);
                    result = trim(result);
                    //result=trim(result);
                    $("#YodaOutput").text(result);
                },
                error: function (result, status, xhr) {

                }
            }
            );
        }
    });
});
$(window).trigger("onload");
//Wykorzystaj numbersapi do wyswietlenia informacji w twojej aplikacji o wpisanej liczbie przez uzytkownika

//PRACA DOMOWA, wybierz sobie ciekawe API np. cos z mapa a'la google, mapami z pogoda, botem odpowiadajacym w stylu Yody lub cos innego i uzyj tego API tak jak Twoim zdaniem jest najciekawiej


