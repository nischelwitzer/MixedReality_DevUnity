using System;
using TMPro;
using UnityEngine;

public class InfoLineWriter : MonoBehaviour
{
    private TextMeshProUGUI infoLine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoLine = this.GetComponent<TextMeshProUGUI>();
        infoLine.text = "Start: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm ") + Application.productName + " V" + Application.version + " [FHJ/IMA/DMT/NIS]";
    }

}
