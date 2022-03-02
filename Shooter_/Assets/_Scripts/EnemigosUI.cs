using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemigosUI : MonoBehaviour
{
    private TextMeshProUGUI _text;


    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(RefreshText);
        RefreshText();
    }


    private void RefreshText()
    {
        _text.text = "ENEMIGOS: " + EnemyManager.SharedInstance.EnemyCount;
    }
}
