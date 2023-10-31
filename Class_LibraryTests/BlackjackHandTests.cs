using Microsoft.VisualStudio.TestTools.UnitTesting;
using Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Tests
{
    [TestClass()]
    public class BlackjackHandTests
    {
        [TestMethod()]
        public void BlackjackHandTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BlackjackHandTest1()
        {
            var hand = new BlackjackHand();
            var checkHand = new BlackjackHand();
            var blackJackHand = new BlackjackHand();

            hand.AddCard(new BlackjackCard(CardFace.A, CardSuit.Heart));
            hand.AddCard(new BlackjackCard(CardFace.Eight, CardSuit.Club));
            Assert.AreEqual(19, hand.Score);

            checkHand.AddCard(new BlackjackCard(CardFace.A, CardSuit.Heart));
            checkHand.AddCard(new BlackjackCard(CardFace.Eight, CardSuit.Club));
            checkHand.AddCard(new BlackjackCard(CardFace.Ten, CardSuit.Diamond));
            Assert.AreEqual(19, hand.Score);

            blackJackHand.AddCard(new BlackjackCard(CardFace.K, CardSuit.Club));
            blackJackHand.AddCard(new BlackjackCard(CardFace.A, CardSuit.Diamond));
            Assert.AreEqual(21, hand.Score);


        }

        [TestMethod()]
        public void AddCardTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawTest1()
        {
            Assert.Fail();
        }
    }
}