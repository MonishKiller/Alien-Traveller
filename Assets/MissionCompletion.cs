using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MissionCompletion : SingletonManger<MissionCompletion>
{
    [SerializeField] private SPSFManager sPSFManager;
    [SerializeField] private TextMeshProUGUI plantCollectedTMP;
    private int keySCollected = 0;

    public void updateKeysCollected()
    {
        keySCollected++;
        plantCollectedTMP.text = keySCollected + "/3";
        if (keySCollected >= 3)
        {
            sPSFManager.finishPanel.ShowPanel();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
