using System;
using System.Collections.Generic;
using NUnit.Framework;
using Blazor_Sylt;
using Blazor_Sylt.Business.Helper;
using Blazor_Sylt.Business.Models;
using Blazor_Sylt.Service.SyltServices;

namespace Blazor_Sylt.Tests
{
    public class SixDiceTests
    {
        private DiceLogic _diceLogic;
        private DiceHelper _diceHelper;

        [SetUp]
        public void SetUp()
        {
            _diceLogic = new DiceLogic();
            _diceHelper = new DiceHelper();
        }

        [TestCase(1, 2, 3, 4, 5, 6, true)]
        [TestCase(1, 3, 3, 4, 5, 6, false)]
        public void TestIfStraightLogicWorks(int val1, int val2, int val3, int val4, int val5, int val6, bool expected)
        {
            // Arrange
            var diceList = new List<Dice>()
            {
                new Dice() {Locked = false, Value = val1},
                new Dice() {Locked = false, Value = val2},
                new Dice() {Locked = false, Value = val3},
                new Dice() {Locked = false, Value = val4},
                new Dice() {Locked = false, Value = val5},
                new Dice() {Locked = false, Value = val6}
            };

            // Act
            var result = _diceLogic.CheckIfStraight(diceList);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestCase(1, 1, 3, 3, 5, 5, true)]
        [TestCase(5, 1, 3, 1, 5, 3, true)]
        [TestCase(1, 3, 3, 4, 5, 6, false)]
        [TestCase(3, 3, 3, 4, 5, 6, false)]
        [TestCase(3, 3, 3, 4, 4, 3, false)]
        public void TestIfThreePairWork(int val1, int val2, int val3, int val4, int val5, int val6, bool expected)
        {
            // Arrange
            var diceList = new List<Dice>()
            {
                new Dice() {Locked = false, Value = val1},
                new Dice() {Locked = false, Value = val2},
                new Dice() {Locked = false, Value = val3},
                new Dice() {Locked = false, Value = val4},
                new Dice() {Locked = false, Value = val5},
                new Dice() {Locked = false, Value = val6}
            };

            // Act
            var result = _diceLogic.CheckIfThreePair(diceList);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 1, 3, 3, 5, 5, false)]
        [TestCase(2, 2, 3, 3, 4, 4, false)]
        [TestCase(6, 3, 3, 4, 2, 6, true)]
        [TestCase(4, 2, 5, 2, 3, 6, false)]
        [TestCase(4, 2, 4, 2, 4, 4, false)]
        public void TestIfNothingWork(int val1, int val2, int val3, int val4, int val5, int val6, bool expected)
        {
            // Arrange
            var diceList = new List<Dice>()
            {
                new Dice() {Locked = false, Value = val1},
                new Dice() {Locked = false, Value = val2},
                new Dice() {Locked = false, Value = val3},
                new Dice() {Locked = false, Value = val4},
                new Dice() {Locked = false, Value = val5},
                new Dice() {Locked = false, Value = val6}
            };

            // Act
            var result = _diceLogic.CheckIfNothing(diceList);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 3, 3, 5, 5, false)]
        [TestCase(2, 3, 3, 4, 4, true)]
        [TestCase(3, 3, 4, 2, 6, true)]
        [TestCase(2, 5, 2, 3, 6, false)]
        [TestCase(2, 4, 2, 4, 4, false)]
        public void TestIfSyltWork(int val1, int val2, int val3, int val4, int val5, bool expected)
        {
            // Arrange
            var diceList = new List<Dice>()
            {
                new Dice() {Locked = false, Value = val1},
                new Dice() {Locked = false, Value = val2},
                new Dice() {Locked = false, Value = val3},
                new Dice() {Locked = false, Value = val4},
                new Dice() {Locked = false, Value = val5}
            };

            // Act
            var result = _diceLogic.CheckIfSylt(diceList);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestCase(1, 3, 3, 5, 5, 2)]
        [TestCase(2, 3, 3, 4, 4, 0)]
        [TestCase(3, 3, 4, 2, 3, 3)]
        [TestCase(2, 5, 2, 2, 2, 4.5)]
        [TestCase(1, 1, 1, 5, 3, 10.5)]
        public void TestIfScoringWork(int val1, int val2, int val3, int val4, int val5, double expected)
        {
            // Arrange
            var diceList = new List<Dice>()
            {
                new Dice() {Locked = false, Value = val1},
                new Dice() {Locked = false, Value = val2},
                new Dice() {Locked = false, Value = val3},
                new Dice() {Locked = false, Value = val4},
                new Dice() {Locked = false, Value = val5}
            };

            // Act
            var result = _diceHelper.GetTotalScore(diceList);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
