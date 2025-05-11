namespace DevBank_WebApi.Modules.Controllers;

using UseCases;
using Shared.Domain.Entities;
using Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TransactionController(
    ITransactionUseCase transactionUseCase
) : ControllerBase
{
    [HttpGet]
    [Route("/history")]
    public async Task<IActionResult> Get()
    {
        var transactions = await transactionUseCase.GetAllTransactions();

        return Ok(
            new ApiResponse<IReadOnlyList<Transaction>>
            {
                Message = "The transactions were retrieved successfully",
                Data = transactions
            }    
        );
    }
}