using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoadScene = "MainLevel";
    public string extraItemScene = "MainLevel";
    public string galleryScene = "Gallery";
    public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoadScene);
	}

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

    public void ExtraItem()
    {
        sceneFader.FadeTo(extraItemScene);
    }
    public void Gallery()
    {
        sceneFader.FadeTo(galleryScene);
    }
}
