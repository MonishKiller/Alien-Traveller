using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPSFManager : MonoBehaviour
{
    [SerializeField] private PausePanel pausePanel;
    [SerializeField] private Button BTN_Pause;
    [SerializeField] public FinishPanel finishPanel;
    private void Start()
    {
        this.BTN_Pause?.onClick.AddListener(OnClickPauseBTN);
    }
    private void OnClickPauseBTN()
    {
        Time.timeScale = 0;
        this.pausePanel.ShowPanel();

    }
}
