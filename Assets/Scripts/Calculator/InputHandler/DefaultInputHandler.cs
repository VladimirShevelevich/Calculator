namespace Calculator
{
    public class DefaultInputHandler : IInputHandler
    {
        public bool HandleInput(string input, out int result)
        {
            result = default;
            var split = input.Split('+');
            if (split.Length != 2)
                return false;
            
            if (uint.TryParse(split[0], out var left) && uint.TryParse(split[1], out var right))
            {
                result = (int)(left + right);
                return true;
            }

            return false;
        }
    }
}