using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcLogic : MonoBehaviour
{
    char operationFlag;
    double operand1 = 0d, operand2 = 0d;
    public Leds mainLeds;

    void Start()
    {
        operationFlag = ' ';
    }
    public void PartOfOperation(char operationSymbol)
    {
        if (mainLeds.CalcDisplay.text != "Многовато" && mainLeds.CalcDisplay.text != "Маловато")
        {
            operationFlag = operationSymbol;
            operand1 = double.Parse(mainLeds.CalcDisplay.text);
            mainLeds.ClearCalcDisplay();
        }
        else
        {
            mainLeds.CalcDisplay.text = "";
        }
    }
    public void ClearCalcMemory()
    {
        operand1 = 0d;
        operand2 = 0d;
        mainLeds.CalcDisplay.text = "0";
        operationFlag = ' ';
    }
    public void ComputeResult()
    {
        if (operationFlag != ' ')
        {
            operand2 = double.Parse(mainLeds.CalcDisplay.text);


            double operationResult = 0d;
            switch (operationFlag)
            {
                case ('+'):
                    operationResult = operand1 + operand2;
                    operationFlag = ' ';
                    break;
                case ('-'):
                    operationResult = operand1 - operand2;
                    operationFlag = ' ';
                    break;
                case ('*'):
                    operationResult = operand1 * operand2;
                    operationFlag = ' ';
                    break;
                case ('/'):
                    operationResult = operand1 / operand2;
                    operationFlag = ' ';
                    break;
            }
            operand1 = operationResult;
            mainLeds.ShowOperationResult(operationResult);
        }
    }
    public void ComputeSqr()
    {
        double operationResult = 0d;
        float operandSqr = float.Parse(mainLeds.CalcDisplay.text);
        operationResult = Mathf.Sqrt(operandSqr);
        mainLeds.ShowOperationResult(operationResult);
    }

}
