document.querySelector("#btnStart").addEventListener("click", startGame);
let player1 = "player1";
let player2 = "player2";
let currentTurn = player1;
let gameOver = false;
let msg = document.querySelector("#msg");
const allBlueCards = Array.from(document.querySelectorAll(".blueCard"));
const allPinkCards = Array.from(document.querySelectorAll(".pinkCard"));
let shuffle = (array) => { return array.sort(() => Math.random() - 0.5); };
let CardNamesPink = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
let CardNamesBlue = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
let selectedBlueCard = null;
let selectedPinkCard = null;
let ScorePlayer1 = 0;
let ScorePlayer2 = 0;
let winner = null;
let displayScorePlayer1 = document.querySelector("#scoreplayer1");
let displayScorePlayer2 = document.querySelector("#scoreplayer2");
allBlueCards.forEach(s => s.addEventListener("click", doTakeTurn));
allPinkCards.forEach(s => s.addEventListener("click", doTakeTurn));
function startGame() {
    //shuffle the "pictures" and apply them to the cards
    shuffle(CardNamesPink);
    //console.log(CardNamesPink);
    shuffle(CardNamesBlue);
    //console.log(CardNamesBlue);
    for (let i = 0; i < 8; i++) {
        allBlueCards[i].textContent = CardNamesBlue[i];
        allPinkCards[i].textContent = CardNamesPink[i];
        allBlueCards[i].style.color = "lightblue";
        allPinkCards[i].style.color = "lightpink";
        allBlueCards[i].style.backgroundColor = "lightblue";
        allPinkCards[i].style.backgroundColor = "lightpink";
        allPinkCards[i].disabled = false;
        allBlueCards[i].disabled = false;
    }
    ScorePlayer1 = 0;
    ScorePlayer2 = 0;
    displayScore();
    selectedBlueCard = null;
    selectedPinkCard = null;
    winner = null;
    gameOver = false;
    currentTurn = player1;
    gameStatusmsg();
}
;
function doTakeTurn(event) {
    const btn = event.target;
    if (btn.disabled == false) {
        TakeTurn(btn);
    }
}
function TakeTurn(btn) {
    if (btn.classList.contains("blueCard")) {
        if (selectedBlueCard !== null) {
            return;
        }
        selectedBlueCard = btn;
        btn.style.color = "white";
        console.log(selectedBlueCard);
    }
    if (btn.classList.contains("pinkCard")) {
        if (selectedPinkCard !== null) {
            return;
        }
        selectedPinkCard = btn;
        btn.style.color = "white";
        console.log(selectedPinkCard);
    }
    if (selectedBlueCard !== null && selectedPinkCard != null) {
        setTimeout(() => {
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
                //document.querySelector("#score1").textContent = ScorePlayer1
                displayScore();
            }
            else if (currentTurn == player2) {
                ScorePlayer2++;
                //document.querySelector("#score2").textContent = ScorePlayer2
                displayScore();
            }
            selectedBlueCard.disabled = true;
            selectedPinkCard.disabled = true;
            checkGameOver();
        }
        else {
            selectedBlueCard.style.color = "lightblue";
            selectedPinkCard.style.color = "lightpink";
        }
    }
}
function gameStatusmsg() {
    if (gameOver == false) {
        msg.textContent = "Current Turn: " + currentTurn;
    }
    else if (gameOver == true) {
        msg.textContent = "Game over! Winner is: " + winner;
    }
}
function checkGameOver() {
    if (allBlueCards.every(c => c.disabled) && allPinkCards.every(c => c.disabled)) {
        gameOver = true;
        checkWinnerTie();
        gameStatusmsg();
        [...allBlueCards, ...allPinkCards].forEach(c => c.style.backgroundColor = "grey");
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
function displayScore() {
    displayScorePlayer1.textContent = "Player 1: " + ScorePlayer1.toString();
    displayScorePlayer2.textContent = "Player 2: " + ScorePlayer2.toString();
}
//# sourceMappingURL=matchingGame.js.map