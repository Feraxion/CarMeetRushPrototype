using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OpenSettings()
    {
        settingsUI.SetActive(true);
        GameManager.inst.StartScreen.SetActive(false);
        GameManager.inst.playerState = GameManager.PlayerState.Shopping;
    }

    public void CloseSettings()
    {
        settingsUI.SetActive(false);
        GameManager.inst.StartScreen.SetActive(true);
        GameManager.inst.playerState = GameManager.PlayerState.Prepare;

    }
    
}
