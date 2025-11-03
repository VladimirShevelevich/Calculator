namespace Calculator
{
    public interface IInputHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result">Expression result if success </param>
        /// <returns>Whether the operation is success</returns>
        public bool HandleInput(string input, out int result);
    }
}