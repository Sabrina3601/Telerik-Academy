﻿using System;


public class ExtractSentences
{
    public static void Main(string[] args)
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string key = " in ";

        string[] newText = text.Split('.');

        for (int i = 0; i < newText.Length; i++)
        {
            if (newText[i].IndexOf(key).ToString() == key)
            {
                
            }
        }
    }
}