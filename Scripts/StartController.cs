using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class StartController : MonoBehaviour
{
    [SerializeField] private GameObject joinBgImg;
    [SerializeField] private GameObject loginBgImg;
    [SerializeField] private GameObject setBgImg;
    [SerializeField] private GameObject singleBgImg;
    [SerializeField] private GameObject multiBgImg;
    public Button loginBtn;
    public Button startBtn;
    public Button joinBtn;
    public TMP_InputField myIdField;
    public TMP_InputField myPassWordField;
    public PlayerJoinManager playerJoinManager;
    public float delayTime = 5f;
    private CanvasGroup loginCanvasGroup;

    private string userInfoFilePath; 

    private void Start()
    {
        if (playerJoinManager != null)
        {
            playerJoinManager.UserAddedSuccessfully += OnUserAddedSuccessfully;
        }

        userInfoFilePath = Path.Combine(Application.persistentDataPath, "PlayerInfo.json");
        loginCanvasGroup = loginBgImg.GetComponent<CanvasGroup>();
        startBtn.interactable = true;

    }

    IEnumerator ShowloginImg()
    {
        yield return new WaitForSeconds(delayTime);

        float elapsedTime = 0f;
        while (elapsedTime < delayTime)
        {
            elapsedTime += Time.deltaTime;
            loginCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / delayTime); // ������ ���� ����
            yield return null;
        }
        loginCanvasGroup.alpha = 1f; // ���������� ������ 1�� ����
    }

    public void JoinTxtClick()
    {
        loginCanvasGroup.alpha = 0;
        loginBgImg.SetActive(false);
        joinBgImg.SetActive(true);
        startBtn.gameObject.SetActive(true);
        loginBtn.gameObject.SetActive(false);
        startBtn.interactable = false;
    }

    public void JoinCloseBtnClick()
    {
        startBtn.interactable = true;
        startBtn.gameObject.SetActive(true);
        loginBtn.gameObject.SetActive(false);
        joinBgImg.SetActive(false);
    }

    void OnUserAddedSuccessfully()
    {
        // ���� �߰� ���� �� joinBgImg ��Ȱ��ȭ
        joinBgImg.SetActive(false);
    }

    public void StartBtnClick()
    {
        loginBgImg.SetActive(true);
        StartCoroutine(ShowloginImg());
        startBtn.gameObject.SetActive(false);
        loginBtn.gameObject.SetActive(true);

    }

    public void SetBtnClick()
    {
        if (setBgImg.activeSelf)
        {
            setBgImg.SetActive(false);
        }
        else
        {
            setBgImg.SetActive(true);
        }
    }

    public void LoginBtnClick()
    {
        string enteredId = myIdField.text;
        string enteredPassword = myPassWordField.text;

        if (CheckLogin(enteredId, enteredPassword))
        {
            ScoreManager.instance.id = myIdField.text;
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.Log("���̵� �Ǵ� ��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
        }
    }

    private bool CheckLogin(string enteredId, string enteredPassword)
    {
        // ����� ���� �ε�
        if (File.Exists(userInfoFilePath))
        {
            string jsonData = File.ReadAllText(userInfoFilePath);
            UserList savedUserList = JsonUtility.FromJson<UserList>(jsonData);

            if (savedUserList != null && savedUserList.users != null)
            {
                foreach (var user in savedUserList.users)
                {
                    if (user.id == enteredId && user.password == enteredPassword)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public void SingleBtnClick()
    {
        singleBgImg.SetActive(true);
        multiBgImg.SetActive(false);
    }

    public void MultiBtnClick()
    {
        singleBgImg.SetActive(false);
        multiBgImg.SetActive(true);
    }
}
