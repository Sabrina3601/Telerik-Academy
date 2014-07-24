var newGameButton = document.getElementById('new-game');
var result = document.getElementById('result');
var sheepField = document.getElementById('sheep');
var ramsField = document.getElementById('rams');
var fieldForScores = document.getElementById('scores');
var tryButton = document.getElementById('try');
var errorField = document.getElementById('error');
var showScores = document.getElementById('show-highscores');
var clearLocalstorageButton = document.getElementById('clear-localstorage');
var score;
var sheep;
var rams;
var scoresAndName = [];
var users = [];



function generateNumber(digits) {
    var number = "";

    number += Math.floor(Math.random() * 9 + 1);

    for (var i = 0; i < digits - 1; i++) {
        var generatedRandomNumber = Math.floor(Math.random() * 9);
        if (number.indexOf(generatedRandomNumber) > -1) {
            while (number.indexOf(generatedRandomNumber) > -1) {
                generatedRandomNumber = Math.floor(Math.random() * 9);
            }
        }

        number += generatedRandomNumber;
    }

    return number;
}

function checkIfNumberIsValid(number) {
    if (isNaN(parseInt(number))) {
        errorField.innerHTML = 'Not a number';
        ramsField.innerHTML = "";
        sheepField.innerHTML = "";
        return false;
    }
    else if (number.length !== 4) {
        errorField.innerHTML = 'Not a 4 digit number';
        ramsField.innerHTML = "";
        sheepField.innerHTML = "";
        return false
    }
    else {
        var isValidInputNumber = true;
        for (var i = 0; i < number.length; i++) {
            for (var j = 0; j < number.length; j++) {
                if (i !== j && number[i] === number[j]) {
                    isValidInputNumber = false;
                }
            }
        }
        if (!isValidInputNumber) {
            errorField.innerHTML = 'Not a valid number!';
            ramsField.innerHTML = "";
            sheepField.innerHTML = "";
            return false;
        }
        else {
            return true;
        }
    }
}

function updateUsers() {
    if (localStorage.getItem('users') !== null) {
        users = JSON.parse(localStorage.getItem('users'));
    }
}

function sortUsers(sortBy) {
    var exchangeValues;

    for (var i = 0; i < users.length - 1; i++) {
        for (var j = i + 1; j < users.length; j++) {
            if (users[j][sortBy] > users[i][sortBy]) {
                exchangeValues = users[i];
                users[i] = users[j];
                users[j] = exchangeValues;
            }
        }
    }
}

function updateScoresInnerHtml() {
    if (users.length === 0) {
        updateUsers();
    }

    sortUsers('scores');

    fieldForScores.innerHTML = 'Scores:';
    for (var i = 0; i < users.length; i++) {
        fieldForScores.innerHTML +=
            '<br>' +
            (i + 1) + ')   ' +
            users[i].name + ' -> ' +
            users[i].scores + ' scores';
    }
}

function updateButtonForShowingResults() {
    if (showScores.innerHTML === 'Show highscores!') {
        updateScoresInnerHtml();
        showScores.innerHTML = 'Hide highscores!';
    }
    else {
        fieldForScores.innerHTML = 'Scores:';
        showScores.innerHTML = 'Show highscores!';
    }
}

function updateResultFields(rams, sheep) {
    ramsField.innerHTML = 'Rams: ' + rams;
    sheepField.innerHTML = 'Sheep: ' + (sheep - rams);

    if (rams === 4) {
        result.innerHTML = 'You guessed the number ' + generatedNumber + ' !';
        if (showScores.innerHTML === 'Show highscores!') {
            updateButtonForShowingResults();
        }
        if (scores < 0) {
            scores = 0;
        }

        addToTopScores(scores);
    }
}

function addToTopScores(scores) {
    personName = prompt("Please enter your nickname");
    if (personName === '' || personName === null) {
        personName = 'unnamed';
    }

    var name = personName;

    var nameAndScores = {
        'name': name,
        'scores': scores
    };

    users.push(nameAndScores);

    localStorage.setItem('users', JSON.stringify(users));

    updateScoresInnerHtml();
}

function checkForSheepOrRam() {
    var inputNumber = document.getElementById('input-number').value;

    if (checkIfNumberIsValid(inputNumber)) {
        scores -= 10;
        errorField.innerHTML = "";
        var sheep = 0;
        var rams = 0;

        for (var i = 0; i < inputNumber.length; i++) {
            if (inputNumber[i] === generatedNumber[i]) {
                rams++;
            }
        }

        for (var i = 0; i < inputNumber.length; i++) {
            if (generatedNumber.indexOf(inputNumber[i]) > -1) {
                sheep++;
            }
        }

        updateResultFields(rams, sheep);
    }
}

function startNewGame() {
    result.innerHTML = '';
    ramsField.innerHTML = 'Rams: 0';
    sheepField.innerHTML = 'Sheep: 0';
    fieldForScores.innerHTML = 'Scores:';
    generatedNumber = generateNumber(4);
    console.log(generatedNumber);
    document.getElementById('input-number').value = '';
    scores = 1010;
}

newGameButton.addEventListener('click', startNewGame);
tryButton.addEventListener('click', checkForSheepOrRam);
clearLocalstorageButton.addEventListener('click', function () {
    localStorage.clear();
    users = [];
    fieldForScores.innerHTML = 'Scores:';
});
showScores.addEventListener('click', updateButtonForShowingResults);
