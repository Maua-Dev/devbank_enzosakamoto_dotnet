namespace DevBank_WebApi.Modules.Controllers;

using System.Net;
using Shared.Domain.Entities;
using Shared.Dtos;
using Shared.Helpers;
using Shared.Helpers.Errors;
using UseCases;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController(
    IUserUseCase userUseCase
) : ControllerBase
{
    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> Get()
    {
        var user = await userUseCase.GetUser();

        return Ok(
            new ApiResponse<User>
            {
                Message = "The user was retrieved successfully",
                Data = user
            }
        );
    }

    [HttpPost]
    [Route("/deposit")]
    public async Task<IActionResult> Deposit([FromBody] AmountDto amount)
    {
        try
        {
            var transaction = await userUseCase.UpdateBalance(TransactionType.Deposit, amount);

            return Ok(
                new ApiResponse<Transaction>
                {
                    Message = "The deposit has been executed successfully",
                    Data = transaction
                }
            );
        }
        catch (InvalidParams e)
        {
            return BadRequest(new ApiResponse
            {
                Message = e.Message,
            });
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError,
                new ApiResponse
                {
                    Message = e.Message,
                });
        }
    }

    [HttpPost]
    [Route("/withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] AmountDto amount)
    {
        try
        {
            var transaction = await userUseCase.UpdateBalance(TransactionType.Withdraw, amount);

            return Ok(
                new ApiResponse<Transaction>
                {
                    Message = "The withdraw has been executed successfully",
                    Data = transaction
                }
            );
        }
        catch (InsufficientFundsException e)
        {
            return UnprocessableEntity(new ApiResponse
            {
                Message = e.Message,
            });
        }
        catch (SuspectAmountException e)
        {
            return BadRequest(new ApiResponse
            {
                Message = e.Message,
            });
        }
        catch (InvalidParams e)
        {
            return BadRequest(new ApiResponse
            {
                Message = e.Message,
            });
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError,
                new ApiResponse
                {
                    Message = e.Message,
                });
        }
    }
}