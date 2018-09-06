$(window).load(function () {
    $("#calculatorDisplay").val("2 + 5");
    let myFunction = function () {
        let display = $("#calculatorDisplay");
        var currentValue = display.val() + (this.id);
        display.val(currentValue);
        //alert(this.id);
    };
    let operatorFunction = function () {
        let display = $("#calculatorDisplay");
        var currentValue = display.val() + " " + (this.id) + " ";
        display.val(currentValue);
    }
    for (let i = 0; i < 10; i++) {
        $("#" + i).click(myFunction);
    }
    $("#\\+").click(operatorFunction);
    $("#-").click(operatorFunction);
    $("#\\*").click(operatorFunction);
    $("#\\/").click(operatorFunction);
    $("#\\%").click(operatorFunction);
    $("#\\.").click(myFunction);
    $("#clear").click(
        function () {
            $("#calculatorDisplay").val("");
        });

    $("#equals").click(
        function () {
            window.location.href = '/Calculator/EvaluateExpression/?expression=' + $("#calculatorDisplay").val();
        });
    $("#equals2").click(
        function () {
            let display = $("#calculatorDisplay");
            var currentValue = display.val();
            var split = currentValue.split(" ");
            var a = Number(split[0]);
            var b = Number(split[2]);
            var op = split[1];
            if (op == "+") {
                currentValue = a + b;
            }
            else if (op == "-") {
                currentValue = a - b;
            }
            else if (op == "*") {
                currentValue = a * b;
            }
            else if (op == "/") {
                currentValue = a / b;
            }
            else if (op == "%") {
                currentValue = a % b;
            }
            display.val(currentValue);
        });

    $("#equals3").click(function (e) {


        $.ajax({
            type: "POST",
            url: "/Calculator/EvaluateExpressionAJAX",
            contentType: "application/json; charset=utf-8",
            data: '{"expression":"' + $("#calculatorDisplay").val() + '"}',
            dataType: "html",
            success: function (result, status, xhr) {
                $("#calculatorDisplay").val(result);
            },
            error: function (xhr, status, error) {
                $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
            }
        });

        return false;
    });
});