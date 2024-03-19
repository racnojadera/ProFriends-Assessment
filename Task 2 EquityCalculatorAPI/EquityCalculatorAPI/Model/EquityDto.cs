using System.Runtime;

namespace EquityCalculatorAPI.Model
{
    public class EquityDto
    {
        public float sellingPrice { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public int equityTerm { get; set; }

        public float monthlyAmount => sellingPrice / equityTerm;

        public DateTime startDate => dateTime.AddMonths(1);
    }
}
