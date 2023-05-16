namespace FireResistance.Core
{
    internal interface IFireResistance <N, K>
    {
        public void PerformCalculation(K data);
        public N GetResult();
    }
}
