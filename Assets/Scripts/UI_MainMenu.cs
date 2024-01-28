using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private Button BTN_Play;
    [SerializeField] private Button BTN_Options;
    [SerializeField] private Button BTN_Quit;

    [SerializeField] private UI_Tutorial _UI_Tutorial;

    private void OnEnable()
    {
        DeactivatePanels();
    }
    private void Start()
    {
        if (BTN_Play != null) this.BTN_Play.onClick.AddListener(Onclick_BTN_Play);
        if (BTN_Options != null) this.BTN_Options.onClick.AddListener(OnClick_BTN_Tutorial);
        if (BTN_Quit != null) this.BTN_Quit.onClick.AddListener(OnClick_BTN_Quit);
    }
    private void Onclick_BTN_Play()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    private void OnClick_BTN_Tutorial()
    {
        _UI_Tutorial.gameObject.SetActive(true);


    }
    private void OnClick_BTN_Quit()
    {
        Application.Quit();

    }

    private void DeactivatePanels()
    {
        _UI_Tutorial.gameObject.SetActive(false);

    }
}
