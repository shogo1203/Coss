using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    [System.NonSerialized] public bool IsPlay;
    [SerializeField] GameObject player;
    [SerializeField] GameObject startCanvas;
    [SerializeField] AudioClip clip;
    static GameManager instance;
    bool isStart;
    public bool IsEnd;
    public bool IsClear;

    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<GameManager>();
        }
    }
    // Use this for initialization
    void Start()
    {
        IsClear = false;
        isStart = false;
        IsPlay = false;
        IsEnd = false;
        player.SetActive(false);
        player.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

        StartAction();
        EndAction();
        ClearAction();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void StartAction()
    {
        if (!isStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SEManager.Instance.OneShot(clip);
                IsPlay = true;
                isStart = true;
                player.SetActive(true);
                player.GetComponent<Rigidbody>().useGravity = true;
                startCanvas.SetActive(false);
            }
        }
    }

    void EndAction()
    {
        if (IsEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SEManager.Instance.OneShot(clip);
                SceneManager.LoadScene(0);
            }
        }
    }

    void ClearAction()
    {
        if (IsClear)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SEManager.Instance.OneShot(clip);
                SceneManager.LoadScene(0);
            }
        }
    }
}
