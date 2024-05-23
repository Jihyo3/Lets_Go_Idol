using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance; 
    private TMP_Text score;
    public float time = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        score = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        score.text = time.ToString("N2");
    }
}
