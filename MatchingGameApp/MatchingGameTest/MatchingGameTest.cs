using MatchingGameSystem;
using System.Drawing;
namespace MatchingGameTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestStartGame()
        {
            Game game = new();
            game.StartGame();
            string msg = $"Game status = {game.GameStatus.ToString()} current turn= {game.CurrentTurn.ToString()} top cards count = {game.lstCardsTopRow.Count.ToString()} bottom cards count= {game.lstCardsBottomRow.Count.ToString()}";
            Assert.IsTrue(game.GameStatus == Game.GameStatusEnum.Playing && game.CurrentTurn == Game.TurnEnum.player1 && game.lstCardsBottomRow.Count == 8 && game.lstCardsTopRow.Count == 8, msg);
            TestContext.WriteLine(msg);
        }

        [Test]
        public void TestAddWordsToButton()
        {
            Game game = new();
            game.AddWordsToButton();

            // Assert: check top and bottom rows each have 8 cards
            Assert.AreEqual(8, game.lstCardsTopRow.Count, "Top row should have 8 cards.");
            Assert.AreEqual(8, game.lstCardsBottomRow.Count, "Bottom row should have 8 cards.");

            // Assert: each value in lstCardNames is in top row exactly once
            foreach (var name in game.lstCardNames)
            {
                Assert.AreEqual(1, game.lstCardsTopRow.Count(c => c.Value == name), $"Top row should contain '{name}' exactly once.");
                Assert.AreEqual(1, game.lstCardsBottomRow.Count(c => c.Value == name), $"Bottom row should contain '{name}' exactly once.");
            }

            // Assert: top and bottom rows are not in the same order (usually true)
            bool sameOrder = true;
            for (int i = 0; i < 8; i++)
            {
                if (game.lstCardsTopRow[i].Value != game.lstCardsBottomRow[i].Value)
                {
                    sameOrder = false;
                    break;
                }
            }
            Assert.IsFalse(sameOrder, "Top and bottom rows should be shuffled into different orders.");

            // Output
            TestContext.WriteLine("Top Row: " + string.Join(", ", game.lstCardsTopRow.Select(c => c.Value)));
            TestContext.WriteLine("Bottom Row: " + string.Join(", ", game.lstCardsBottomRow.Select(c => c.Value)));
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task TestDoTurn(bool isTopRow)
        {
            Game game = new();
            game.StartGame();

            int index = isTopRow ? 0 : 9;

            Card card = game.lstAllCards[index];
            card.ForeColor = isTopRow ? game.TopCardsHiddendColor : game.BottomCardsHiddenColor;


            await game.DoTurn(index);

            string msg = $"Row: {(isTopRow ? "Top" : "Bottom")}, MatchPart = {game.MatchPart1.Value}, Card Revealed = {card.IsRevealed}, GameStatus = {game.GameStatus}";
            Assert.IsTrue((game.MatchPart1 == card), msg);
            Assert.IsTrue(card.IsRevealed, msg);
            Assert.IsTrue(game.GameStatus == Game.GameStatusEnum.Playing, msg);

            TestContext.WriteLine(msg);
        }






        [Test]
        public void TestSwitchTurn()
        {
            Game game = new();
            game.CurrentTurn = Game.TurnEnum.player1;
            game.SwitchTurn();
            string msg1 = $"After first switch: CurrentTurn = {game.CurrentTurn}";
            Assert.IsTrue(Game.TurnEnum.player2==game.CurrentTurn, msg1);

            game.SwitchTurn();
            string msg2 = $"After second switch: CurrentTurn = {game.CurrentTurn}";
            Assert.IsTrue(Game.TurnEnum.player1== game.CurrentTurn, msg2);

            TestContext.WriteLine(msg1);
            TestContext.WriteLine(msg2);

        }

        [Test]
        public async Task TestUpdateScore()
        {
            Game game = new();
            game.StartGame();

            game.lstAllCards[0].Value = "Z";
            game.lstAllCards[9].Value = "Z";

            game.CurrentTurn = Game.TurnEnum.player1;

            await game.DoTurn(0); 
            await game.DoTurn(9);

            string msg = $"Player1Score= {game.Player1Score} and Player2Score= {game.Player2Score}";

            Assert.IsTrue(1==game.Player1Score && game.Player2Score==0, msg);
            TestContext.WriteLine(msg);
        }


        [Test]
        public void TestIsGameOver()
        {
            Game game = new();
            game.StartGame();

            // Simulate all cards matched
            game.lstMatchFound = game.lstAllCards.ToList();
            game.Player1Score = 5;
            game.Player2Score = 3;

            bool isOver = game.IsGameOver();
            string msg = $"GameOver = {isOver}, GameStatus = {game.GameStatus}, Player1Score = {game.Player1Score}, Player2Score = {game.Player2Score}";

            Assert.IsTrue(game.GameStatus== Game.GameStatusEnum.Winner && isOver==true, msg);

            TestContext.WriteLine(msg);
        }

    }



}

