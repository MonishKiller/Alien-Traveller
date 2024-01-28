using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{ 
    [SerializeField] private Button BTN_Restart;
    [SerializeField] private Button BTN_Home;

    private void Start()
    {
        this.BTN_Home?.onClick.AddListener(OnClick_Home);
        this.BTN_Restart?.onClick.AddListener(OnClick_Restart);
    }
    public void ShowPanel()
    {
        Time.timeScale = 0;
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
    private void OnClick_Restart()
    {
        Time.timeScale = 1;
        MissionCompletion.Instance.LoadCurrentScene();

    }
}
