using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{


    [SerializeField] private Button BTN_Home;

    private void Start()
    {
        this.BTN_Home?.onClick.AddListener(OnClick_Home);

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
}
