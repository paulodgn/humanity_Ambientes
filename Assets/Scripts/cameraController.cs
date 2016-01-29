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
        offset = new Vector3(0, 2, 1f);


    }

    // Update is called once per frame
    void Update()
    {

        
        transform.position = player.position + offset;
        transform.LookAt(player.position + new Vector3(0, 1.5f, 0));

        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("GameMenu");
        }

    }


}