using UnityEngine;
using System.Collections;

public class newGame : MonoBehaviour {

    private AudioSource[] allAudioSources;

    void Awake()
    {
        allAudioSources = FindObjectsOfType<AudioSource>() as AudioSource[];
    }

	// Use this for initialization
	void Start () {
	}

    private void StopAllAudio()
    {
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadGame()
    {
        StopAllAudio();
        Application.LoadLevel("main");
    }
}
