using UnityEngine;
using System.Collections;

public class luzTreme : MonoBehaviour {

    public float tempoTremerMin=0.8f;
    public float tempoTremerMax = 2.2f;
    float timeBetweenTremer = 800;
    float timer=0;
    int numTremidelas = 3;
    Light luz;
    
	// Use this for initialization
	void Awake () {

        luz = GetComponent<Light>();
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.time;
        
        if(timer >= timeBetweenTremer)
        {
            numTremidelas = 2;
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
        timer = 0;
        
        
        
    }

}
