using EcoEnergyPartTwo.Models;
using EcoEnergyPartTwo.Models.Utilities;

namespace XUnitTests
{
    public class XUnitTests
    {
        const int NumDecimals = 2;
        const double Rati = 2;
        const string SolarType = "Solar";
        const string EolicType = "Eolic";
        const string HidroelectricType = "Hidroelectric";

        DateTime date = DateTime.Now;

        //SistemaSolar
        [Fact]
        public void TestSistemaSolar_HoresDeSolValid()
        {
            //Arrange
            int hores = 5;
            double expectedResult = Math.Round(hores * Rati, NumDecimals);
            var sistemaSolar = new SistemaSolar
            {
                HoursOfSun = hores,
                Rati = Rati
            };
            //Act
            double result = sistemaSolar.CalcularEnergia();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestSistemaSolar_HoresDeSolLimit()
        {
            //Arrange
            int hores = 1;
            double expectedResult = Math.Round(hores * Rati, NumDecimals);
            var sistemaSolar = new SistemaSolar
            {
                HoursOfSun = hores,
                Rati = Rati
            };
            //Act
            double result = sistemaSolar.CalcularEnergia();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        //[Fact]
        //public void TestSistemaSolar_HoresDeSolInvalid() //Ha de fallar
        //{
        //    //Arrange
        //    int hores = 0;
        //    double expectedResult = Math.Round(hores * Rati, NumDecimals);
        //    var sistemaSolar = new SistemaSolar
        //    {
        //        HoursOfSun = hores,
        //        Rati = Rati
        //    };
        //    //Act
        //    double result = sistemaSolar.CalcularEnergia();
        //    //Assert
        //    Assert.NotEqual(expectedResult, result);
        //}

        //SistemaEòlic
        [Fact]
        public void TestSistemaEolic_VelocitatValid()
        {
            //Arrange
            int speed = 10;
            double expectedResult = Math.Round(Math.Pow(speed, 3) * Rati, NumDecimals);
            var sistemaEolic = new SistemaEolic
            {
                WindSpeed = speed,
                Rati = Rati
            };
            //Act
            double result = sistemaEolic.CalcularEnergia();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestSistemaEolic_VelocitatLimit()
        {
            //Arrange
            int speed = 5;
            double expectedResult = Math.Round(Math.Pow(speed, 3) * Rati, NumDecimals);
            var sistemaEolic = new SistemaEolic
            {
                WindSpeed = speed,
                Rati = Rati
            };
            //Act
            double result = sistemaEolic.CalcularEnergia();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        //[Fact]
        //public void TestSistemaEolic_VelocitatInvalid() //Ha de fallar
        //{
        //    //Arrange
        //    int speed = 0;
        //    double expectedResult = Math.Round(Math.Pow(speed, 3) * Rati, NumDecimals);
        //    var sistemaEolic = new SistemaEolic
        //    {
        //        WindSpeed = speed,
        //        Rati = Rati
        //    };
        //    //Act
        //    double result = sistemaEolic.CalcularEnergia();
        //    //Assert
        //    Assert.NotEqual(expectedResult, result);
        //}

        //SistemaHidroelèctric
        [Fact]
        public void TestSistemaHidroelec_CabalValid()
        {
            //Arrange
            int flow = 30;
            double expectedResult = Math.Round(flow * 9.8 * Rati, NumDecimals);
            var sistemaHidroelectric = new SistemaHidroelectric
            {
                WaterFlow = flow,
                Rati = Rati
            };
            //Act
            double result = sistemaHidroelectric.CalcularEnergia();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestSistemaHidroelec_CabalLimit()
        {
            //Arrange
            int flow = 20;
            double expectedResult = Math.Round(flow * 9.8 * Rati, NumDecimals);
            var sistemaHidroelectric = new SistemaHidroelectric
            {
                WaterFlow = flow,
                Rati = Rati
            };
            //Act
            double result = sistemaHidroelectric.CalcularEnergia();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        //[Fact]
        //public void TestSistemaHidroelec_CabalInvalid() //Ha de fallar
        //{
        //    //Arrange
        //    int flow = 0;
        //    double expectedResult = Math.Round(flow * 9.8 * Rati, NumDecimals);
        //    var sistemaHidroelectric = new SistemaHidroelectric
        //    {
        //        WaterFlow = flow,
        //        Rati = Rati
        //    };
        //    //Act
        //    double result = sistemaHidroelectric.CalcularEnergia();
        //    //Assert
        //    Assert.NotEqual(expectedResult, result);
        //}

        // CheckNotInRange()
        [Fact]
        public void TestCheckNotInRange_True()
        {
            //Arrange
            double num = 5;
            double min = 6;
            //Act
            bool result = Utilities.CheckNotInRange(num, min);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void TestCheckNotInRange_Limit()
        {
            //Arrange
            double num = 5;
            double min = 5;
            //Act
            bool result = Utilities.CheckNotInRange(num, min);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void TestCheckNotInRange_False()
        {
            //Arrange
            double num = 5;
            double min = 4;
            //Act
            bool result = Utilities.CheckNotInRange(num, min);
            //Assert
            Assert.False(result);
        }

        // IsAllUpper()
        [Fact]
        public void TestIsAllUpper_True()
        {
            //Arrange
            string word = "HOLA";
            //Act
            bool result = Utilities.IsAllUpper(word);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void TestIsAllUpper_Limit()
        {
            //Arrange
            string word = "HOLa";
            //Act
            bool result = Utilities.IsAllUpper(word);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void TestIsAllUpper_False()
        {
            //Arrange
            string word = "holA";
            //Act
            bool result = Utilities.IsAllUpper(word);
            //Assert
            Assert.False(result);
        }

        // IsValidDate()
        [Fact]
        public void TestIsValidDate_True()
        {
            //Arrange
            string date = "12/2024";
            //Act
            bool result = Utilities.IsValidDate(date);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void TestIsValidDate_Limit()
        {
            //Arrange
            string date = "12/2025";
            //Act
            bool result = Utilities.IsValidDate(date);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void TestIsValidDate_FalseOne()
        {
            //Arrange
            string date = "12/2026";
            //Act
            bool result = Utilities.IsValidDate(date);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void TestIsValidDate_FalseTwo()
        {
            //Arrange
            string date = "aaaa";
            //Act
            bool result = Utilities.IsValidDate(date);
            //Assert
            Assert.False(result);
        }
    }
}