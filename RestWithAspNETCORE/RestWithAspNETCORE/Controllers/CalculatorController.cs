using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNETCORE.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
  
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("SUM/{firstNumber}/{secondNumber}")]
    public IActionResult SUM(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("SUB/{firstNumber}/{secondNumber}")]
    public IActionResult SUB(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("MUL/{firstNumber}/{secondNumber}")]
    public IActionResult MUL(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("DIV/{firstNumber}/{secondNumber}")]
    public IActionResult DIV(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("Raiz/{firstNumber}")]
    public IActionResult RAIZ(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("SUM/{firstNumber}/{secondNumber}")]
  
    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number
            );
        return isNumber;
            
    }
}
