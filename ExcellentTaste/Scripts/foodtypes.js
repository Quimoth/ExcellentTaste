function showTheseFoods(foodType) {
    console.log(foodType);
    var listToShow = document.getElementById(foodType);
    var nameString = foodType + "+Span";
    var spanToShow = document.getElementById(nameString);

    var foodLists = document.getElementsByClassName("FoodList");

    for (i = 0; i < foodLists.length; i++) {
        foodLists[i].style.display = "none";
        //console.log(foodLists[i].style.visibility);
    }

    spanToShow.style.display = "block";
    listToShow.style.display = "block";
}

function addProduct(title) {
    var numberInput = document.getElementById(title);
    numberInput.value++;


    var hiddenInput = document.getElementById("hiddenInput");
    //console.log(hiddenInput.textContent);
    hiddenInput.textContent += title;
    //console.log(hiddenInput.textContent);
}
function removeProduct(title) {
    var numberInput = document.getElementById(title);
    if (numberInput.value > 0) {
        numberInput.value--;
    }




    var hiddenInput = document.getElementById("hiddenInput");
    //console.log(hiddenInput.textContent);
    //console.log("removing " + title);

    if (hiddenInput.textContent.includes(title)) {
        hiddenInput.textContent = hiddenInput.textContent.replace(title,"");
        //console.log(hiddenInput.textContent);
    }
}