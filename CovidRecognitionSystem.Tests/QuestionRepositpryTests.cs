using CovidRecognitionSystem.DAL.Repositories;
using FluentAssertions;
using System;
using Xunit;

namespace CovidRecognitionSystem.Tests
{
    public class QuestionRepositpryTests
    {
        [Fact]
        public void GetCovidChance_WhenQuestion0_ShouldBeEqualTo091()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(0, "12-18 лет");

            var expectedCovid = Math.Round(10 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetCovidChance(); 

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetGrippeChance_WhenQuestion0_ShouldBeEqualTo18()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(0, "12-18 лет");

            var expectedCovid = Math.Round(20 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetGrippeChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetOrviChance_WhenQuestion0_ShouldBeEqualTo6()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(0, "12-18 лет");

            var expectedCovid = Math.Round(70 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetOrviChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetCovidChance_WhenQuestion1_ShouldBeEqualTo7()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(1, "Да");

            var expectedCovid = Math.Round(80 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetCovidChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetGrippeChance_WhenQuestion1_ShouldBeEqualTo045()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(1, "Да");

            var expectedCovid = Math.Round(5 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetGrippeChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetOrviChance_WhenQuestion1_ShouldBeEqualTo045()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(1, "Да");

            var expectedCovid = Math.Round(5 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetOrviChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetCovidChance_WhenQuestion2_ShouldBeEqualTo4()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(2, "7-14 дней");

            var expectedCovid = Math.Round(50 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetCovidChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetGrippeChance_WhenQuestion2_ShouldBeEqualTo2()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(2, "7-14 дней");

            var expectedCovid = Math.Round(25 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetGrippeChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetOrviChance_WhenQuestion2_ShouldBeEqualTo2()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(2, "7-14 дней");

            var expectedCovid = Math.Round(25 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetOrviChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetCovidChance_WhenQuestion3_ShouldBeEqualTo091()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(3, "Нет");

            var expectedCovid = Math.Round(10 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetCovidChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetGrippeChance_WhenQuestion3_ShouldBeEqualTo091()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(3, "Нет");

            var expectedCovid = Math.Round(10 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetGrippeChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }

        [Fact]
        public void GetOrviChance_WhenQuestion3_ShouldBeEqualTo091()
        {
            //Arrange
            QuestionRepository questionRepository = new QuestionRepository();

            questionRepository.SetBalls(3, "Нет");

            var expectedCovid = Math.Round(10 / 11.0, 2);

            //Act
            var covidBalls = questionRepository.GetOrviChance();

            //Assert
            covidBalls.Should().Be(expectedCovid);
        }
    }
}