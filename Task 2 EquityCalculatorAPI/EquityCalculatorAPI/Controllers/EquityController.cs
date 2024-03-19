using EquityCalculatorAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EquityCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EquityController : ControllerBase
    {
        private static List<StatusDto> listStatus = new List<StatusDto>();

        EquityDto userInput = new EquityDto()
        {
            sellingPrice = 10000,
            dateTime = new DateTime(2022, 4, 5),
            equityTerm = 5
        };

        [HttpPost]
        public void PopulateListStatus()
        {
            for(int i = 1; i <= userInput.equityTerm; i++)
            {
                StatusDto temp = new StatusDto()
                {
                    Balance = userInput.sellingPrice - (i * userInput.monthlyAmount),
                    DueDate = userInput.startDate.AddMonths(i-1),
                    Term = i,
                    Amount = userInput.monthlyAmount,
                };
                listStatus.Add(temp);
            }
        }

        [HttpGet]
        public List<StatusDto> GetListStatus()
        {
            return listStatus;
        }

        [HttpDelete]
        public void DeleteListStatus()
        {
            listStatus.Clear();
        }
    }
}
