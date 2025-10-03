using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInputHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    //[SerializeField] public GameManager gameManager;

    public void SubmitName()
    {
        string playerName = nameInputField.text;
        GameManager.Instance.SetPlayerName(playerName);
    }
}