using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button BTN_Resume;
    [SerializeField] private Button BTN_Settings;
    [SerializeField] private Button BTN_Home;

    private void Start()
    {
        this.BTN_Home?.onClick.AddListener(OnClick_Home);
        this.BTN_Resume?.onClick.AddListener(OnClick_Resume);
        this.BTN_Settings?.onClick.AddListener(OnClick_Settings);
    }
    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }
    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
    private void OnClick_Home()
    {
        Time.timeScale = 1;
        MissionCompletion.Instance.LoadMainMenu();

    }
    private void OnClick_Resume()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);

    }
    private void OnClick_Settings()
    {
        Time.timeScale = 1;
        MissionCompletion.Instance.LoadCurrentScene();

    }
}
