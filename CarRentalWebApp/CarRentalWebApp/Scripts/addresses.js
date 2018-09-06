$(window).load(function () {

    function searchAddress() {
        var searchButton = $("#search")[0];
        var searchBoxValue = $("#addressLookUp").val();
        searchButton.href = searchButton.href.replace("xxx", searchBoxValue);
    }
    $("#search").click(searchAddress);
    $("#addressLookUp").keypress(function (e) {
        if (e.which == 13) {
            searchAddress();
            window.location = $("#search").attr('href');
        }
    });
    function sort() {
        var searchPhrase = search ? $("#addressLookUp").val() : null;

        window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + this.id);
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