using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour
{
    private AbilityRoll[] rolls;
    private CaptureInput ci;
    public TMP_InputField jsonoutput;
    public GameObject outputholder;
    private string myjson;
    private TextEditor textcopier;
    public GameObject abilitypage;
    void Start()
    {
        abilitypage.SetActive(true);
        textcopier = new TextEditor();
        //Get captureinput obj, will be on managers gameobj with this script
        //Find all rolls(order doesn't matter)
        ci = GetComponent<CaptureInput>();
        rolls = FindObjectsOfType<AbilityRoll>();
        abilitypage.SetActive(false);
    }

    //Checks the status of each roll and abilitytype
    //If its all good we can have everything and can generate output
    public void CheckRolls()
    {
        float str = 0.0f;
        float dex = 0.0f;
        float con = 0.0f;
        float intel = 0.0f;
        float wis = 0.0f;
        float chr = 0.0f;
        foreach (AbilityRoll ab in rolls)
        {
            
            if (!ab.GetRolled())
            {
                return;
            }
            if (ab.GetAbilityType() == "Str")
            {
                //checks for duplicates if str is already set, there is one
                if (str != 0.0f)
                {
                    return;
                }
                str = ab.GetAbilityValue();
            }
            if (ab.GetAbilityType() == "Dex")
            {
                //checks for duplicates if str is already set, there is one
                if (dex != 0.0f)
                {
                    return;
                }
                dex = ab.GetAbilityValue();
            }
            if (ab.GetAbilityType() == "Con")
            {
                //checks for duplicates if str is already set, there is one
                if (con != 0.0f)
                {
                    return;
                }
                con = ab.GetAbilityValue();
            }
            if (ab.GetAbilityType() == "Int")
            {
                //checks for duplicates if str is already set, there is one
                if (intel != 0.0f)
                {
                    return;
                }
                intel = ab.GetAbilityValue();
            }
            if (ab.GetAbilityType() == "Wis")
            {
                //checks for duplicates if str is already set, there is one
                if (wis != 0.0f)
                {
                    return;
                }
                wis = ab.GetAbilityValue();
            }
            if (ab.GetAbilityType() == "Chr")
            {
                //checks for duplicates if str is already set, there is one
                if (chr != 0.0f)
                {
                    return;
                }
                chr = ab.GetAbilityValue();
            }
        }
        
        ConstructOutputJson(str,dex,con,intel,wis,chr);
    }

    //Constructs a Character class, and converts it to Json
    //Then ouputs it to the ui
    public void ConstructOutputJson(float str, float dex, float con, float intel, float wis, float chr)
    {
        
        Character mychar = new Character(ci.GetCharName(), str, dex, con, intel, wis, chr, ci.GetRace(), ci.GetClass(), ci.GetAlignment(), ci.GetCurrentExp(),
            ci.GetMaxExp(), ci.GetCurrentHp(), ci.GetMaxHp(), ci.GetArmor(), ci.GetWalkSpeed(), ci.GetRunSpeed(), ci.GetJumpHeight());

        myjson = JsonUtility.ToJson(mychar);
        outputholder.SetActive(true);
        jsonoutput.text = myjson;
        
        
    }

    //Copies the Json to clipboard
    //Used in conjunction with a button
    public void CopyJsontoClipboard()
    {
        textcopier.text = myjson;
        textcopier.SelectAll();
        textcopier.Copy();
    }
}
