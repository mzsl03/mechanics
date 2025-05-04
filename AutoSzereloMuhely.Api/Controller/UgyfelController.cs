using AutoSzereloMuhely.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoSzereloMuhely.API.Controller;


[ApiController]
[Route("ugyfel")]
public class UgyfelController : ControllerBase
{
    private readonly IUgyfelService _ugyfelService;
    
}