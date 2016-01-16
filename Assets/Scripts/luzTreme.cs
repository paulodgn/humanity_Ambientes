using UnityEngine;
using System.Collections;

public class luzTreme : MonoBehaviour {

     float tempoTremerMin=0.05f;
     float tempoTremerMax = 0.15f;
    float timeBetweenTremer = 6f;
    float timer=0;
    int numTremidelas = 3;
    Light luz;
    int count;
	// Use this for initialization
	void Awake () {
        luz = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        timer += Time.deltaTime;
        
        if(timer >= timeBetweenTremer)
        {
            numTremidelas = 4;
            StartCoroutine(Treme());
            
        }
              
	}

    IEnumerator Treme()
    {
        while (numTremidelas>=0) 
        {
            luz.enabled = true;
            yield return new WaitForSeconds(Random.Range(tempoTremerMin, tempoTremerMax));
            luz.enabled = false;
            yield return new WaitForSeconds(Random.Range(tempoTremerMin, tempoTremerMax));
            luz.enabled = true;
            numTremidelas--;
        }
        Debug.Log(count++);
        timer = 0;
        
        
    }

}
