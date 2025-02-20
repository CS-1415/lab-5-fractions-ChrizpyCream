using NUnit.Framework;
using Lab05;

namespace Lab05.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test_RationalNumber_PositiveNumeratorAndDenominator()
        {
            RationalNumber rational = new RationalNumber(3, 4);
            Assert.That(rational.Numerator, Is.EqualTo(3));
            Assert.That(rational.Denominator, Is.EqualTo(4));
        }

        [Test]
        public void Test_RationalNumber_Equality()
        {
            RationalNumber rational1 = new RationalNumber(3, 4);
            RationalNumber rational2 = new RationalNumber(3, 4);

            // overridden Equals method to compare the two objects
            Assert.That(rational1, Is.EqualTo(rational2)); // it Should pass if Equals is properly overridden
        }

        [Test]
        public void Test_RationalNumber_PositiveNumeratorAndNegativeDenominator()
        {
            RationalNumber rational = new RationalNumber(3, -4);
            Assert.That(rational.Numerator, Is.EqualTo(-3));
            Assert.That(rational.Denominator, Is.EqualTo(4));
        }

        [Test]
        public void Test_RationalNumber_NegativeNumeratorAndPositiveDenominator()
        {
            RationalNumber rational = new RationalNumber(-3, 4);
            Assert.That(rational.Numerator, Is.EqualTo(-3));
            Assert.That(rational.Denominator, Is.EqualTo(4));
        }

        [Test]
        public void Test_RationalNumber_NegativeNumeratorAndNegativeDenominator()
        {
            RationalNumber rational = new RationalNumber(-3, -4);
            Assert.That(rational.Numerator, Is.EqualTo(3));
            Assert.That(rational.Denominator, Is.EqualTo(4));
        }

        [Test]
        public void Test_RationalNumber_Simplification()
        {
            RationalNumber rational = new RationalNumber(20, 4);
            Assert.That(rational.Numerator, Is.EqualTo(5));
            Assert.That(rational.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void Test_RationalNumber_CanNotBeSimplified()
        {
            RationalNumber rational = new RationalNumber(7, 12);
            Assert.That(rational.Numerator, Is.EqualTo(7));
            Assert.That(rational.Denominator, Is.EqualTo(12));
        }

        [Test]
        public void Test_MixedNumber_CorrectWholeAndPartialUnits()
        {
            MixedNumber mixed = new MixedNumber(7, 3);
            Assert.That(mixed.WholeUnits, Is.EqualTo(2));
            Assert.That(mixed.PartialUnits, Is.EqualTo(new RationalNumber(1, 3)));
        }

        [Test]
        public void Test_MixedNumber_CorrectWholeAndPartialUnits2()
        {
            MixedNumber mixed = new MixedNumber(125, 50);
            // it makes sure that new MixedNumber(125,50).Equals(new MixedNumber(5,2)) is true
            Assert.That(mixed, Is.EqualTo(new MixedNumber(5, 2)));
        }

        [Test]
        public void Test_MixedNumber_NoWholeUnits()
        {
            MixedNumber mixed = new MixedNumber(1, 3);
            Assert.That(mixed.WholeUnits, Is.EqualTo(0));
            Assert.That(mixed.PartialUnits, Is.EqualTo(new RationalNumber(1, 3)));
        }
    }
}