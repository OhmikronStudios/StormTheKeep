using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject levelPanel;

    public Image mapImage;
    public string levelName;

    AudioCue ac;
    



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SettingsManager>().LoadAudioLevels();
        ac = GetComponent<AudioCue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnObjectOn(GameObject obj)
    {
        obj.SetActive(true);
        Debug.Log("clicked");
    }
    
    public void TurnObjectOff(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Quit()
    {
        FindObjectOfType<GameManager>().OnQuitButton();
    }

    public void OpenURL()
    {
            Application.OpenURL("http://ohmikronstudios.com/");
            Debug.Log("is this working?");
    }
    
    public void playCue(AudioCueSO cue)
    {
        ac.PlayAudioCue(cue);
    }

}
