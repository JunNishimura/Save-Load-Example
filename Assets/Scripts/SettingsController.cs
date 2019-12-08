using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
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
        SavePlayerData player = CreateGamePlayer();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SaveFilePath);
        bf.Serialize(file, player);
        file.Close();
    } 

    private SavePlayerData CreateGamePlayer() 
    {
        SavePlayerData player = new SavePlayerData();
        player.name = nameInput.text;
        player.age = int.Parse(ageDropdown.options[ageDropdown.value].text);
        player.color = colorDropdown.options[colorDropdown.value].text;
        return player;
    }
}
