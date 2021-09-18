using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaptureInput : MonoBehaviour
{
    //When Progressing from the input page to the ability roll page, This script checks all of the inputs
    //If they are valid, it will allow user to proceed to the next step otherwise it will pop up an error msg
    public TMP_InputField charname;
    public TMP_Dropdown race;
    public TMP_Dropdown charclass;
    public TMP_Dropdown alignment;
    public TMP_InputField curexp;
    public TMP_InputField maxexp;
    public TMP_InputField armor;
    public TMP_InputField maxhp;
    public TMP_InputField currenthp;
    public Slider walkspd;
    public Slider runspd;
    public Slider jumpht;
    public TextMeshProUGUI errmsgtext;
    public GameObject errmsgobj;
    //All fields are assigned in inspector since the project is relatively small

    public GameObject inputpage;
    public GameObject abilitiespage;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Checks the inputs that can be entered incorrectly,
    //If they are wrong submits an error message
    //Otherwise procceds to nextpage
    public void CheckInput()
    {
        if (!CheckField(charname))
        {
            DisplayErrorMsg("Character Name Empty.");
        }
        else if (!CheckInt(maxhp))
        {
            DisplayErrorMsg("Max Hp must be a whole number");
        }
        //Does not actually check if currenthp/xp is greater than max
        //Allows user to make that mistake
        else if (!CheckInt(currenthp))
        {
            DisplayErrorMsg("Current Hp must be a whole number.");
        }
        else if (!CheckIntRange(armor,1,100))
        {
            DisplayErrorMsg("Armor not in the range 1-100.");
        }
        else if (!CheckInt(curexp))
        {
            DisplayErrorMsg("Current Exp must be a number");
        }
        else if (!CheckInt(maxexp))
        {
            DisplayErrorMsg("Max Exp must be a number");
        }
        else
        {
            inputpage.SetActive(false);
            abilitiespage.SetActive(true);
        }
    }

    private void CollectInput()
    {

    }

    //Checks if the given TMP_InputField is empty
    private bool CheckField(TMP_InputField testedfield)
    {
        if (testedfield.text != "")
        {
            return true;
        }
        return false;
    }

    //Checks if the field is empty and then test if the string is only numbers
    private bool CheckInt(TMP_InputField testedfield)
    {
        if (!CheckField(testedfield))
        {
            return false;
        }
        else
        {
            foreach(char c in testedfield.text)
            {
                if (!"0987654321".Contains(c.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }

    //Checks that the field is not empty and only numbers then converts it to an int
    //Then compares it to the given min and max range
    private bool CheckIntRange(TMP_InputField testedfield,int minrange, int maxrange)
    {
        if (!CheckInt(testedfield))
        {
            return false;
        }
        else
        {
            int temp = StringToInt(testedfield.text);
            return temp >= minrange && temp <= maxrange;
        }
    }

    //Converts a given str to int does not do its own check
    //Assumes str has already been checked
    private int StringToInt(string str)
    {
        int place = str.Length-1;
        int output = 0;
        foreach(char c in str)
        {
            int temp = 0;
            if (c == '1')
            {
                temp = 1;
            }
            else if (c == '2')
            {
                temp = 2;
            }
            else if (c == '3')
            {
                temp = 3;
            }
            else if (c == '4')
            {
                temp = 4;
            }
            else if (c == '5')
            {
                temp = 5;
            }
            else if (c == '6')
            {
                temp = 6;
            }
            else if (c == '7')
            {
                temp = 7;
            }
            else if (c == '8')
            {
                temp = 8;
            }
            else if (c == '9')
            {
                temp = 9;
            }

            output += temp * (int)Mathf.Pow(10, place);
            place--;
            
        }
        
        return output;
    }

    //Displays an Error Message to the user with the given str
    private void DisplayErrorMsg(string errormsg)
    {
        errmsgobj.SetActive(true);
        errmsgtext.text = errormsg;
    }

    //A Series of Getters to get the values for Character Creation
    public string GetCharName()
    {
        return charname.text;
    }

    public string GetRace()
    {
        return race.captionText.text;
    }

    public string GetClass()
    {
        return charclass.captionText.text;
    }

    public string GetAlignment()
    {
        return alignment.captionText.text;
    }

    public int GetCurrentExp()
    {
        return StringToInt(curexp.text);
    }

    public int GetMaxExp()
    {
        return StringToInt(maxexp.text);
    }

    public int GetCurrentHp()
    {
        return StringToInt(currenthp.text);
    }

    public int GetMaxHp()
    {
        return StringToInt(maxhp.text);
    }

    public int GetArmor()
    {
        return StringToInt(armor.text);
    }

    public int GetWalkSpeed()
    {
        return (int)walkspd.value;
    }

    public int GetRunSpeed()
    {
        return (int)runspd.value;
    }
    public int GetJumpHeight()
    {
        return (int)jumpht.value;
    }
}
