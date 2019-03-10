using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    static SEManager instance;
    public static SEManager Instance { get { return instance; } }
    AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<SEManager>();
        }
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OneShot(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
