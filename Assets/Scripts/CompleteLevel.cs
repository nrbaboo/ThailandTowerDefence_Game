using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public string nextLevel = "Level02";
	public int levelToUnlock = 2;
    public static int levelToUnlockS;
    public SceneFader sceneFader;
    void Start()
    {
       // levelToUnlockS = levelToUnlock;
    }
    private void Update()
    {
        levelToUnlockS = levelToUnlock;
    }
    public void Continue ()
	{
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo(nextLevel);
	}

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
	}

}
