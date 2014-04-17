using System;
using NUnit.Framework;
using Shouldly;

namespace Bowling.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void first_roll()
        {
            var game = new Game();

            game.AddRoll(7);

            game.GetScore().ShouldBe(7);
        }

        [Test]
        public void two_rolls_under10()
        {
            var game = new Game();

            game.AddRoll(7);
            game.AddRoll(2);
            
            game.GetScore().ShouldBe(9);
        }

        [Test]
        public void my_little_spare()
        {
            var game = new Game();

            game.AddRoll(5);
            game.AddRoll(5);
       
            game.AddRoll(4);

            // total pins: 14
            
            // first frame raw: 10
            // second frame raw: 4
            // first frame spare bonus: 4
            
            game.GetScore().ShouldBe(18);
        }
    }
}