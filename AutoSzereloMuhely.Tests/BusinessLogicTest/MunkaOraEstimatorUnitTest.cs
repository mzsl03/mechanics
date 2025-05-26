using AutoSzereloMuhely.Client.Services;
using AutoSzereloMuhely.Domain;
using FakeItEasy;

namespace AutoSzereloMuhely.Tests.BusinessLogicTest;

public class MunkaOraEstimatorUnitTest
{
    
    [Fact]
    public void MunkaOraEstimator_CountMunkaora_ReturnsCorrectValue()
    {
        // Arrange
        var munka = new Munka
        {
            Kategoria = EKategoria.Motor,
            GyartasEve = DateTime.Now.Year - 6,
            Sulyossag = 5
        };

        // Act
        var result = MunkaOraEstimator.CountMunkaora(munka);

        // Assert
        Assert.Equal("Munkaóra becslés: 4,8 óra", result);
    }
    
}