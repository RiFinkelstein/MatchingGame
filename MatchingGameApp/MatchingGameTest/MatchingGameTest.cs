using MatchingGameSystem;
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
            Assert.IsTrue(game.GameStatus == Game.GameStatusEnum.Playing && game.CurrentTurn == Game.TurnEnum.player1 && game.lstCardsBottomRow.Count==8 && game.lstCardsTopRow.Count==8, msg);
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
        public void TestDoTurn(bool isTopRow)
        {
            Game game = new();
            game.StartGame();

            Card card = isTopRow ? game.lstCardsTopRow[0] : game.lstCardsBottomRow[0];
            card.ForeColor = isTopRow ? game.TopCardsHiddendColor : game.BottomCardsHiddenColor;
            card.Value = "A";

            game.DoTurn(card);

            string msg = $"Row: {(isTopRow ? "Top" : "Bottom")}, MatchPart = {(isTopRow ? game.MatchPart1.Value : game.MatchPart2.Value)}, ForeColor = {card.ForeColor}, GameStatus = {game.GameStatus}";
            Assert.IsTrue((isTopRow ? game.MatchPart1 == card : game.MatchPart2 == card) , msg);
            Assert.IsTrue(card.ForeColor == game.CardsRevealedColor, msg);
            Assert.IsTrue(game.GameStatus == Game.GameStatusEnum.Playing, msg);

            TestContext.WriteLine(msg);
        }


    }
}