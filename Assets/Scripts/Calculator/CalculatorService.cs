using Core;
using UnityEngine;

namespace Calculator
{
    public class CalculatorService : ICalculatorService
    {
        public void ApplyInput(string input)
        {
            Debug.Log($"Applying input: {input}");
        }
    }
}