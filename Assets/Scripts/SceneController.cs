using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnSceneChangeToNewGame() 
    {
        SceneManager.LoadScene("NewGame");
    }

    public void OnSceneChangeToMain() 
    {
        if (!File.Exists(Application.persistentDataPath + "/savedPlayer.save"))
        {
            Debug.Log("there is no saved file");
            return;
        }

        SceneManager.LoadScene("Main");
    }
}