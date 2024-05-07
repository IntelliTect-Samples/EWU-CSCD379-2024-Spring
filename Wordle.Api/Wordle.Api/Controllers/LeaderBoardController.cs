using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Controllers;

[ApiController]
public class LeaderBoardController : ControllerBase
{
    private readonly WordleServicing wordleService;

    public LeaderBoardController(WordleServicing service)
    {
        this.wordleService = service;
    }


}

