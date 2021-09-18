using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityRoll : MonoBehaviour
{
    //Rolls Ability Dice, rolls 4d8s and takes the highest 3 and sums them as an ability score
    //Only allowed to roll once
    bool hasrolled = false;
    float abilityvalue = 0.0f;
    public TMP_Dropdown abilitytype;
    public TextMeshProUGUI roll1;
    public TextMeshProUGUI roll2;
    public TextMeshProUGUI roll3;
    public TextMeshProUGUI roll4;
    public TextMeshProUGUI rolltotal;

    public void Roll()
    {
        if (!hasrolled)
        {
            //Rolls 4 times, and then sorts the list least to greatest
            List<int> rolls = new List<int>();
            rolls.Add(Random.Range(1, 9));
            rolls.Add(Random.Range(1, 9));
            rolls.Add(Random.Range(1, 9));
            rolls.Add(Random.Range(1, 9));
            rolls.Sort();

            //Updates visuals based on roll results
            roll1.text = rolls[0].ToString();
            roll2.text = rolls[1].ToString();
            roll3.text = rolls[2].ToString();
            roll4.text = rolls[3].ToString();
            rolltotal.text = (rolls[1] + rolls[2] + rolls[3]).ToString();
            hasrolled = true;
            abilityvalue = rolls[1] + rolls[2] + rolls[3];
        }

    }

    public float GetAbilityValue()
    {
        return abilityvalue;
    }

    public string GetAbilityType()
    {
        return abilitytype.captionText.text;
    }

    public bool GetRolled()
    {
        return hasrolled;
    }
  
}
