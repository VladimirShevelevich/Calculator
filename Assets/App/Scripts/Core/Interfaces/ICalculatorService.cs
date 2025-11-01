namespace Core
{
    public interface ICalculatorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Whether the operation is success</returns>
        public bool ApplyInput(string input);
        public ICalculatorModel CalculatorModel { get; }
    }
}