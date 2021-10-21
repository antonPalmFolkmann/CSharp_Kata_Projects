using System.Collections.Generic;
using Xunit;

namespace Yatzy.Test
{
    public class YatzyTest
    {
        public List<Yatzy> SetupYatzySuite(){
            List<Yatzy> yatzyList = new List<Yatzy>();

            // Index 0-5
            yatzyList.Add(new Yatzy(1,1,1,1,1));
            yatzyList.Add(new Yatzy(2,2,2,2,2));
            yatzyList.Add(new Yatzy(3,3,3,3,3));
            yatzyList.Add(new Yatzy(4,4,4,4,4));
            yatzyList.Add(new Yatzy(5,5,5,5,5));
            yatzyList.Add(new Yatzy(6,6,6,6,6));

            // Index 6-7
            yatzyList.Add(new Yatzy(1,2,3,4,5));
            yatzyList.Add(new Yatzy(2,3,4,5,6));

            // Index 8-13
            yatzyList.Add(new Yatzy(1,1,2,2,2));
            yatzyList.Add(new Yatzy(2,2,3,3,3));
            yatzyList.Add(new Yatzy(3,3,4,4,4));
            yatzyList.Add(new Yatzy(4,4,5,5,5));
            yatzyList.Add(new Yatzy(5,5,6,6,6));
            yatzyList.Add(new Yatzy(6,6,1,1,1));

            // Index 14-
            yatzyList.Add(new Yatzy(1,1,2,3,4));
            yatzyList.Add(new Yatzy(1,2,2,3,5));
            yatzyList.Add(new Yatzy(2,2,4,6,6));

            return yatzyList;
        }

        [Theory]
        [InlineData(3,4,5,6,7)]
        public void Test_Illegal_Inputs_And_Verify_Exceptions(int d1, int d2, int d3, int d4, int d5){
            Yatzy yatzy = new Yatzy(d1,d2,d3,d4,d5);
            
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(1, 0)]
        [InlineData(6, 1)]
        [InlineData(7, 0)]
        [InlineData(8, 2)]
        [InlineData(13, 3)]
        public void Test_Ones_Given_Different_Inputs_Returns_Int(int index, int expected)
        {
        //Given
        List<Yatzy> yatzies = SetupYatzySuite();

        //When
        Yatzy yatzy = yatzies[index];
        
        //Then
        Assert.Equal(expected, yatzy.Ones());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1,10)]
        [InlineData(6, 2)]
        [InlineData(7, 2)]
        [InlineData(8, 6)]
        public void Test_Twos_Given_Different_Inputs_Returns_Int(int index, int expected)
        {
        //Given
        List<Yatzy> yatzies = SetupYatzySuite();
        
        //When
        Yatzy yatzy = yatzies[index];
        
        //Then
        Assert.Equal(expected, yatzy.Twos());
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(2,15)]
        [InlineData(7,3)]
        [InlineData(9,9)]
        public void Test_Threes_Given_Different_Inputs_Returns_Int(int index, int expected){
            //Given 
            List<Yatzy> yatzies = SetupYatzySuite();

            //When 
            Yatzy yatzy = yatzies[index];

            //Then
            Assert.Equal(expected, yatzy.Threes());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3,20)]
        [InlineData(6, 4)]
        [InlineData(10,12)]
        public void Test_Fours_Given_Different_Inputs_Returns_Int(int index, int expected){
            //Given
            List<Yatzy> yatzies = SetupYatzySuite();

            //When
            Yatzy yatzy = yatzies[index];

            //Then
            Assert.Equal(expected, yatzy.Fours());
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(4,25)]
        [InlineData(6,5)]
        [InlineData(11,15)]
        public void Test_Fives_Given_Different_Inputs_Returns_Int(int index, int expected)
        {
            //Given
            List<Yatzy> yatzies = SetupYatzySuite();

            //When
            Yatzy yatzy = yatzies[index];

            //Then
            Assert.Equal(expected, yatzy.Fives());
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(5,30)]
        [InlineData(7,6)]
        [InlineData(12,18)]
        public void Test_Sixes_Given_Different_Inputs_Returns_Int(int index, int expected)
        {
            //Given
            List<Yatzy> yatzies = SetupYatzySuite();

            //When
            Yatzy yatzy = yatzies[index];

            //Then
            Assert.Equal(expected, yatzy.Sixes());
        }

        [Theory]
        [InlineData(6,0)]
        [InlineData(14,2)]
        [InlineData(16,12)]
        public void Test_Score_One_Pair_Given_Different_Roles(int index, int expected){
            //Given
            List<Yatzy> yatzies = SetupYatzySuite();

            //When
            Yatzy yatzy = yatzies[index];

            //Then
            Assert.Equal(expected, yatzy.OnePair());
        }

        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            var expected = 15;
            var actual = Yatzy.Chance(2, 3, 4, 5, 1);
            Assert.Equal(expected, actual);
            Assert.Equal(16, Yatzy.Chance(3, 3, 4, 5, 1));
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, Yatzy.FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, Yatzy.FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, Yatzy.FourOfAKind(3, 3, 3, 3, 3));
        }

        [Fact]
        public void fullHouse()
        {
            Assert.Equal(18, Yatzy.FullHouse(6, 2, 2, 2, 6));
            Assert.Equal(0, Yatzy.FullHouse(2, 3, 4, 5, 6));
        }

        [Fact]
        public void largeStraight()
        {
            Assert.Equal(20, Yatzy.LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, Yatzy.LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, Yatzy.LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void smallStraight()
        {
            Assert.Equal(15, Yatzy.SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, Yatzy.SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, Yatzy.SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void three_of_a_kind()
        {
            Assert.Equal(9, Yatzy.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, Yatzy.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(9, Yatzy.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void two_Pair()
        {
            Assert.Equal(16, Yatzy.TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(16, Yatzy.TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            var expected = 50;
            var actual = Yatzy.yatzy(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, Yatzy.yatzy(6, 6, 6, 6, 6));
            Assert.Equal(0, Yatzy.yatzy(6, 6, 6, 6, 3));
        }
    }
}