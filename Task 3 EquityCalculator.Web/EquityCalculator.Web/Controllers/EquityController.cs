using EquityCalculator.Web.Data;
using EquityCalculator.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquityCalculator.Web.Controllers
{
    public class EquityController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EquityController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult InitialRun()
        {
            foreach (var entity in dbContext.EquityStatuses)
            {
                dbContext.EquityStatuses.Remove(entity);
            }
            dbContext.SaveChangesAsync();

            return Add();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserInput userInput)
        {
            foreach (var entity in dbContext.EquityStatuses)
            {
                dbContext.EquityStatuses.Remove(entity);
            }
            await dbContext.SaveChangesAsync();

            var initValue = new UserInput()
            {
                sellingPrice = userInput.sellingPrice,
                dateTime = userInput.dateTime,
                equityTerm = userInput.equityTerm
            };

            for (int i = 1; i <= userInput.equityTerm; i++)
            {
                EquityStatus temp = new EquityStatus()
                {
                    Balance = (float)Math.Round(initValue.sellingPrice - (i * initValue.monthlyAmount),2),
                    DueDate = initValue.startDate.AddMonths(i - 1),
                    Term = i,
                    Amount = (float)Math.Round(initValue.monthlyAmount, 2),
                };
                temp.Interest = (float)Math.Round(temp.Balance * (float)0.05, 2);
                temp.Insurance = (float)Math.Round(temp.Amount * (float)0.01, 2);
                temp.Total = (float)Math.Round(temp.Amount + temp.Interest + temp.Insurance,2);

                await dbContext.EquityStatuses.AddAsync(temp);
                await dbContext.SaveChangesAsync();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var test = await dbContext.EquityStatuses.ToListAsync();
            return View(test);
        }
    }
}
