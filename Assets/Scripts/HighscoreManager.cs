using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour {

    private static int highscore;

	void Awake () {
        InitHighscore();
	}

    // Lade Highscore von der Platte, wenn nicht verfügbar, dann erstelle Highscore
    void InitHighscore ()
    {
        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            highscore = PlayerPrefs.GetInt("HIGHSCORE");
        }
        else
        {
            highscore = 0;
            PlayerPrefs.SetInt("HIGHSCORE", 0);
            PlayerPrefs.Save();
        }
    }

    public static int GetHighscore ()
    {
        return highscore;
    }

    // If newScore greater than highscore - set new score
    public static void SetHighscore (int newScore)
    {
        if (newScore <= highscore)
            return;

        highscore = newScore;
        PlayerPrefs.SetInt("HIGHSCORE", newScore);
        PlayerPrefs.Save();
    }
}
