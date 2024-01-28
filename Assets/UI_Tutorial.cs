using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tutorial : MonoBehaviour
{
    [SerializeField] private Button BTN_GoHome;

    private void Start()
    {
        if (this.BTN_GoHome != null) this.BTN_GoHome.onClick.AddListener(onClick_BTN_Home);
    }
    private void onClick_BTN_Home()
    {
        Debug.Log("HOme button is pressed");
        this.gameObject.SetActive(false);

    }

}
