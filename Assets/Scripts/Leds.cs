using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leds : MonoBehaviour
{

    public TextMesh CalcDisplay;

    void Start()
    {
        CalcDisplay = gameObject.GetComponent<TextMesh>();
        CalcDisplay.text = "0";
    }

    public void UpdateCalcDisplay(char addingDigets)
    {
        if (CalcDisplay.text.Length <= 8)
        {
            if (CalcDisplay.text == "Многовато" || CalcDisplay.text == "Маловато") { CalcDisplay.text = ""; }
            if (addingDigets.ToString() == ",")
            {
                if (CalcDisplay.text == "0" || !CalcDisplay.text.Contains(","))
                {
                    CalcDisplay.text += addingDigets.ToString();
                }

            }
            else
            {
                if (CalcDisplay.text != "0") { CalcDisplay.text += addingDigets.ToString(); }
                else { CalcDisplay.text = addingDigets.ToString(); }
            }
        }
    }
    public void ClearCalcDisplay()
    {
        CalcDisplay.text = "";
    }

    public void Backspace()
    {
        if (CalcDisplay.text.Length != 0 && CalcDisplay.text != "Многовато" && CalcDisplay.text != "Маловато")
        {
            CalcDisplay.text = CalcDisplay.text.Remove(CalcDisplay.text.Length - 1);
        }
    }

    public void ShowOperationResult(double toOutputView)
    {
        string operationResult = toOutputView.ToString();
        int positonComma = operationResult.IndexOf(',');

        if ((toOutputView < 0.0000001d) && (toOutputView > -0.0000001d) && (toOutputView != 0d))
        {
            CalcDisplay.text = "Маловато";
        }
        else if ((toOutputView > 999999999d) || (toOutputView < -999999999d))
        {
            CalcDisplay.text = "Многовато";
        }
        else
        {
            
            if (positonComma >= 0 && positonComma <= 9 && operationResult.Length > 9)
            {
                operationResult = operationResult.Remove(9).TrimEnd(',');
            }

            CalcDisplay.text = operationResult;

            
        }
    }
    public void ChangeSign()
    {
        if (CalcDisplay.text[0] != '-') 
        {
            CalcDisplay.text = CalcDisplay.text.Insert(0, "-"); 
        }
        else
        { 
            CalcDisplay.text = CalcDisplay.text.Remove(0, 1); 
        }
    }
}
