$(window).on("load", function () {
    function filter() {
        var searchPhrase = search ? $("#addressLookUp").val() : null;
        var order = getURLParameter("order") === null ? "" : getURLParameter("order");
        var pageSize = getURLParameter("PageSize");
        window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + order + "&pageNumber=" + this.value + "&PageSize=" + pageSize);
    }
    function sort() {
        var searchPhrase = search ? $("#addressLookUp").val() : null;
        var pageSize = getURLParameter("PageSize");
        window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&order=" + this.id + "&PageSize=" + pageSize);
    }
    function getURLParameter(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
    $("#search").click(filter);
    $("#addressLookUp").keypress(function (e) {
        if (e.which === 13) {
            filter();
        }
    });
    $("#clearSearch").click(function () {
        window.location.assign("/Address/Index?pageNumber =" + 1);
    });
    $("#PageNumber").keypress(function (e) {
        if (e.which === 13) {
            filter.apply(this);
            $("#addressLookUp").val = searchPhrase;
        }
    });
    $('#pagesizelist').on('change', function () {
        var searchPhrase = search ? $("#addressLookUp").val() : null;
        var order = getURLParameter("order");
        pageSize = $('#pagesizelist').val();
        if (order === null) {
            window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&PageSize=" + pageSize);
        }
        else {
            window.location.assign("/Address/Index?searchPhrase=" + searchPhrase + "&PageSize=" + pageSize + "&order=" + order);
        }
    });
    $("#CityName_Asc").click(sort);
    $("#CityName_Desc").click(sort);
    $("#StreetName_Asc").click(sort);
    $("#StreetName_Desc").click(sort);
    $("#ZipCode_Asc").click(sort);
    $("#ZipCode_Desc").click(sort);
    $("#PhoneNumber_Asc").click(sort);
    $("#PhoneNumber_Desc").click(sort);
    $.ajax({
        type: "POST",
        url: "/Address/GetNumberPages",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function () {
            //uncomment do overwite whatever is in TotalPageNumber div
            // $("#TotalPageNumber").text(result);
        },
        error: function (xhr, status, error) {
            $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
        }
    });
});
$(window).trigger("load");