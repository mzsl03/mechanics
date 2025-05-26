using AutoSzereloMuhely.API.Controller;
using AutoSzereloMuhely.Domain;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace AutoSzereloMuhely.Tests.Controller;

public class UgyfelControllerUnitTest
{
    private readonly IUgyfelService _ugyfelService = A.Fake<IUgyfelService>();

    [Fact]
    public void UgyfelController_GetAll_Ugyfel_ReturnOk()
    {
        //Arrange
        var fakeUgyfelek = new List<Ugyfel> { new Ugyfel(), new Ugyfel()};
        A.CallTo(() => _ugyfelService.GetAll()).Returns(fakeUgyfelek);
        var controller = new UgyfelController(_ugyfelService);
        
        //Act
        var result = controller.GetAll();
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedUgyfelek = Assert.IsAssignableFrom<List<Ugyfel>>(okResult.Value);
        Assert.Equal(2, returnedUgyfelek.Count);
    }

    [Fact]
    public void UgyfelController_Get_ValidId_ReturnsUgyfel()
    {
        //Arrange
        var ugyfel = new Ugyfel { UgyfelId = 1 };
        A.CallTo(() => _ugyfelService.Get(1)).Returns(ugyfel);
        var controller = new UgyfelController(_ugyfelService);
        
        //Act
        var result = controller.Get(1).Result;
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(ugyfel, okResult.Value);
    }
    
    [Fact]
    public void UgyfelController_Get_UgyfelNotFound_ReturnsBadRequest()
    {
        // Arrange
        int id = 99;
        A.CallTo(() => _ugyfelService.Get(id)).Returns(null as Ugyfel);
        var controller = new UgyfelController(_ugyfelService);

        // Act
        var result = controller.Get(id);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Ugyfel>>(result);
        Assert.IsType<BadRequestResult>(actionResult.Result);
    }
    
    [Fact]
    public void UgyfelController_Add_Ugyfelek_ReturnOk()
    {
        //Arrange
        var fakeUgyfel = new Ugyfel();
        var controller = new UgyfelController(_ugyfelService);
        
        //Act
        var result = controller.Add(fakeUgyfel);

        //Assert
        A.CallTo(() => _ugyfelService.Add(fakeUgyfel)).MustHaveHappenedOnceExactly();
        Assert.IsType<OkResult>(result);

    }
    
    [Fact]
    public void UgyfelController_Delete_Ugyfel_ReturnOk()
    {
        // Arrange
        var fakeUgyfel = new Ugyfel { UgyfelId = 1 };
        A.CallTo(() => _ugyfelService.Get(1)).Returns(fakeUgyfel);
        var controller = new UgyfelController(_ugyfelService);

        // Act
        var result = controller.Delete(1);

        // Assert
        A.CallTo(() => _ugyfelService.Delete(1)).MustHaveHappenedOnceExactly();
        Assert.IsType<OkResult>(result);

    }
    
    [Fact]
    public void UgyfelController_Delete_UgyfelNotFound_ReturnNotFound()
    {
        // Arrange
        A.CallTo(() => _ugyfelService.Get(1)).Returns(null as Ugyfel);
        var controller = new UgyfelController(_ugyfelService);

        // Act
        var result = controller.Delete(1);

        // Assert
        Assert.IsType<BadRequestResult>(result);

    }
    
}