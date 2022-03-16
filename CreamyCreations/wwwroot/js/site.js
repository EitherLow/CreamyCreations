// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
        $("#cakePrice").text($totalPrice);
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
            $decorationPrice = Number( $decorationArray.reduce((a, b) => Number(a) + Number(b), 0) );
            calculatePrice()
        }
        else {
            $decorationIndex = $decorationArray.findIndex((item) => item === this.getAttribute("data-price"));
            $decorationArray.splice($decorationIndex, 1);
            $decorationPrice = Number( $decorationArray.reduce((a, b) => Number(a) + Number(b), 0) );
            calculatePrice();
        }
    })
    //console.log($decorations);



    $("#cakePrice").text($totalPrice);
});