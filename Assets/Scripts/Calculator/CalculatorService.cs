using Core;
using UnityEngine;

namespace Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IInputHandler _inputHandler;

        public CalculatorService(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }
        
        public bool ApplyInput(string input)
        {
            Debug.Log($"Applying input: {input}");
            return _inputHandler.HandleInput(input, out var result);
        }
    }
}