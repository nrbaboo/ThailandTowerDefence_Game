using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadTextFile : MonoBehaviour {

    [Header("Story")]
    public string str;
    public Text storyTextUI;
    public static string story = "eieinana";

    static public void read(string data)
    {
        story = data;
    }

    void Update()
    {
        str = story;
        storyTextUI.text = story;
    }
}

