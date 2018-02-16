using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";
	public SceneFader sceneFader;
   
    public void Retry ()
	{
        WaveSpawner.EnemiesAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
      
    }
        
	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
	}

}
