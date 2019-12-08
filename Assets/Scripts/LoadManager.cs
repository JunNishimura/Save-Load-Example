using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadManager : MonoBehaviour
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
            // バイナリ形式でデシリアライズ
            BinaryFormatter bf = new BinaryFormatter();
            // 指定したパスのファイルストリームを開く
            FileStream file = File.Open(SaveFilePath, FileMode.Open);
            try 
            {
                // 指定したファイルストリームをオブジェクトにデシリアライズ。
                SavePlayerData player = (SavePlayerData)bf.Deserialize(file);
                // 読み込んだデータを反映。
                var playerObject = Instantiate(playerPrefab) as GameObject;
                playerObject.GetComponent<PlayerController>().Init(player.name, player.age, player.color);
            }
            finally 
            {
                // ファイル操作には明示的な破棄が必要です。Closeを忘れないように。
                if (file != null) 
                    file.Close();
            }
        }
        else
        {
            Debug.Log("no load file");
        }
    }
}