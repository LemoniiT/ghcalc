using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{

    public Camera GreatCamera;
    public float pressRange;
    Transform buttonHit;
    public Leds mainLeds;
    CalcLogic ComputeMachine;

    private void Start()
    {
        ComputeMachine = GreatCamera.GetComponent<CalcLogic>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray rayToButtons = GreatCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayToButtons, out hit))
            {
                buttonHit = hit.transform;
                buttonHit.position = new Vector3(buttonHit.position.x, buttonHit.position.y, buttonHit.position.z + pressRange);
                if (buttonHit.gameObject.tag == "NumberButtons") 
                {
                    mainLeds.UpdateCalcDisplay(buttonHit.gameObject.name[7]);
                }
                if (buttonHit.gameObject.tag == "Operation") { ComputeMachine.PartOfOperation(buttonHit.gameObject.name[7]); }
                if (buttonHit.gameObject.name[7] == '=') { ComputeMachine.ComputeResult(); }
                if (buttonHit.gameObject.name == "Button CE") { ComputeMachine.ClearCalcMemory(); }
                if (buttonHit.gameObject.name == "Button C") { mainLeds.ClearCalcDisplay(); }
                if (buttonHit.gameObject.name == "Button sqr") { ComputeMachine.ComputeSqr(); }
                if (buttonHit.gameObject.name == "Button +-") { mainLeds.ChangeSign(); }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (buttonHit != null)
            {
                buttonHit.position = new Vector3(buttonHit.position.x, buttonHit.position.y, buttonHit.position.z - pressRange);
                buttonHit = null;
            }
        }

        if (Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.Keypad1)) { mainLeds.UpdateCalcDisplay('1'); }
        if (Input.GetKeyDown("2") || Input.GetKeyDown(KeyCode.Keypad2)) { mainLeds.UpdateCalcDisplay('2'); }
        if (Input.GetKeyDown("3") || Input.GetKeyDown(KeyCode.Keypad3)) { mainLeds.UpdateCalcDisplay('3'); }
        if (Input.GetKeyDown("4") || Input.GetKeyDown(KeyCode.Keypad4)) { mainLeds.UpdateCalcDisplay('4'); }
        if (Input.GetKeyDown("5") || Input.GetKeyDown(KeyCode.Keypad5)) { mainLeds.UpdateCalcDisplay('5'); }
        if (Input.GetKeyDown("6") || Input.GetKeyDown(KeyCode.Keypad6)) { mainLeds.UpdateCalcDisplay('6'); }
        if (Input.GetKeyDown("7") || Input.GetKeyDown(KeyCode.Keypad7)) { mainLeds.UpdateCalcDisplay('7'); }
        if (Input.GetKeyDown("8") || Input.GetKeyDown(KeyCode.Keypad8)) { mainLeds.UpdateCalcDisplay('8'); }
        if (Input.GetKeyDown("9") || Input.GetKeyDown(KeyCode.Keypad9)) { mainLeds.UpdateCalcDisplay('9'); }
        if (Input.GetKeyDown("0") || Input.GetKeyDown(KeyCode.Keypad0)) { mainLeds.UpdateCalcDisplay('0'); }
        if (Input.GetKeyDown(",") || Input.GetKeyDown(KeyCode.KeypadPeriod)) { mainLeds.UpdateCalcDisplay(','); }
        if (Input.GetKeyDown(KeyCode.Backspace))  { mainLeds.Backspace(); }

        if (Input.GetKeyDown(KeyCode.Delete)) { ComputeMachine.ClearCalcMemory(); }

        if ((Input.GetKeyDown(KeyCode.KeypadPlus)) || (Input.GetKeyDown(KeyCode.Plus))) 
        { 
            ComputeMachine.PartOfOperation('+');  
        }
        if ((Input.GetKeyDown(KeyCode.KeypadMinus)) || (Input.GetKeyDown(KeyCode.Minus)))
        {
            ComputeMachine.PartOfOperation('-');
        }
        if ((Input.GetKeyDown(KeyCode.KeypadMultiply)) || (Input.GetKeyDown(KeyCode.Asterisk)))
        {
            ComputeMachine.PartOfOperation('*');
        }
        if ((Input.GetKeyDown(KeyCode.KeypadDivide)) || (Input.GetKeyDown(KeyCode.Slash)))
        {
            ComputeMachine.PartOfOperation('/');
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) 
        {
            ComputeMachine.ComputeResult();
        }


    }
}
