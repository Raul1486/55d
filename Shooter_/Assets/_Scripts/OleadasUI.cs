using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OleadasUI : MonoBehaviour
{
    private TextMeshProUGUI _text;


    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        OleadasManager.SharedInstance.onWaveChanged.AddListener(RefreshText);
        RefreshText();
    }


    private void RefreshText()
    {
        _text.text = "OLEADA: " + 
                     (OleadasManager.SharedInstance.MaxOleadas-OleadasManager.SharedInstance.WavesCount) + 
                     "/" +OleadasManager.SharedInstance.MaxOleadas;
    }
}
