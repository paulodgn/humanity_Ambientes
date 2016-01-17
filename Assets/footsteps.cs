using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour {

    public AudioClip[] audios;
    AudioSource audioSource;
    SphereCollider leftFootCollider;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        leftFootCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collision col)
    {
        Debug.Log("Pé no chão!");
        if (col.gameObject.name == "passeios" || col.gameObject.name == "Terrain")
        {
            audioSource.clip = audios[Random.Range(0, audios.Length)];
            audioSource.Play();
        }
        else
        {
            Debug.Log(col.gameObject.name);
        }
    }

    
}
