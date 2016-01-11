using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{

    Transform player;
    float speed;
    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = 5f;
        offset = new Vector3(0,10,14);


    }

    // Update is called once per frame
    void Update()
    {

        
        transform.position = player.position + offset;
        transform.LookAt(player);

        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;
        }

    }


}