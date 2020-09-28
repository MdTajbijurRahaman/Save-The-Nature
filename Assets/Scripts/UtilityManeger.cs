using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityManeger  {


    public static int levelTotal = 10;
    public static int currentLevel = 0;
    public static int unlockLevel = 1;
    public static int highestStep = 0;
    public static int currentStep = 0;

    public static bool isSound = true;
    public static bool isEnglish = true;


    public static void InitData() {

        if (PlayerPrefs.HasKey("highest_score"))
           highestStep= PlayerPrefs.GetInt("highest_score");
        else 
            PlayerPrefs.SetInt("highest_score", highestStep);

        if (PlayerPrefs.HasKey("unlock_level"))
            unlockLevel = PlayerPrefs.GetInt("unlock_level");
        else
            PlayerPrefs.SetInt("unlock_level", unlockLevel);

        if (PlayerPrefs.HasKey("current_level"))
            currentLevel = PlayerPrefs.GetInt("current_level");
        else
            PlayerPrefs.SetInt("current_level", currentLevel);

        if (PlayerPrefs.HasKey("sound"))
        {

            if (PlayerPrefs.GetInt("sound") == 0)
                isSound = false;
            else
                isSound = true;
        }
        else
        {
            if (isSound) 
                PlayerPrefs.SetInt("sound", 1);
            else
                PlayerPrefs.SetInt("sound", 0);
        }

        if (PlayerPrefs.HasKey("languge"))
        {
            if (PlayerPrefs.GetInt("languge") == 0)
                isEnglish = false;
            else
                isEnglish = true;
                
            
        }
        else
        {
            if(isEnglish)
              PlayerPrefs.SetInt("languge", 1);
            else
                PlayerPrefs.SetInt("languge", 0);
        }

    }

    public static void SaveHighestScore() {
        PlayerPrefs.SetInt("highest_score", highestStep);
    }

    public static void SaveUnlockLevel()
    {
        PlayerPrefs.SetInt("unlock_level", unlockLevel);
    }

    public static void SaveCurrentLevel()
    {
        PlayerPrefs.SetInt("current_level", currentLevel);
    }

    public static void SaveSound() {
        if (isSound)
            PlayerPrefs.SetInt("sound", 1);
        else
            PlayerPrefs.SetInt("sound", 0);
    }

    public static void SaveLanguage() {
        if (isEnglish)
            PlayerPrefs.SetInt("languge", 1);
        else
            PlayerPrefs.SetInt("languge", 0);
    }
}
