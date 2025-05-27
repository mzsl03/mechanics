using AutoSzereloMuhely.API.Controller;
using AutoSzereloMuhely.Domain;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace AutoSzereloMuhely.Tests.Controller;

public class MunkaControllerUnitTest
{

    private readonly IMunkaService _munkaService = A.Fake<IMunkaService>();
    
    [Fact]
    public void MunkaController_GetAll_Munkak_ReturnOk()
    {
        //Arrange
        var fakeMunkak = new List<Munka> { new Munka() , new Munka() };
        A.CallTo(() => _munkaService.GetAll()).Returns(fakeMunkak);
        var controller = new MunkaController(_munkaService);
        
        //Act
        var result = controller.GetAll();

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedMunkak = Assert.IsAssignableFrom<List<Munka>>(okResult.Value);
        Assert.Equal(2, returnedMunkak.Count);
    }

    [Fact]
    public void MunkaController_Get_ValidId_ReturnsMunka()
    {
        // Arrange
        var munka = new Munka { MunkaID = 1 };
        A.CallTo(() => _munkaService.Get(1)).Returns(munka);

        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Get(1).Result;

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(munka, okResult.Value);
    }
    
    [Fact]
    public void MunkaController_Get_MunkaNotFound_ReturnsBadRequest()
    {
        // Arrange
        int id = 99;
        A.CallTo(() => _munkaService.Get(id)).Returns(null as Munka);
        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Get(id);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Munka>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }
    
    [Fact]
    public void MunkaController_Add_Munkak_ReturnOk()
    {
        //Arrange
        var fakeMunkak = new Munka();
        var controller = new MunkaController(_munkaService);
        
        //Act
        var result = controller.Add(fakeMunkak);

        //Assert
        A.CallTo(() => _munkaService.Add(fakeMunkak)).MustHaveHappenedOnceExactly();
        Assert.IsType<OkResult>(result);

    }
    
    [Fact]
    public void MunkaController_Delete_Munkak_ReturnOk()
    {
        // Arrange
        var fakeMunka = new Munka { MunkaID = 1 };
        A.CallTo(() => _munkaService.Get(1)).Returns(fakeMunka);
        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Delete(1);

        // Assert
        A.CallTo(() => _munkaService.Delete(1)).MustHaveHappenedOnceExactly();
        Assert.IsType<OkResult>(result);

    }
    
    [Fact]
    public void MunkaController_Delete_MunkakNotFound_ReturnNotFound()
    {
        // Arrange
        A.CallTo(() => _munkaService.Get(1)).Returns(null as Munka);
        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Delete(1);

        // Assert
        Assert.IsType<BadRequestResult>(result);

    }
    
    [Fact]
    public void MunkaController_Update_ValidMunka_ReturnsOk()
    {
        // Arrange
        var munka = new Munka { MunkaID = 1, UgyfelId = 1, Rendszam = "ABC-123", GyartasEve = 2015, Kategoria = EKategoria.Motor, Leiras = "Csere", Sulyossag = 5, Allapot = EAllapot.Felvett };

        A.CallTo(() => _munkaService.Get(munka.MunkaID)).Returns(munka);

        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Update(munka.MunkaID, munka);

        // Assert
        A.CallTo(() => _munkaService.Update(munka)).MustHaveHappenedOnceExactly();
        Assert.IsType<OkResult>(result);
    }
    
    [Fact]
    public void MunkaController_Update_IdMismatch_ReturnsBadRequest()
    {
        // Arrange
        var munka = new Munka { MunkaID = 1 };
        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Update(2, munka);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public void MunkaController_Update_MunkaNotFound_ReturnsNotFound()
    {
        // Arrange
        var munka = new Munka { MunkaID = 1 };
        A.CallTo(() => _munkaService.Get(munka.MunkaID)).Returns(null as Munka);

        var controller = new MunkaController(_munkaService);

        // Act
        var result = controller.Update(1, munka);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    
    
}
