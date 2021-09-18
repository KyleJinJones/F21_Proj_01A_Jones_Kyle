using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    //This is the class that will be constructed from the user input
    //and subsequently turned into json and outputted
    public string charname;

    //Ability values
    public float str;
    public float dex;
    public float con;
    public float intel;
    public float wis;
    public float chr;

    public string race;
    public string clss;
    public string alignment;
    public int xpcurrent;
    public int xpmax;
    public int currenthp;
    public int maxhp;
    public int armor;
    public int walkingspd;
    public int runningspd;
    public int jumpheight;
    public List<string> itemlist;


    //Creates a new character, assigning all the values
    public Character(string newname, float newstr, float newdex, float newcon, float newintel, float newwis, float newchr,
        string newrace, string newclass, string newalignment, int newcurxp, int newmaxxp, int newcurrenthp, int newmaxhp, 
        int newarmor, int newwalkspd, int newrunspd, int newjmpht, List<string> newitemlist=null )
    {
        charname = newname;
        str = newstr;
        dex = newdex;
        con = newcon;
        intel = newintel;
        wis = newwis;
        chr = newchr;
        race = newrace;
        clss = newclass;
        alignment = newalignment;
        xpcurrent = newcurxp;
        xpmax = newmaxxp;
        currenthp = newcurrenthp;
        maxhp = newmaxhp;
        armor = newarmor;
        walkingspd = newwalkspd;
        runningspd = newrunspd;
        jumpheight = newjmpht;
        //Currently does nothing for itemlist
        itemlist = new List<string>();
        
        

    }

}
