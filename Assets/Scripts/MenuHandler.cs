using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
        DataManager.Instance.Save();
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

    private void SaveName()
    {
        string enteredName = PlayerNameInput.GetComponent<TMP_InputField>().text;
        DataManager.Instance.PlayerName = enteredName;
    }
}
