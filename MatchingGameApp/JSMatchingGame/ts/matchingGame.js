document.querySelector("#btnStart").addEventListener("click", startGame);
var player1 = "player1";
var player2 = "player2";
var currentTurn = player1;
var gameOver = false;
var msg;
var allBlueCards;
var allPinkCards;
var shuffle;
var CardNamesPink;
var CardNamesBlue;
var selectedBlueCard = null;
var selectedPinkCard = null;
var ScorePlayer1 = 0;
var ScorePlayer2 = 0;
var winner = null;
$(document).ready(function () {
    msg = $("#msg")[0];
    allBlueCards = $(".blueCard").toArray();
    allPinkCards = $(".pinkCard").toArray();
    CardNamesPink = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
    CardNamesBlue = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
    shuffle = function (array) { return array.sort(function () { return Math.random() - 0.5; }); };
    $(allBlueCards).click(doTakeTurn);
    $(allPinkCards).click(doTakeTurn);
});
function startGame() {
    //shuffle the "pictures" and apply them to the cards
    shuffle(CardNamesPink);
    //console.log(CardNamesPink);
    shuffle(CardNamesBlue);
    //console.log(CardNamesBlue);
    for (var i = 0; i < 8; i++) {
        allBlueCards[i].textContent = CardNamesBlue[i];
        allPinkCards[i].textContent = CardNamesPink[i];
        allBlueCards[i].style.color = "lightblue";
        allPinkCards[i].style.color = "lightpink";
        allPinkCards[i].disabled = false;
        allBlueCards[i].disabled = false;
    }
    ScorePlayer1 = 0;
    ScorePlayer2 = 0;
    $("#score2").text(ScorePlayer2);
    $("#score1").text(ScorePlayer1);
    $(allBlueCards).css("backgroundColor", "lightblue");
    $(allPinkCards).css("backgroundColor", "lightpink");
    selectedBlueCard = null;
    selectedPinkCard = null;
    winner = null;
    gameOver = false;
    currentTurn = player1;
    gameStatusmsg();
}
;
function doTakeTurn(event) {
    var btn = event.target;
    if (btn.disabled == false) {
        TakeTurn(btn);
    }
}
function TakeTurn(btn) {
    if ($(btn).hasClass("blueCard")) {
        if (selectedBlueCard !== null) {
            return;
        }
        selectedBlueCard = btn;
        $(btn).css("color", "white");
        console.log(selectedBlueCard);
    }
    if ($(btn).hasClass("pinkCard")) {
        if (selectedPinkCard !== null) {
            return;
        }
        selectedPinkCard = btn;
        $(btn).css("color", "white");
        console.log(selectedPinkCard);
    }
    if (selectedBlueCard !== null && selectedPinkCard != null) {
        setTimeout(function () {
            checkMatch();
            switchTurn();
        }, 1000);
    }
}
function switchTurn() {
    if (!gameOver) {
        if (selectedBlueCard !== null && selectedPinkCard !== null) {
            currentTurn = currentTurn == player1 ? player2 : player1;
            selectedBlueCard = null;
            selectedPinkCard = null;
            gameStatusmsg();
        }
    }
}
function checkMatch() {
    if (selectedBlueCard !== null && selectedPinkCard !== null) {
        if (selectedBlueCard.textContent == selectedPinkCard.textContent) {
            if (currentTurn == player1) {
                ScorePlayer1++;
                $("#score1").text(ScorePlayer1);
            }
            else if (currentTurn == player2) {
                ScorePlayer2++;
                $("#score2").text(ScorePlayer2);
            }
            selectedBlueCard.disabled = true;
            selectedPinkCard.disabled = true;
            checkGameOver();
        }
        else {
            $(selectedBlueCard).css("color", "lightblue");
            $(selectedPinkCard).css("color", "lightpink");
        }
    }
}
function gameStatusmsg() {
    if (gameOver == false) {
        $(msg).text("Current Turn: " + currentTurn);
    }
    else if (gameOver == true) {
        $(msg).text("Game over! Winner is: " + winner);
    }
}
function checkGameOver() {
    if (allBlueCards.every(function (c) { return c.disabled; }) && allPinkCards.every(function (c) { return c.disabled; })) {
        gameOver = true;
        checkWinnerTie();
        gameStatusmsg();
        $(allBlueCards).css("backgroundColor", "grey");
        $(allPinkCards).css("backgroundColor", "grey");
    }
}
function checkWinnerTie() {
    if (ScorePlayer1 > ScorePlayer2) {
        winner = player1;
    }
    else if (ScorePlayer1 < ScorePlayer2) {
        winner = player2;
    }
    else {
        winner = "Tie";
    }
}
//# sourceMappingURL=matchingGame.js.map