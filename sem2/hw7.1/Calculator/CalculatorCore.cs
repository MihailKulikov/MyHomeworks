using System;
using System.Globalization;

namespace Calculator
{
    public class CalculatorCore
    {
        private readonly CultureInfo culture = CultureInfo.InvariantCulture;
        public string LabelValue { get; private set; }
        public string TextBoxValue { get; private set; }
        private decimal currentResult;
        private BinaryOperations lastOperation;
        private CalculatorCoreState currentState;
        private const int TextBoxCapacity = 16;

        public CalculatorCore()
        {
            TextBoxValue = "0";
            LabelValue = "";
            currentState = CalculatorCoreState.Initial;
        }

        public void PressButtonDigits(byte digit)
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    D1(digit.ToString(culture));

                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    D2(digit.ToString(culture));

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    D1(digit.ToString(culture));

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    D1(digit.ToString(culture));

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    D2(digit.ToString(culture));

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        public void PressButtonCE()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    D3();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    D3();

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.Initial;
                    D3();

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    D3();

                    break;
                case CalculatorCoreState.Exception:
                    currentState = CalculatorCoreState.Initial;
                    D4();

                    break;
            }
        }

        public void PressButtonC()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    D3();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    D4();

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.Initial;
                    D4();

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    currentState = CalculatorCoreState.Initial;
                    D4();

                    break;
                case CalculatorCoreState.Exception:
                    currentState = CalculatorCoreState.Initial;
                    D4();

                    break;
            }
        }

        public void PressButtonBack()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    D5();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    break;
                case CalculatorCoreState.Result:
                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    D5();

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        public void PressBinaryOperationButton(BinaryOperations binaryOperation)
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    D8(binaryOperation);

                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    D8(binaryOperation);

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    D9(binaryOperation);

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    D8(binaryOperation);

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    currentState = CalculatorCoreState.BinaryOperationIntroduction;
                    try
                    {
                        D11(binaryOperation);
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

        public void PressButtonPoint()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    D2("0.");

                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    D6();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    D1("0.");

                    break;
                case CalculatorCoreState.Result:
                    currentState = CalculatorCoreState.FirstOperandIntroduction;
                    D1("0.");

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    D6();

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

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
                        D10();
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
                        D10();
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

        public void PressNegateButton()
        {
            switch (currentState)
            {
                case CalculatorCoreState.Initial:
                    break;
                case CalculatorCoreState.FirstOperandIntroduction:
                    D7();

                    break;
                case CalculatorCoreState.BinaryOperationIntroduction:
                    currentState = CalculatorCoreState.SecondOperandIntroduction;
                    D7();

                    break;
                case CalculatorCoreState.Result:
                    D7();

                    break;
                case CalculatorCoreState.SecondOperandIntroduction:
                    D7();

                    break;
                case CalculatorCoreState.Exception:
                    break;
            }
        }

        private void D1(string input) //AssignEnteredDigitToTextBox
        {
            TextBoxValue = input;
        }

        private void D2(string input) //AddValueToEndOfTextBox
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

        private void D3() //ResetTextBox
        {
            TextBoxValue = "0";
        }

        private void D4() //ResetAll
        {
            TextBoxValue = "0";
            LabelValue = "";
        }

        private void D5() //RemoveLastDigit
        {
            TextBoxValue = TextBoxValue.Remove(TextBoxValue.Length - 1);
            if (!decimal.TryParse(TextBoxValue, NumberStyles.Any, culture, out _))
            {
                TextBoxValue = "0";
            }
        }

        private void D6() //TryToAddPoint
        {
            if (!TextBoxValue.Contains("."))
            {
                TextBoxValue += ".";
            }
        }

        private void D7() //NegateTextBox
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

        private void D8(BinaryOperations binaryOperation) //ApplyFirstBinaryOperation
        {
            if (TextBoxValue[^1] == '.')
            {
                TextBoxValue = TextBoxValue.Remove(TextBoxValue.Length - 1);
            }

            LabelValue = TextBoxValue + " " + (char)int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
            lastOperation = binaryOperation;
            currentResult = decimal.Parse(TextBoxValue, culture);
        }

        private void D9(BinaryOperations binaryOperation) //ChangeBinaryOperation
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

        private void D10() //Summarize
        {
            PerformLastOperation();

            LabelValue = "";
        }

        private void D11(BinaryOperations binaryOperation)  //ApplyOtherBinaryOperations
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
