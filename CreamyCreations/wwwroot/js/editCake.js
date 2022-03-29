$(document).ready(function () {
    // CREATE CAKE FORM INPUTS
    var $level = $("#selectLevel");
    var $cover = $("#selectCover");
    var $filling = $("#selectFilling");
    var $label = $("#selectLabel");
    var $decorations = $(".decoration");
    var $decorationArray = [];

    var $totalPrice = Number(0);

    function calculatePrice() {
        $totalPrice = Number($levelPrice + $coverPrice + $fillingPrice + $labelPrice + $decorationPrice).toFixed(2);
        //console.log("Total price", $totalPrice);
        $("#cakePrice").text("$" + $totalPrice);
        $("#cakePriceInput").val($totalPrice);
    }

    // PRICES
    var $levelPrice = Number($level.find("option:selected").attr("data-price"));
    var $coverPrice = Number($cover.find("option:selected").attr("data-price"));
    var $fillingPrice = Number($filling.find("option:selected").attr("data-price"));
    var $labelPrice = Number($label.find("option:selected").attr("data-price"));
    var $decorationPrice = Number(0);

    $.each($decorations, function (index, value) {
        if (value.checked === true) {
            $decorationArray.push(value.getAttribute("data-price"));
            $decorationPrice = Number($decorationArray.reduce((a, b) => Number(a) + Number(b), 0));
        }
    });

    // TOTAL PRICE
    calculatePrice()

    $level.change(function () {
        var $price = $(this).find("option:selected").attr("data-price");
        $levelPrice = Number($price);
        calculatePrice();
    });

    $cover.change(function () {
        var $price = $(this).find("option:selected").attr("data-price");
        $coverPrice = Number($price);
        calculatePrice();
    });

    $filling.change(function () {
        var $price = $(this).find("option:selected").attr("data-price");
        $fillingPrice = Number($price);
        calculatePrice();
    });

    $label.change(function () {
        var $price = $(this).find("option:selected").attr("data-price");
        $labelPrice = Number($price);
        calculatePrice();
    });

    $decorations.change(function () {
        if (this.checked) {
            $decorationArray.push(this.getAttribute("data-price"));
            $decorationPrice = Number($decorationArray.reduce((a, b) => Number(a) + Number(b), 0));
            calculatePrice()
        }
        else {
            $decorationIndex = $decorationArray.findIndex((item) => item === this.getAttribute("data-price"));
            $decorationArray.splice($decorationIndex, 1);
            $decorationPrice = Number($decorationArray.reduce((a, b) => Number(a) + Number(b), 0));
            calculatePrice();
        }
    });

    $("#cakePrice").text("$" + $totalPrice);
    $("#cakePriceInput").val();
});