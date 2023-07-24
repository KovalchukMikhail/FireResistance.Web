
namespace FireResistance.Core.Entities.Calculator.AbstractClasses
{
    internal abstract class CalculatorAbstract <T>
    {
        public T ResultBuilder { get; set; }

        public abstract void Construct();
    }
}
