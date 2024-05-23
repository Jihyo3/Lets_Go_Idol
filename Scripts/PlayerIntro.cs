using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

// 삭제해도 되는 코드
public class PlayerIntro : MonoBehaviour
{
    public Button button;
    private bool insu = false;
    private bool sujeong = false;
    private bool jihyo = false;
    private bool ygs = false;
    private bool puk = false;
    private string selectplayer;
    private GameObject selectplayerimage; 
    public Sprite[] images;
    public GameObject popupMenu;
    public Image DefaultPlayerImg;
    private bool isPopupMenu = false;
    
    //캐릭터 이미지 가져오기
    public GameObject[] players;

    public void Clickbtn()
    {
        if (insu)
        {
            selectplayer = players[0].name;
        }
        else if (sujeong)
        {
            selectplayer = players[1].name;
        }
        else if (jihyo)
        {
            selectplayer = players[2].name;
        }
        else if (puk)
        {
            selectplayer = players[3].name;
        }
        else
        {
            selectplayer = players[4].name;
        }
    }

    public void Join()
    {

        if (selectplayer != null)
        {
            PlayerPrefs.SetString("selectPlayer", selectplayer);
            PlayerPrefs.SetFloat("PlayerPositionX", 0);
            PlayerPrefs.SetFloat("PlayerPositionY", 0);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            SceneManager.LoadScene("MainScene2");
        }
        else
        {
            Debug.Log("아이돌이 선택되지 않았습니다!");
        }
    }
    public void selectedinsu()
    {
        insu = true;
        sujeong = false;
        jihyo = false;
        ygs = false;
        puk = false;

        DefaultPlayerImg.sprite = images[0];
        Clickbtn();
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedsujeong()
    {
        insu = false;
        sujeong = true;
        jihyo = false;
        ygs = false;
        puk = false;

        DefaultPlayerImg.sprite = images[1];
        Clickbtn();
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedjihyo()
    {
        insu = false;
        sujeong = false;
        jihyo = true;
        ygs = false;
        puk = false;

        DefaultPlayerImg.sprite = images[2];
        Clickbtn();
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedpuk()
    {
        insu = false;
        sujeong = false;
        jihyo = false;
        ygs = false;
        puk = true;

        DefaultPlayerImg.sprite = images[3];
        Clickbtn();
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedygs()
    {
        insu = false;
        sujeong = false;
        jihyo = false;
        ygs = true;
        puk = false;

        DefaultPlayerImg.sprite = images[4];
        Clickbtn();
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void PopupMenuClick()
    {
        popupMenu.SetActive(true);
        DefaultPlayerImg.gameObject.SetActive(true);
        if(!isPopupMenu)
        {
            isPopupMenu = true;
            popupMenu.SetActive(true);
            DefaultPlayerImg.gameObject.SetActive(true);
        }
        else
        {
            isPopupMenu = false;
            popupMenu.SetActive(false);
        }
    }
}