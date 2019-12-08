using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;

    private string SaveFilePath;

    private void Start() 
    {
        SaveFilePath = Application.persistentDataPath + "/savedPlayer.save";

        LoadPlayer();
    }
 
    private void LoadPlayer() 
    {
        if (File.Exists(SaveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SaveFilePath, FileMode.Open);
            SavePlayer player = (SavePlayer)bf.Deserialize(file);
            file.Close();

            var playerObject = Instantiate(playerPrefab) as GameObject;
            playerObject.GetComponent<PlayerController>().Init(player.name, player.age, player.color);
        }
        else 
        {
            Debug.Log("no load file");
        }
    }
}