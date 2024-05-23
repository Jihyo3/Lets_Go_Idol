using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class User
{
    // Json�� ������ User ����
    public string id;
    public string password;
    public string selectedCharacter;
}

[System.Serializable]
// �����Ҷ� ����Ʈ�� �����Ϸ���
public class UserList
{
    public List<User> users;
}

public class PlayerJoinManager : MonoBehaviour
{
    public TMP_InputField idField;              // Id �ʵ�
    public TMP_InputField passWordField;        // Password �ʵ�
    public Text idWarningTxt;                   // Id ��ȿ�� �˻� ���н� ������ �����
    public Text passWordWarningTxt;             // Password ��ȿ�� �˻� ���н� ������ �����
    public Button joinCheckBtn;                 // Join ��ư

    private string userInfoFilePath;            // Json ���
    public event Action UserAddedSuccessfully; 

    private bool insu = false;
    private bool sujeong = false;
    private bool jihyo = false;
    private bool ygs = false;
    private bool puk = false;
    private string selectplayer;
    private GameObject selectplayerimage;
    public Sprite[] images;
    public Image DefaultPlayerImg;
    public GameObject[] players;
    public Text playerName;

    void Start()
    { 

        userInfoFilePath = Path.Combine(Application.persistentDataPath, "PlayerInfo.json");

        if (!File.Exists(userInfoFilePath))
        {
            UserList emptyUserList = new UserList { users = new List<User>() };
            string emptyJson = JsonUtility.ToJson(emptyUserList, true);
            File.WriteAllText(userInfoFilePath, emptyJson);
        }
        idWarningTxt.gameObject.SetActive(false);
        passWordWarningTxt.gameObject.SetActive(false);
        joinCheckBtn.onClick.AddListener(OnJoinCheckBtnClick);
    }

    public void Clickbtn()
    {
        if (insu)
        {
            selectplayer = players[0].name;
            playerName.text = "���μ�";
        }
        else if (sujeong)
        {
            selectplayer = players[1].name;
            playerName.text = "������";
        }
        else if (jihyo)
        {
            selectplayer = players[2].name;
            playerName.text = "����ȿ";
        }
        else if (puk)
        {
            selectplayer = players[3].name;
            playerName.text = "���ǰ�";
        }
        else
        {
            selectplayer = players[4].name;
            playerName.text = "���Լ�";
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
    }

    // ��ư Ŭ�� �̺�Ʈ �Լ�
    void OnJoinCheckBtnClick()
    {
        string id = idField.text;
        string password = passWordField.text;

        bool isIdValid = !IdCheck(id);
        bool isPasswordValid = PasswordCheck(password);

        idWarningTxt.gameObject.SetActive(!isIdValid);
        passWordWarningTxt.gameObject.SetActive(!isPasswordValid);

        if (isIdValid && isPasswordValid)
        {
            SaveUser(id, password, selectplayer);
            UserAddedSuccessfully?.Invoke();

            PlayerPrefs.SetString("selectPlayer", selectplayer);
            PlayerPrefs.SetFloat("PlayerPositionX", 0);
            PlayerPrefs.SetFloat("PlayerPositionY", 0);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);
        }
        else
        {
            Debug.Log("���̵��� ���õ��� �ʾҽ��ϴ�!");
        }
    }

    // ID ��ȿ�� �˻��ϴ� �Լ�
    bool IdCheck(string id)
    {
        if (File.Exists(userInfoFilePath))
        {
            string json = File.ReadAllText(userInfoFilePath);
            UserList userList = JsonUtility.FromJson<UserList>(json);
            if (userList != null && userList.users != null)
            {
                foreach (var user in userList.users)
                {
                    if (user.id == id)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    // Password ��ȿ�� �˻��ϴ� �Լ�
    bool PasswordCheck(string password)
    {
        return password.Length >= 4 && password.Length <= 12;
    }


    // Json���Ͽ� �����ϴ� �Լ�
    void SaveUser(string id, string password, string selectedCharacter)
    {
        if (string.IsNullOrEmpty(userInfoFilePath))
        {
            return;
        }

        User newUser = new User { id = id, password = password, selectedCharacter = selectedCharacter };
        UserList userList;

        if (File.Exists(userInfoFilePath))
        {
            string json = File.ReadAllText(userInfoFilePath);

            if (string.IsNullOrEmpty(json))
            {
                userList = new UserList { users = new List<User>() };
            }
            else
            {
                userList = JsonUtility.FromJson<UserList>(json);
            }
        }
        else
        {
            userList = new UserList { users = new List<User>() };
        }

        if (userList.users == null)
        {
            userList.users = new List<User>();
        }

        userList.users.Add(newUser);
        string newJson = JsonUtility.ToJson(userList, true);
        File.WriteAllText(userInfoFilePath, newJson);
    }
}
