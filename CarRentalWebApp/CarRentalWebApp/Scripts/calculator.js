$(window).on("load", function () {
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
    };
    for (let i = 0; i < 10; i++) {
        $("#" + i).click(myFunction);
    }
    $("#\\+").click(operatorFunction);
    $("#-").click(operatorFunction);
    $("#\\*").click(operatorFunction);
    $("#\\/").click(operatorFunction);
    $("#\\%").click(operatorFunction);
    $("#\\.").click(myFunction);
    $("#clear").click(function () {
        $("#calculatorDisplay").val("");
    });
    $("#equals").click(function () {
        window.location.href = '/Calculator/EvaluateExpression/?expression=' + $("#calculatorDisplay").val();
    });
    $("#equals2").click(function () {
        let display = $("#calculatorDisplay");
        var currentValue = display.val();
        var split = currentValue.split(" ");
        var a = Number(split[0]);
        var b = Number(split[2]);
        var op = split[1];
        if (op === "+") {
            currentValue = a + b;
        }
        else if (op === "-") {
            currentValue = a - b;
        }
        else if (op === "*") {
            currentValue = a * b;
        }
        else if (op === "/") {
            currentValue = a / b;
        }
        else if (op === "%") {
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
                $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            }
        });
        return false;
    });
    function Graph(config) {
        this.canvas = document.getElementById(config.canvasId);
        this.minX = config.minX;
        this.minY = config.minY;
        this.maxX = config.maxX;
        this.maxY = config.maxY;
        this.unitsPerTick = config.unitsPerTick;

        this.axisColor = '#aaa';
        this.font = '8pt Times New Roman';
        this.tickSize = 20;

        this.context = this.canvas.getContext("2d");
        this.rangeX = this.maxX - this.minX;
        this.rangeY = this.maxY - this.maxY;
        this.unitX = this.canvas.width / this.rangeX;
        this.unitY = this.canvas.height / this.rangeY;
        this.centerY = Math.round(Math.abs(this.minY / this.rangeY) * this.canvas.height);
        this.centerX = Math.round(Math.abs(this.minX / this.rangeX) * this.canvas.width);
        this.iteration = (this.maxX - this.minX) / 1000;
        this.scaleX = this.canvas.width / this.rangeX;
        this.scaleY = this.canvas.height / this.rangeY;

        this.drawXAxis();
        this.drawYAxis();
    }
    Graph.prototype.drawXAxis = function () {
        this.context.beginPath();
        this.context.moveTo(0, this.centerY);
        this.context.lineTo(this.canvas.width, this.centerY);
        this.context.strokeStyle = this.axisColor;
        this.context.lineWidth = 2;
        this.context.stroke();

        var xPosIncrement = this.unitsPerTick * this.unitX;
        var xPos, unit;
        this.context.font = this.font;
        this.context.textAlign = 'center';
        this.context.textBaseline = 'top';

        xPos = this.centerX - xPosIncrement;
        unit = -1 * this.unitsPerTick;
        while (xPos > 0) {
            this.context.moveTo(xPos, this.centerY - this.tickSize / 2);
            this.context.lineTo(xPos, this.centerY + this.tickSize / 2);
            this.context.stroke();
            this.context.fillText(unit, xPos, this.centerY + this.tickSize / 2 + 3);
            unit -= this.unitsPerTick;
            xPos = Math.round(xPos - xPosIncrement);
        }
        xPos = this.centerX + xPosIncrement;
        unit = this.unitsPerTick;
        while (xPos < this.canvas.width) {
            this.context.moveTo(xPos, this.centerY - this.tickSize / 2);
            this.context.lineTo(xPos, this.centerY + this.tickSize / 2);
            this.context.stroke();
            this.context.fillText(unit, xPos, this.centerY + this.tickSize / 2 + 3);
            unit += this.unitsPerTick;
            xPos = Math.round(xPos + xPosIncrement);
        }
        this.context.restore();
    };
    Graph.prototype.drawYAxis = function () {
        this.context.beginPath();
        this.context.moveTo(this.centerX, 0);
        this.context.lineTo(this.centerX, this.canvas.height);
        this.context.strokeStyle = this.axisColor;
        this.context.lineWidth = 2;
        this.context.stroke();
        var yPosIncrement = this.unitsPerTick * this.unitY;
        var yPos, unit;
        this.context.font = this.font;
        this.context.textAlign = 'right';
        this.context.textBaseline = 'middle';
        yPos = this.centerY - yPosIncrement;
        unit = this.unitsPerTick;
        while (yPos > 0) {
            this.context.moveTo(this.centerX - this.tickSize / 2, yPos);
            this.context.lineTo(this.centerX + this.tickSize / 2, yPos);
            this.context.stroke();
            this.context.fillText(unit, this.centerX - this.tickSize / 2 - 3, yPos);
            unit += this.unitsPerTick;
            yPos = Math.round(yPos - yPosIncrement);
        }
        yPos = this.centerY + yPosIncrement;
        unit = -1 * this.unitsPerTick;
        while (yPos < this.canvas.height) {
            this.context.moveTo(this.centerX - this.tickSize / 2, yPos);
            this.context.lineTo(this.centerX + this.tickSize / 2, yPos);
            this.context.stroke();
            this.context.fillText(unit, this.centerX - this.tickSize / 2 - 3, yPos);
            unit -= this.unitsPerTick;
            yPos = Math.round(yPos + yPosIncrement);
        }
        this.context.restore();
    };

    Graph.prototype.drawEquation = function (equation, color, thickness) {
        var context = this.context;
        context.save();
        context.save();
        this.transformContext();
        context.beginPath();
        context.moveTo(this.minX, equation(this.minX));
        for (var x = this.minX + this.iteration; x <= this.maxX; x += this.iteration) {
            context.lineTo(x, equation(x));
        }
        context.restore();
        context.lineJoin = 'round';
        context.lineWidth = thickness;
        context.strokeStyle = color;
        context.stroke();
        context.restore();
    };
    Graph.prototype.transformContext = function () {
        var context = this.context;
        this.context.translate(this.centerX, this.centerY);
        context.scale(this.scaleX, -this.scaleY);
    };
    var myGraph = $(new Graph({
        canvasId: 'canvas',
        minX: -10,
        minY: -10,
        maxX: 10,
        maxY: 10,
        unitsPerTick: 1
    }));
    $("#plot").click(drawEquation(function (x) { return 5 * Math.sin(x); }, 'green', 3));
});
$(window).trigger("load");