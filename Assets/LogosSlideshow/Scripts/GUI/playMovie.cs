using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class playMovie : MonoBehaviour {

    MovieTexture movie;

	// Use this for initialization
	void Start () {
        movie = GetComponent<RawImage>().texture as MovieTexture;
        movie.Play();
        StartCoroutine(FindEnd(callback));
	}

    private IEnumerator FindEnd(Action callback)
    {
        while (movie.isPlaying)
        {
            yield return 0;
        }

        callback();
        yield break;
    }

    private void callback()
    {
        Application.LoadLevel("GameMenu");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
