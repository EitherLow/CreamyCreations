$(document).ready(function () {
    // CREATE CAKE FORM INPUTS
    var $level = $("#selectLevel");
    var $cover = $("#selectCover");
    var $filling = $("#selectFilling");
    var $label = $("#selectLabel");
    var $decorations = $(".decoration");
    var $decorationArray = [];

    // PRICES
    var $levelPrice = Number(0);
    var $coverPrice = Number(0);
    var $fillingPrice = Number(0);
    var $labelPrice = Number(0);
    var $decorationPrice = Number(0);

    // TOTAL PRICE
    var $totalPrice = Number(0);

    function calculatePrice() {
        $totalPrice = Number($levelPrice + $coverPrice + $fillingPrice + $labelPrice + $decorationPrice).toFixed(2);
        //console.log("Total price", $totalPrice);
        $("#cakePrice").text("$" + $totalPrice);
        $("#cakePriceInput").val($totalPrice);
    }

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

    if (parseFloat($level[0].options[$level[0].options["selectedIndex"]].dataset.price)) {
        $levelPrice = parseFloat($level[0].options[$level[0].options["selectedIndex"]].dataset.price)
    }

    if (parseFloat($cover[0].options[$cover[0].options["selectedIndex"]].dataset.price)) {
        $coverPrice = parseFloat($cover[0].options[$cover[0].options["selectedIndex"]].dataset.price)
    }

    if (parseFloat($filling[0].options[$filling[0].options["selectedIndex"]].dataset.price)) {
        $fillingPrice = parseFloat($filling[0].options[$filling[0].options["selectedIndex"]].dataset.price)
    }

    if (parseFloat($label[0].options[$label[0].options["selectedIndex"]].dataset.price)) {
        $labelPrice = parseFloat($label[0].options[$label[0].options["selectedIndex"]].dataset.price)
    }

    var decorations = document.querySelectorAll('.form-check');
    decorations.forEach(function(decoration, index) {
        if (decoration.children[0].checked) {
            $decorationArray.push(parseFloat(decoration.children[0].dataset.price))
            $decorationPrice += parseFloat(decoration.children[0].dataset.price)
        }
    });

    calculatePrice();

});