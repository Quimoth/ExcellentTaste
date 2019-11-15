function showTheseFoods(foodType) {
    console.log(foodType);
    var listToShow = document.getElementById(foodType);
    var nameString = foodType + "+Span";
    var spanToShow = document.getElementById(nameString);
    var activeButton = document.getElementById(foodType + "Button");

    hideMenuList();

    activeButton.style.backgroundColor = "#666666";
    spanToShow.style.display = "block";
    listToShow.style.display = "block";
}

//Adds a product
function addProduct(title) {
    var numberInput = document.getElementById(title);
    numberInput.value++;

    var hiddenInput = document.getElementById("hiddenInput");
    console.log(hiddenInput.value);
    hiddenInput.value += title + ';';
    console.log(hiddenInput.value);
}
//Removes a product
function removeProduct(title) {
    var numberInput = document.getElementById(title);
    if (numberInput.value > 0) {
        numberInput.value--;
    }

    var hiddenInput = document.getElementById("hiddenInput");
    //console.log(hiddenInput.attributes.value);
    //console.log("removing " + title);

    if (hiddenInput.value.includes(title)) {
        var temp = title + ';';
        hiddenInput.value = hiddenInput.value.replace(temp,"");
        console.log(hiddenInput.value);
    }
}
//Opens the food tab
function showEten() {
    var tabToOpen = document.getElementById("FoodCategoryTab");
    var tabToClose = document.getElementById("DrinkCategoryTab");
    var activeButton = document.getElementById("FoodButton");
    var inactiveButton = document.getElementById("DrinkButton");

    hideMenuList();

    inactiveButton.style.backgroundColor = "transparent";
    activeButton.style.backgroundColor = "#666666";
    tabToOpen.style.display = "block";
    tabToClose.style.display = "none";
}
//Opens the drink tab
function showDrank() {
    var tabToOpen = document.getElementById("DrinkCategoryTab");
    var tabToClose = document.getElementById("FoodCategoryTab");
    var activeButton = document.getElementById("DrinkButton");
    var inactiveButton = document.getElementById("FoodButton");

    hideMenuList();

    inactiveButton.style.backgroundColor = "transparent";
    activeButton.style.backgroundColor = "#666666";
    tabToOpen.style.display = "block";
    tabToClose.style.display = "none";
}

//Hide the last shown list of products
function hideMenuList() {
    //console.log("Hiding!")
    var foodLists = document.getElementsByClassName("FoodList");
    for (i = 0; i < foodLists.length; i++) {
        foodLists[i].style.display = "none";
    }

    var inactiveButtons = document.getElementsByClassName("FoodHeadBtns");
    for (i = 0; i < inactiveButtons.length; i++) {
        var inactiveButton = inactiveButtons[i];
        inactiveButton.style.backgroundColor = "transparent";
    }

}
//Makes sure you see products that were added but haven't been delivered.
//Allows to quickly correct errors trough the same page.
$(document).ready(initializeList());
function initializeList() {
    
    var hiddenInput = document.getElementById("hiddenInput");
    //The list of products that can still be changed. (not delivered)
    var productString = hiddenInput.value;
    var product = "";
    var foodCounters = document.getElementsByClassName("foodButtonsCntr");

    for (i = 0; i < foodCounters.length; i++) {
        var foodCounter = foodCounters[i];
        foodCounter.value = 0;
    }

    while (productString.length > 0) {
        console.log(productString);
        if (productString[0] == ';') {
            productString = productString.replace(';', '');
            if (product != "") {
                var productBox = document.getElementById(product);
                productBox.value++;
            }
            product = "";
        }
        else {
            product += productString[0];
            productString = productString.replace(productString[0], '');
        }
    }
    if (document.URL.includes("AddProduct")) {
        hideMenuList();
    }    
}