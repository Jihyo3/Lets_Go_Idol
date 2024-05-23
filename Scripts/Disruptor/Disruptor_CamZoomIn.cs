using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_CamZoonIn : Disruptor
{
    // 플레이어를 중심으로 카메라의 시야를 좁히는 방해물입니다.

    private Disruptor disruptor;
    [SerializeField] private GameObject playerContainer; // 유니티 직접 캐싱
    [SerializeField] private Player player;
    private Camera _mainCamera;
    private AudioSource audioSource;

    [SerializeField, Range(0.5f, 3f)] private float duration = 3f;
    [SerializeField, Range(0.5f, 3f)] private float sightSize = 1f;
    private float defaultSightSize = 5f;

    private bool IsActive = false;

    private void Awake()
    {
        disruptor = transform.parent.GetComponent<Disruptor>();
        _mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        player = playerContainer.GetComponentInChildren<Player>();
    }

    public override void Execute()
    {
        if (IsActive) return;
        StartCoroutine(CoroutineMethod());
    }

    IEnumerator CoroutineMethod()
    {
        //ChanegeCameraPosition(player);
        IsActive = true;
        GenerateSFX();
        //yield return new WaitForSeconds(duration);
        float cameraY;
        float cameraX;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            cameraX = Mathf.Lerp(0f, player.transform.position.x, elapsedTime / duration);
            cameraY = Mathf.Lerp(0f, -2.4f, elapsedTime / duration);
            _mainCamera.transform.position = new Vector3(cameraX, cameraY, -10f);  
            _mainCamera.orthographicSize = Mathf.Lerp(defaultSightSize, sightSize, elapsedTime / duration);
            yield return null;
        }

        audioSource.Stop();
        _mainCamera.orthographicSize = defaultSightSize;    
        _mainCamera.transform.position = new Vector3(0, 0, -10f);
        IsActive = false;
    }
        public void GenerateSFX()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    //public void ChangeCameraSize()
    //{
    //    // default mainCamera.orthographicSize = 5f
    //    // _mainCamera.orthographicSize = sightSize;
    //}

    //public void ChanegeCameraPosition(GameObject player)    
    //{
    //    _mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2.4f, -10f);
    //}

}
