using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DMTEventHelpers : MonoBehaviour
{

    private bool myToggle = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("##### DMTEventHelpers: Start");
    }

    public void HelperToggle()
    {
        myToggle = !myToggle;
        this.gameObject.SetActive(myToggle);
    }


    public void HelperSceneManager(string whichScene)
    {
        if (whichScene != "")
        {
            Debug.LogWarning("Trigger event fired: change Scene > " + whichScene);
            SceneManager.LoadScene(whichScene);
        }
        else
            Debug.LogError("DMTTriggerScene: no Scene Name specified!");
    }
    
    // Update is called once per frame
    public void HelperSize(float newSize)
    {
        Vector3 newScaling = this.transform.localScale * newSize;
        this.transform.localScale = newScaling;
    }
}
