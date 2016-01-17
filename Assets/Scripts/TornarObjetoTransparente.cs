using UnityEngine;
using System.Collections;

public class TornarObjetoTransparente : MonoBehaviour {

    RaycastHit ray;
    Vector3 playerPosition;
    Vector3 direcao;
    public GameObject player;
    float rayDistance=200f;
    Color color;
    Color colorOriginal;
    Ray shootRay;
	void Start () 
    {
        playerPosition = player.transform.position;
        direcao = transform.position + playerPosition;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        playerPosition = player.transform.position;
        direcao = transform.position - playerPosition;

        CamaraRay();
	}

    void CamaraRay()
    {
        //novo
        shootRay.origin = Camera.main.transform.position;
        shootRay.direction = -direcao;

        RaycastHit rayHit;
        if(Physics.Raycast(shootRay, out rayHit, rayDistance))
        {
            
            Debug.DrawRay(Camera.main.transform.position, -direcao, Color.green);
            if (rayHit.transform.tag == "hideObject")
            {
                GameObject edificio = rayHit.collider.gameObject;
                //color = edificio.GetComponent<Renderer>().material.color;
                //color.a = 0.2f;
                //edificio.GetComponent<Renderer>().material.color = color;
                edificio.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GameObject[] listaEdificios;
                listaEdificios = GameObject.FindGameObjectsWithTag("hideObject");
                foreach (GameObject e in listaEdificios)
                {
                    //color.a = 1f;
                    //e.GetComponent<Renderer>().material.color = color;
                    e.GetComponent<Renderer>().enabled = true;
                }
            }
            
        }
    }
}
