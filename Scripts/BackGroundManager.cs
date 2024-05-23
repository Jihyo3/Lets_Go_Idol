using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    public Sprite[] bgImg;
    public Toggle backGroundImg1;
    public Toggle backGroundImg2;

    private Sprite backSprite;
    public Image backgroundImg;

    void Start()
    {
        SelectBackgroundImg(0);

        backGroundImg1.onValueChanged.AddListener(delegate { ToggleClick(); });
        backGroundImg2.onValueChanged.AddListener(delegate { ToggleClick(); });
    }

    public void SelectBackgroundImg(int index)
    {
        if (index >= 0 && index < bgImg.Length)
        {
            backSprite = bgImg[index];
            backgroundImg.sprite = backSprite; 
        }
    }

    public void ToggleClick()
    {
        if (backGroundImg1.isOn)
        {
            SelectBackgroundImg(0);
        }
        else if (backGroundImg2.isOn)
        {
            SelectBackgroundImg(1);
        }
    }
}
