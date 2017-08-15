using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    [TestFixture]
    class BowlingUnitTest
    {
        Game game;
        [SetUp]
        public void CreateGame()
        {
            game = new Game();
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }
        private void ManyRolls(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

        [Test]
        public void Rolls()
        {
            ManyRolls(20, 1);

            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void OneSpare()
        {
            RollSpare();
            game.Roll(4);
            game.Roll(2);
            ManyRolls(16, 0);

            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void SpareSpare()
        {
            RollSpare();
            RollSpare();
            game.Roll(4);
            game.Roll(2);
            ManyRolls(14, 0);

            Assert.That(game.Score(), Is.EqualTo(35));
        }

        [Test]
        public void OneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            ManyRolls(16, 0);

            Assert.That(game.Score(), Is.EqualTo(24));
        }

        [Test]
        public void Double()
        {
            RollStrike();
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            ManyRolls(14, 0);

            Assert.That(game.Score(), Is.EqualTo(47));
        }

        [Test]
        public void Turkey()
        {
            RollStrike();
            RollStrike();
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            ManyRolls(12, 0);

            Assert.That(game.Score(), Is.EqualTo(77));
        }

        [Test]
        public void StrikeSpareStrike()
        {
            RollStrike();
            RollSpare();
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            ManyRolls(12, 0);

            Assert.That(game.Score(), Is.EqualTo(64));
        }

        [Test]
        public void LastTwoSpare()
        {
            ManyRolls(16, 0);
            RollSpare();
            RollSpare();

            Assert.That(game.Score(), Is.EqualTo(25));
        }

        [Test]
        public void LastTwoStrike()
        {
            ManyRolls(16, 0);
            RollStrike();
            RollStrike();
           
            Assert.That(game.Score(), Is.EqualTo(30));
        }

        [Test]
        public void PerfectGame()
        {
            ManyRolls(12, 10);
            Assert.That(game.Score(), Is.EqualTo(300));
        }
    }
}
