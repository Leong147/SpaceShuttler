using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject CreditUI;
    public GameObject OptionUI;

    void Start()
    {
        CreditUI.SetActive(false);
        OptionUI.SetActive(false);
    }

    public void PlayStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenCredit()
    {
        CreditUI.SetActive(true);
    }

    public void OpenOption()
    {
        OptionUI.SetActive(true);
    }

    public void CloseCredit()
    {
        CreditUI.SetActive(false);
    }

    public void CloseOption()
    {
        OptionUI.SetActive(false);
    }
}
