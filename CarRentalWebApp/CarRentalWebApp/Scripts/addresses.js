$(window).load(function () {

    function searchAddress() {
        var searchButton = $("#search")[0];
        var searchBoxValue = $("#addressLookUp").val();
        searchButton.href = searchButton.href.replace("xxx", searchBoxValue);
    }
    $("#search").click(searchAddress);
    $("#addressLookUp").keypress(function (e) {
        if (e.which === 13) {
            searchAddress();
            window.location = $("#search").attr('href');
        }
    });

    $("#PageNumber").keypress(function (e) {
        if (e.which === 13) {
            var searchPhrase = search ? $("#addressLookUp").val() : null;
            var order = getURLParameter("order") === null ? "" : getURLParameter("order");
            window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + order + "&pageNumber=" + this.value);
        }
    });
    function sort() {
        var searchPhrase = search ? $("#addressLookUp").val() : null;

        window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + this.id);
    }
    function getURLParameter(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }

    $("#CityName_Asc").click(sort);
    $("#CityName_Desc").click(sort);
    $("#StreetName_Asc").click(sort);
    $("#StreetName_Desc").click(sort);
    $("#ZipCode_Asc").click(sort);
    $("#ZipCode_Desc").click(sort);
    $("#PhoneNumber_Asc").click(sort);
    $("#PhoneNumber_Desc").click(sort);
    //Address ? searchPhrase = fsafsa
    $.ajax({
        type: "POST",
        url: "/Address/GetNumberPages",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (result, status, xhr) {
            $("#TotalPageNumber").text(result);
        },
        error: function (xhr, status, error) {
            $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
        }
    });


})