using Microsoft.EntityFrameworkCore;

namespace EquityCalculator.Web.Models.Entities
{
    public class EquityStatus
    {
        public Guid Id { get; set; }
        public float Balance { get; set; }
        public DateTime DueDate { get; set; }
        public int Term { get; set; }
        public float Amount { get; set; }
        public float Interest { get; set; }
        public float Insurance { get; set; }
        public float Total {  get; set; }
        //public float Interest => Balance * (float)0.05;
        //public float Insurance => Amount * (float)0.01;
        //public float Total => Amount + Interest + Insurance;
    }
}
