using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject CreditUI;
    public GameObject CreditUI2;
    public GameObject OptionUI;

    void Start()
    {
        CreditUI.SetActive(false);
        OptionUI.SetActive(false);
        CreditUI2.SetActive(false);
    }

    public void PlayStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenCredit()
    {
        CreditUI.SetActive(true);
    }

    public void NextCreditPage()
    {
        CreditUI2.SetActive(true);
        CreditUI.SetActive(false);
    }

    public void PreCreditPage()
    {
        CreditUI.SetActive(true);
        CreditUI2.SetActive(false);
    }

    public void OpenOption()
    {
        OptionUI.SetActive(true);
    }

    public void CloseCredit()
    {
        CreditUI.SetActive(false);
    }

    public void CloseCredit2()
    {
        CreditUI2.SetActive(false);
    }

    public void CloseOption()
    {
        OptionUI.SetActive(false);
    }
}
