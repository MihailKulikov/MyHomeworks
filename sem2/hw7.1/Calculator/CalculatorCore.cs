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
            currentState = CalculatorCoreState.S1;
        }

        public void PressButtonWithNum0()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    break;
                case CalculatorCoreState.S2:
                    D2("0");

                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S5;
                    D1("0");

                    break;
                case CalculatorCoreState.S4:
                    currentState = CalculatorCoreState.S1;
                    D1("0");

                    break;
                case CalculatorCoreState.S5:
                    D2("0");

                    break;
                case CalculatorCoreState.S6:
                    break;
            }
        }

        public void PressButtonWithOtherDigits(byte digit)
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    currentState = CalculatorCoreState.S2;
                    D1(digit.ToString(culture));

                    break;
                case CalculatorCoreState.S2:
                    D2(digit.ToString(culture));

                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S5;
                    D1(digit.ToString(culture));

                    break;
                case CalculatorCoreState.S4:
                    currentState = CalculatorCoreState.S2;
                    D1(digit.ToString(culture));

                    break;
                case CalculatorCoreState.S5:
                    D2(digit.ToString(culture));

                    break;
                case CalculatorCoreState.S6:
                    break;
            }
        }

        public void PressButtonCE()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    break;
                case CalculatorCoreState.S2:
                    currentState = CalculatorCoreState.S1;
                    D3();

                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S5;
                    D3();

                    break;
                case CalculatorCoreState.S4:
                    currentState = CalculatorCoreState.S1;
                    D3();

                    break;
                case CalculatorCoreState.S5:
                    D3();

                    break;
                case CalculatorCoreState.S6:
                    currentState = CalculatorCoreState.S1;
                    D4();

                    break;
            }
        }

        public void PressButtonC()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    break;
                case CalculatorCoreState.S2:
                    currentState = CalculatorCoreState.S1;
                    D3();

                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S1;
                    D4();

                    break;
                case CalculatorCoreState.S4:
                    currentState = CalculatorCoreState.S1;
                    D4();

                    break;
                case CalculatorCoreState.S5:
                    currentState = CalculatorCoreState.S1;
                    D4();

                    break;
                case CalculatorCoreState.S6:
                    currentState = CalculatorCoreState.S1;
                    D4();

                    break;
            }
        }

        public void PressButtonBack()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    break;
                case CalculatorCoreState.S2:
                    D5();

                    break;
                case CalculatorCoreState.S3:
                    break;
                case CalculatorCoreState.S4:
                    break;
                case CalculatorCoreState.S5:
                    D5();

                    break;
                case CalculatorCoreState.S6:
                    break;
            }
        }

        public void PressBinaryOperationButton(BinaryOperations binaryOperation)
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    currentState = CalculatorCoreState.S3;
                    D8(binaryOperation);

                    break;
                case CalculatorCoreState.S2:
                    currentState = CalculatorCoreState.S3;
                    D8(binaryOperation);

                    break;
                case CalculatorCoreState.S3:
                    D9(binaryOperation);

                    break;
                case CalculatorCoreState.S4:
                    currentState = CalculatorCoreState.S3;
                    D8(binaryOperation);

                    break;
                case CalculatorCoreState.S5:
                    currentState = CalculatorCoreState.S3;
                    try
                    {
                        D11(binaryOperation);
                    }
                    catch (DivideByZeroException e)
                    {
                        TextBoxValue = e.Message;
                        currentState = CalculatorCoreState.S6;
                    }
                    catch (OverflowException e)
                    {
                        TextBoxValue = e.Message;
                        currentState = CalculatorCoreState.S6;
                    }

                    break;
                case CalculatorCoreState.S6:
                    break;
            }
        }

        public void PressButtonPoint()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    currentState = CalculatorCoreState.S2;
                    D2("0.");

                    break;
                case CalculatorCoreState.S2:
                    D6();

                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S5;
                    D1("0.");

                    break;
                case CalculatorCoreState.S4:
                    currentState = CalculatorCoreState.S2;
                    D1("0.");

                    break;
                case CalculatorCoreState.S5:
                    D6();

                    break;
                case CalculatorCoreState.S6:
                    break;
            }
        }

        public void PressEqualButton()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    break;
                case CalculatorCoreState.S2:
                    currentState = CalculatorCoreState.S4;
                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S4;
                    try
                    {
                        D10();
                    }
                    catch (DivideByZeroException e)
                    {
                        currentState = CalculatorCoreState.S6;
                        TextBoxValue = e.Message;
                    }
                    catch (OverflowException e)
                    {
                        currentState = CalculatorCoreState.S6;
                        TextBoxValue = e.Message;
                    }
                    break;
                case CalculatorCoreState.S4:
                    break;
                case CalculatorCoreState.S5:
                    currentState = CalculatorCoreState.S4;
                    try
                    {
                        D10();
                    }
                    catch (DivideByZeroException e)
                    {
                        currentState = CalculatorCoreState.S6;
                        TextBoxValue = e.Message;
                    }
                    catch (OverflowException e)
                    {
                        currentState = CalculatorCoreState.S6;
                        TextBoxValue = e.Message;
                    }

                    break;
                case CalculatorCoreState.S6:
                    break;
            }
        }

        public void PressNegateButton()
        {
            switch (currentState)
            {
                case CalculatorCoreState.S1:
                    break;
                case CalculatorCoreState.S2:
                    D7();

                    break;
                case CalculatorCoreState.S3:
                    currentState = CalculatorCoreState.S5;
                    D7();

                    break;
                case CalculatorCoreState.S4:
                    D7();

                    break;
                case CalculatorCoreState.S5:
                    D7();

                    break;
                case CalculatorCoreState.S6:
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
            TextBoxValue = (-decimal.Parse(TextBoxValue, culture)).ToString(culture);
        }

        private void D8(BinaryOperations binaryOperation) //ApplyFirstBinaryOperation
        {
            TextBoxValue = TextBoxValue.Replace(".", "");
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
                    TextBoxValue = currentResult.ToString(culture);

                    break;
                case BinaryOperations.Add:
                    currentResult += decimal.Parse(TextBoxValue, culture);
                    TextBoxValue = currentResult.ToString(culture);

                    break;
                case BinaryOperations.Subtract:
                    currentResult -= decimal.Parse(TextBoxValue, culture);
                    TextBoxValue = currentResult.ToString(culture);

                    break;
                case BinaryOperations.Divide:
                    currentResult /= decimal.Parse(TextBoxValue, culture);
                    TextBoxValue = currentResult.ToString(culture);

                    break;
            }
        }

        private void D10() //Summarize
        {
            PerformLastOperation();

            LabelValue = "";
        }

        private void D11(BinaryOperations binaryOperation)  //ApplyOtherBinaryOperations
        {
            TextBoxValue = TextBoxValue.Replace(".", " ");
            LabelValue += " " + TextBoxValue;
            PerformLastOperation();
            lastOperation = binaryOperation;
            LabelValue += " " + (char)int.Parse(Enum.Format(typeof(BinaryOperations), binaryOperation, "d"));
        }
    }
}
