using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string playerName;
    private int playerAge;
    private Color playerColor;
    public void Init(string _name, int _age, string _color)  
    {
        playerName = _name;
        playerAge = _age;
        switch(_color)
        {
            case "Red":
                playerColor = Color.red;
                break;
            case "Green":
                playerColor = Color.green;
                break;
            case "Blue":
                playerColor = Color.blue;
                break;
        }
        GetComponentInChildren<TextMesh>().text = $"{playerName}: {playerAge}歳だよ";
        GetComponent<MeshRenderer>().material.color = playerColor;
    }
}
