using System;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Represents core for computing data and provides methods to simulating user input.
    /// </summary>
    public class CalculatorCore
    {
        private readonly CultureInfo culture = CultureInfo.InvariantCulture;
        public string LabelValue { get; private set; }
        public string TextBoxValue { get; private set; }
        private decimal currentResult;
        private BinaryOperations lastOperation;
        private CalculatorCoreState currentState;
        private const int TextBoxCapacity = 16;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorCore"/> class.
        /// </summary>
        public CalculatorCore()
        {
            TextBoxValue = "0";
            LabelValue = "";
            currentState = CalculatorCoreState.Initial;
        }

        /// <summary>
        /// Simulate pressing button with specified digit.
        /// </summary>
        /// <param name="digit">Specified digit.</param>
        public void PressButtonDigits(byte digit)
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    AssignEnteredValueToTextBox(digit.ToString(culture));

                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    AddValueToEndOfTextBox(digit.ToString(culture));

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    AssignEnteredValueToTextBox(digit.ToString(culture));

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    AssignEnteredValueToTextBox(digit.ToString(culture));

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    AddValueToEndOfTextBox(digit.ToString(culture));

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        /// <summary>
        /// Simulate pressing CE button.
        /// </summary>
        public void PressButtonCE()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    ResetTextBox();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    ResetTextBox();

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.Initial;
                    ResetTextBox();

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    ResetTextBox();

                    break;
                case CalculatorCoreState.Exception:
                    currentState = CalculatorCoreState.Initial;
                    ResetAll();

                    break;
            }
        }

        /// <summary>
        /// Simulate pressing C button.
        /// </summary>
        public void PressButtonC()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    ResetTextBox();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    ResetAll();

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.Initial;
                    ResetAll();

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    ResetAll();

                    break;
                case CalculatorCoreState.Exception:
                    currentState = CalculatorCoreState.Initial;
                    ResetAll();

                    break;
            }
        }

        /// <summary>
        /// Simulate pressing button backspace.
        /// </summary>
        public void PressButtonBack()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    RemoveLastDigit();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    break;
                case CalculatorCoreState.Result:
                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    RemoveLastDigit();

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        /// <summary>
        /// Simulate pressing button with specified binary operation.
        /// </summary>
        /// <param name="binaryOperation">Specified binary operation.</param>
        public void PressBinaryOperationButton(BinaryOperations binaryOperation)
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    ApplyFirstBinaryOperation(binaryOperation);

                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    ApplyFirstBinaryOperation(binaryOperation);

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    ChangeBinaryOperation(binaryOperation);

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    ApplyFirstBinaryOperation(binaryOperation);

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    try
                    {
                        ApplyOtherBinaryOperations(binaryOperation);
                    }
                    catch (DivideByZeroException e)
                    {
                        TextBoxValue = e.Message;
                        currentState = CalculatorCoreState.Exception;
                    }
                    catch (OverflowException e)
                    {
                        TextBoxValue = e.Message;
                        currentState = CalculatorCoreState.Exception;
                    }

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        /// <summary>
        /// Simulate pressing point button.
        /// </summary>
        public void PressButtonPoint()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    AddValueToEndOfTextBox("0.");

                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    TryToAddPoint();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    AssignEnteredValueToTextBox("0.");

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    AssignEnteredValueToTextBox("0.");

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    TryToAddPoint();

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        /// <summary>
        /// Simulate pressing equal button.
        /// </summary>
        public void PressEqualButton()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.Result;
                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.Result;
                    try
                    {
                        Summarize();
                    }
                    catch (DivideByZeroException e)
                    {
                        currentState = CalculatorCoreState.Exception;
                        TextBoxValue = e.Message;
                    }
                    catch (OverflowException e)
                    {
                        currentState = CalculatorCoreState.Exception;
                        TextBoxValue = e.Message;
                    }
                    break;
                case CalculatorCoreState.Result:
                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    currentState = CalculatorCoreState.Result;
                    try
                    {
                        Summarize();
                    }
                    catch (DivideByZeroException e)
                    {
                        currentState = CalculatorCoreState.Exception;
                        TextBoxValue = e.Message;
                    }
                    catch (OverflowException e)
                    {
                        currentState = CalculatorCoreState.Exception;
                        TextBoxValue = e.Message;
                    }

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        /// <summary>
        /// Simulate pressing negate button.
        /// </summary>
        public void PressNegateButton()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    NegateTextBox();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    NegateTextBox();

                    break;
                case CalculatorCoreState.Result:
                    NegateTextBox();

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    NegateTextBox();

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }
        
        private void AssignEnteredValueToTextBox(string value)
        {
            TextBoxValue = value;
        }

        private void AddValueToEndOfTextBox(string input)
        {
            if (TextBoxValue == "0")
            {
                TextBoxValue = input;
            }
            else
            {
                if (TextBoxValue.Length < TextBoxCapacity)
                {
                    TextBoxValue += input;
                }
            }
        }

        private void ResetTextBox() 
        {
            TextBoxValue = "0";
        }

        private void ResetAll()
        {
            TextBoxValue = "0";
            LabelValue = "";
        }

        private void RemoveLastDigit() 
        {
            TextBoxValue = TextBoxValue.Remove(TextBoxValue.Length - 1);
            if (!decimal.TryParse(TextBoxValue, NumberStyles.Any, culture, out _))
            {
                TextBoxValue = "0";
            }
        }

        private void TryToAddPoint()
        {
            if (!TextBoxValue.Contains("."))
            {
                TextBoxValue += ".";
            }
        }

        private void NegateTextBox() 
        {
            if (TextBoxValue[^1] == '.')
            {
                TextBoxValue = (-decimal.Parse(TextBoxValue, culture)).ToString(culture);
                TextBoxValue += '.';
            }
            else
            {
                TextBoxValue = (-decimal.Parse(TextBoxValue, culture)).ToString(culture);
            }
        }

        private void ApplyFirstBinaryOperation(BinaryOperations binaryOperation)
        {
            if (TextBoxValue[^1] == '.')
            {
                TextBoxValue = TextBoxValue.Remove(TextBoxValue.Length - 1);
            }

            LabelValue = TextBoxValue + " " + (char)int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
            lastOperation = binaryOperation;
            currentResult = decimal.Parse(TextBoxValue, culture);
        }

        private void ChangeBinaryOperation(BinaryOperations binaryOperation)
        {
            lastOperation = binaryOperation;

            LabelValue = LabelValue.Remove(LabelValue.Length - 1);
            LabelValue += (char)int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
        }

        private void PerformLastOperation()
        {
            switch (lastOperation)
            {
                case BinaryOperations.Multiply:
                    currentResult *= decimal.Parse(TextBoxValue, culture);
                    
                    break;
                case BinaryOperations.Add:
                    currentResult += decimal.Parse(TextBoxValue, culture);
                    
                    break;
                case BinaryOperations.Subtract:
                    currentResult -= decimal.Parse(TextBoxValue, culture);
                    
                    break;
                case BinaryOperations.Divide:
                    currentResult /= decimal.Parse(TextBoxValue, culture);

                    break;
            }

            if (currentResult == Math.Round(currentResult))
            {
                currentResult = Math.Round(currentResult);
            }

            TextBoxValue = currentResult.ToString(culture);
        }

        private void Summarize()
        {
            PerformLastOperation();

            LabelValue = "";
        }

        private void ApplyOtherBinaryOperations(BinaryOperations binaryOperation)
        {
            if (TextBoxValue[^1] == '.')
            {
                TextBoxValue = TextBoxValue.Remove(TextBoxValue.Length - 1);
            }
            
            LabelValue += " " + TextBoxValue;
            PerformLastOperation();
            lastOperation = binaryOperation;
            LabelValue += " " + (char)int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
        }
    }
}
