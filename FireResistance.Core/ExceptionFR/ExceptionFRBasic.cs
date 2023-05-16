
namespace FireResistance.Core.ExceptionFR
{
    internal class ExceptionFRBasic : Exception
    {
        public double InvalidValue { get; set; }

        public ExceptionFRBasic(string message, double invalidValue) : base(message)
        {
            InvalidValue = invalidValue;
        }
    }
}
