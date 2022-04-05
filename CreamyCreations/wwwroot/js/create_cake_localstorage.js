// get all the needed input fields

$(document).ready(function () {
    var cakeData = {
        selectLevel: 0,
        selectCover: 0,
        selectFilling: 0,
        selectLabel: 0,
        selectDecoration: []
    }

    var addToLocalStorage = function(key, value) {
        cakeData[key] = value;
        localStorage.setItem('cakeData', JSON.stringify(cakeData));
    }

    var selectLevel = document.getElementById("selectLevel");
    selectLevel.addEventListener("change",
        function(e) {
            addToLocalStorage("selectLevel", e.target.value);
        }
    );

    var selectCover = document.getElementById("selectCover");
    selectCover.addEventListener("change",
        function(e) {
            addToLocalStorage("selectCover", e.target.value);
        }
    );

    var selectFilling = document.getElementById("selectFilling");
    selectFilling.addEventListener("change",
        function(e) {
            addToLocalStorage("selectFilling", e.target.value);
        }
    );

    var selectLabel = document.getElementById("selectLabel");
    selectLabel.addEventListener("change",
        function(e) {
            addToLocalStorage("selectLabel", e.target.value);
        }
    );

    var decorations = document.querySelectorAll('.form-check');
    decorations.forEach(function(decoration, index) {
            decoration.addEventListener("change",
                function(e) {
                    console.log(e.target.checked);
                    cakeData.selectDecoration[index] = e.target.checked;
                    localStorage.setItem('cakeData', JSON.stringify(cakeData));

                }
            );
        }
    );


    if (!localStorage.getItem("cakeData")) {
        localStorage.setItem("cakeData", JSON.stringify(cakeData));
    } else {
        // populate the input fields with the data from localStorage
        var data = JSON.parse(localStorage.getItem("cakeData"));
        cakeData = data;
        if (cakeData.selectLevel) {
            selectLevel.value = data.selectLevel;
        }
        if (cakeData.selectCover) {
            selectCover.value = data.selectCover;
        }
        if (cakeData.selectFilling) {
            selectFilling.value = data.selectFilling;
        }
        if (cakeData.selectLabel) { selectLabel.value = data.selectLabel;
        }

        decorations.forEach(function(decoration, index) {
            if (cakeData.selectDecoration[index]) {
                decoration.children[0].checked = true
            }
        })

    }


});
