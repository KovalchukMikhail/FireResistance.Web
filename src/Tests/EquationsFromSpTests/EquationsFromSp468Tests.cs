using CalculationException;
using EquationsFromSp;
using EquationsFromSp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSpTests
{
    public class EquationsFromSp468Tests
    {
        IEquationsFromSp468 equations;
        public EquationsFromSp468Tests()
        {
            equations = new EquationsFromSp468();
        }

        [Fact]
        public void GetRbWithGammaBt_CorrectValues_ReturnCorrectAnswer()
        {
            // Arrange
            double Rb = 22;
            double gammaBt = 0.7;
            double correctAnswer = 15.4;
            // Act
            double result = Math.Round(equations.GetRbtWithGammaBtt(Rb, gammaBt), 1);
            // Assert
            Assert.Equal(correctAnswer, result);
        }
        [Theory]
        [InlineData(-22, 0.7)]
        [InlineData(22, -0.7)]
        public void GetRbWithGammaBt_InvalidValue_ThrowValueException(double Rb, double gammaBt)
        {
            // Act Assert
            Assert.Throws<ValueException>(() => equations.GetRbtWithGammaBtt(Rb, gammaBt));
        }
        [Fact]
        public void GetRbWithGammaBtt_CorrectValues_ReturnCorrectAnswer()
        {
            // Arrange
            double Rb = 22;
            double gammaBtt = 0.7;
            double correctAnswer = 15.4;
            // Act
            double result = Math.Round(equations.GetRbtWithGammaBtt(Rb, gammaBtt), 1);
            // Assert
            Assert.Equal(correctAnswer, result);
        }
        [Theory]
        [InlineData(-22, 0.7)]
        [InlineData(22, -0.7)]
        public void GetRbWithGammaBtt_InvalidValue_ThrowValueException(double Rb, double gammaBtt)
        {
            // Act Assert
            Assert.Throws<ValueException>(() => equations.GetRbtWithGammaBtt(Rb, gammaBtt));
        }
        [Fact]
        public void GetEbt_CorrectValues_ReturnCorrectAnswer()
        {
            // Arrange
            double Eb = 22;
            double betaB = 0.7;
            double correctAnswer = 15.4;
            // Act
            double result = Math.Round(equations.GetEbt(Eb, betaB), 1);
            // Assert
            Assert.Equal(correctAnswer, result);
        }
        [Theory]
        [InlineData(-22, 0.7)]
        [InlineData(22, -0.7)]
        public void GetEbt_InvalidValue_ThrowValueException(double Eb, double betaB)
        {
            // Act Assert
            Assert.Throws<ValueException>(() => equations.GetEbt(Eb, betaB));
        }
        [Fact]
        public void GetEbTau_CorrectValues_ReturnCorrectAnswer()
        {
            // Arrange
            double Eb = 24;
            double FiBCr = 3;
            double correctAnswer = 6;
            // Act
            double result = equations.GetEbTau(Eb, FiBCr);
            // Assert
            Assert.Equal(correctAnswer, result);
        }
        [Theory]
        [InlineData(-24, 3)]
        [InlineData(24, -3)]
        public void GetEbTau_InvalidValue_ThrowValueException(double Eb, double FiBCr)
        {
            // Act Assert
            Assert.Throws<ValueException>(() => equations.GetEbTau(Eb, FiBCr));
        }
        [Fact]
        public void GetRsWithGammaSt_CorrectValues_ReturnCorrectAnswer()
        {
            // Arrange
            double Rs = 500;
            double gammaSt = 0.5;
            double correctAnswer = 250;
            // Act
            double result = equations.GetRsWithGammaSt(Rs, gammaSt);
            // Assert
            Assert.Equal(correctAnswer, result);
        }
        [Theory]
        [InlineData(-500, 0.5)]
        [InlineData(500, -0.5)]
        public void GetRsWithGammaSt_InvalidValue_ThrowValueException(double Rb, double gammaBt)
        {
            // Act Assert
            Assert.Throws<ValueException>(() => equations.GetRsWithGammaSt(Rb, gammaBt));
        }
    }
}
