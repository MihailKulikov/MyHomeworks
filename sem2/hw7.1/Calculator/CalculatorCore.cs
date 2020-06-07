using System;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Represents core for computing data and provides methods to simulating user input.
    /// </summary>
    public class CalculatorCore
    {
        public abstract class CalculatorCoreState
        {
            public abstract void PressButtonDigits(byte digit, CalculatorCore core);
            public abstract void PressButtonCE(CalculatorCore core);
            public abstract void PressButtonC(CalculatorCore core);
            public abstract void PressButtonBack(CalculatorCore core);
            public abstract void PressBinaryOperationButton(BinaryOperations binaryOperation, CalculatorCore core);
            public abstract void PressButtonPoint(CalculatorCore core);
            public abstract void PressEqualButton(CalculatorCore core);
            public abstract void PressNegateButton(CalculatorCore core);

            protected void SetState(CalculatorCore core, CalculatorCoreState state)
            {
                core.currentState = state;
            }
            
            protected void AssignEnteredValueToTextBox(string value, CalculatorCore core)
            {
                core.TextBoxValue = value;
            }

            protected void AddValueToEndOfTextBox(string input, CalculatorCore core)
            {
                if (core.TextBoxValue == "0")
                {
                    core.TextBoxValue = input;
                }
                else
                {
                    if (core.TextBoxValue.Length < TextBoxCapacity)
                    {
                        core.TextBoxValue += input;
                    }
                }
            }

            protected void ResetTextBox(CalculatorCore core)
            {
                core.TextBoxValue = "0";
            }

            protected void ResetAll(CalculatorCore core)
            {
                core.TextBoxValue = "0";
                core.LabelValue = "";
            }

            protected void RemoveLastDigit(CalculatorCore core)
            {
                core.TextBoxValue = core.TextBoxValue.Remove(core.TextBoxValue.Length - 1);
                if (!decimal.TryParse(core.TextBoxValue, NumberStyles.Any, core.Culture, out _))
                {
                    core.TextBoxValue = "0";
                }
            }

            protected void TryToAddPoint(CalculatorCore core)
            {
                if (!core.TextBoxValue.Contains("."))
                {
                    core.TextBoxValue += ".";
                }
            }

            protected void NegateTextBox(CalculatorCore core)
            {
                if (core.TextBoxValue[^1] == '.')
                {
                    core.TextBoxValue = (-decimal.Parse(core.TextBoxValue, core.Culture)).ToString(core.Culture);
                    core.TextBoxValue += '.';
                }
                else
                {
                    core.TextBoxValue = (-decimal.Parse(core.TextBoxValue, core.Culture)).ToString(core.Culture);
                }
            }

            protected void ApplyFirstBinaryOperation(BinaryOperations binaryOperation, CalculatorCore core)
            {
                if (core.TextBoxValue[^1] == '.')
                {
                    core.TextBoxValue = core.TextBoxValue.Remove(core.TextBoxValue.Length - 1);
                }

                core.LabelValue = core.TextBoxValue + " " +
                             (char) int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
                core.lastOperation = binaryOperation;
                core.currentResult = decimal.Parse(core.TextBoxValue, core.Culture);
            }

            protected void ChangeBinaryOperation(BinaryOperations binaryOperation, CalculatorCore core)
            {
                core.lastOperation = binaryOperation;

                core.LabelValue = core.LabelValue.Remove(core.LabelValue.Length - 1);
                core.LabelValue += (char) int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
            }
            
            private void PerformLastOperation(CalculatorCore core)
            {
                switch (core.lastOperation)
                {
                    case BinaryOperations.Multiply:
                        core.currentResult *= decimal.Parse(core.TextBoxValue, core.Culture);

                        break;
                    case BinaryOperations.Add:
                        core.currentResult += decimal.Parse(core.TextBoxValue, core.Culture);

                        break;
                    case BinaryOperations.Subtract:
                        core.currentResult -= decimal.Parse(core.TextBoxValue, core.Culture);

                        break;
                    case BinaryOperations.Divide:
                        core.currentResult /= decimal.Parse(core.TextBoxValue, core.Culture);

                        break;
                }

                if (core.currentResult == Math.Round(core.currentResult))
                {
                    core.currentResult = Math.Round(core.currentResult);
                }

                core.TextBoxValue = core.currentResult.ToString(core.Culture);
            }

            protected void Summarize(CalculatorCore core)
            {
                PerformLastOperation(core);
                core.LabelValue = "";
            }

            protected void ApplyOtherBinaryOperations(BinaryOperations binaryOperation, CalculatorCore core)
            {
                if (core.TextBoxValue[^1] == '.')
                {
                    core.TextBoxValue = core.TextBoxValue.Remove(core.TextBoxValue.Length - 1);
                }

                core.LabelValue += " " + core.TextBoxValue;
                PerformLastOperation(core);
                core.lastOperation = binaryOperation;
                core.LabelValue += " " + (char) int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
            }
        }

        public CultureInfo Culture => CultureInfo.InvariantCulture;
        public string LabelValue { get; private set; }
        public string TextBoxValue { get; private set; }
        private decimal currentResult;
        private BinaryOperations lastOperation;
        private CalculatorCoreState currentState = new InitialCalculatorState();
        private const int TextBoxCapacity = 16;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorCore"/> class.
        /// </summary>
        public CalculatorCore()
        {
            TextBoxValue = "0";
            LabelValue = "";
        }

        /// <summary>
        /// Simulate pressing button with specified digit.
        /// </summary>
        /// <param name="digit">Specified digit.</param>
        public void PressButtonDigits(byte digit)
        {
            currentState.PressButtonDigits(digit, this);
        }

        /// <summary>
        /// Simulate pressing CE button.
        /// </summary>
        public void PressButtonCE()
        {
            currentState.PressButtonCE(this);
        }

        /// <summary>
        /// Simulate pressing C button.
        /// </summary>
        public void PressButtonC()
        {
            currentState.PressButtonC(this);
        }

        /// <summary>
        /// Simulate pressing button backspace.
        /// </summary>
        public void PressButtonBack()
        {
            currentState.PressButtonBack(this);
        }

        /// <summary>
        /// Simulate pressing button with specified binary operation.
        /// </summary>
        /// <param name="binaryOperation">Specified binary operation.</param>
        public void PressBinaryOperationButton(BinaryOperations binaryOperation)
        {
            currentState.PressBinaryOperationButton(binaryOperation, this);
        }

        /// <summary>
        /// Simulate pressing point button.
        /// </summary>
        public void PressButtonPoint()
        {
            currentState.PressButtonPoint(this);
        }

        /// <summary>
        /// Simulate pressing equal button.
        /// </summary>
        public void PressEqualButton()
        {
            currentState.PressEqualButton(this);
        }

        /// <summary>
        /// Simulate pressing negate button.
        /// </summary>
        public void PressNegateButton()
        {
            currentState.PressNegateButton(this);
        }
    }
}
