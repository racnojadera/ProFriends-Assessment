using System.Runtime;

namespace EquityCalculatorAPI.Model
{
    public class StatusDto
    {
        public float Balance { get; set; }
        public DateTime DueDate { get; set; }
        public int Term {  get; set; }
        public float Amount { get; set; }
        public float Interest => Balance * (float)0.05;
        public float Insurance => Amount * (float)0.01;
        public float Total => Amount + Interest + Insurance;
    }
}
