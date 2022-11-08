using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject PlayerNameInput;

    public void Go()
    {
        SaveName();
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        SaveName();
        Application.Quit();
    }

    private void SaveName()
    {
        string enteredName = PlayerNameInput.GetComponent<TMP_InputField>().text;
        DataManager.Instance.PlayerName = enteredName;
    }
}
