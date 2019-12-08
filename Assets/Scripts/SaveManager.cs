using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public InputField nameInput;
    public Dropdown ageDropdown;
    public Dropdown colorDropdown;

    private string SaveFilePath;
    private void Awake() 
    {
        SaveFilePath = Application.persistentDataPath + "/savedPlayer.save";
        ageDropdown.ClearOptions();

        List<string> ageList = new List<string>();
        ageList.Add("---年齢---");
        for (int i = 0; i <= 100; i++) 
            ageList.Add(i.ToString());
        ageDropdown.AddOptions(ageList);    
    }

    public void OnSaveNewPlayer()
    {
        // セーブデータ作成
        SavePlayerData player = CreateSavePlayerData();
        // バイナリ形式でシリアル化
        BinaryFormatter bf = new BinaryFormatter();
        // 指定したパスにファイルを作成
        FileStream file = File.Create(SaveFilePath);
        // Closeが確実に呼ばれるように例外処理を用いる
        try
        {
            // 指定したオブジェクトを上で作成したストリームにシリアル化する
            bf.Serialize(file, player);
        }
        finally
        {
            // ファイル操作には明示的な破棄が必要です。Closeを忘れないように。
            if (file != null) 
                file.Close();
        }
    }

    // 入力された情報をもとにセーブデータを作成
    private SavePlayerData CreateSavePlayerData() 
    {
        SavePlayerData player = new SavePlayerData();
        player.name = nameInput.text;
        player.age = int.Parse(ageDropdown.options[ageDropdown.value].text);
        player.color = colorDropdown.options[colorDropdown.value].text;
        return player;
    }
}