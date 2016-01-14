using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{

    public float speed = 6.0f;
    float speedAndar;
    Vector3 movement;//direcao
    Animator anim;
    Rigidbody playerRigidBody;
    int floorMask;
    float camRayLength = 100.0f;
    public Camera playerCamera;
    Vector3 direcaoMovimento;
    public bool isArmed;
    Vector3 playerToMouse;
    PlayerHealth playerHealth;
    public bool hasBullets;
    public bool hasKey;
    void Awake()
    {
        
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        direcaoMovimento = playerCamera.transform.forward;
        direcaoMovimento.y = 0f;
        playerHealth = GetComponent<PlayerHealth>();
        hasBullets = false;
        hasKey = false;
    }

    void Start()
    {
        speedAndar = speed / 2;
        isArmed = false;
    }

    void FixedUpdate()
    {

        //se health menor ou igual a zero morre
        if (playerHealth.playerHealth <= 0)
        {
            anim.SetBool("PistolWalk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
            anim.SetBool("PistolStrafeLeft", false);
            anim.SetBool("PistolStrafeRight", false);
            anim.SetBool("PistolIdle", false);
            anim.enabled = false;
            Animation animation = GetComponent<Animation>();
            animation.wrapMode = WrapMode.ClampForever;
            animation.Play();
            //anim.SetBool("Death", true);
            
        }
       
        //getAxis vai buscar valores entre [-1,1]
        //getAxisRaw so tem 3 valores {-1,0,1}
        if (playerHealth.playerHealth > 0)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            //direcao para onde aponta a camara
            direcaoMovimento = playerCamera.transform.forward;
            direcaoMovimento.y = 0f;
            //ativa e desativa a arma
            if (Input.GetKeyDown(KeyCode.E))
            {
                isArmed = !isArmed;

            }

            //se estiver com arma e a andar
            if (isArmed && (h != 0 || v != 0))
            {
                Move(h, v);
                Turning();

                anim.SetBool("PistolWalk", true);
                anim.SetBool("PistolIdle", false);

                anim.SetBool("Run", false);
            }
            //se estiver armado e quieto, nao se move mas vira
            if (isArmed && (h == 0 && v == 0))
            {
                Turning();
                anim.SetBool("PistolWalk", false);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("PistolStrafeLeft", false);
                anim.SetBool("PistolStrafeRight", false);
                anim.SetBool("PistolIdle", true);
                //Debug.Log("ta quieto");
            }

            //se nao estiver armado e em movimento corre com animaçao de correr normal
            if (!isArmed && (h != 0 || v != 0))
            {

                anim.SetBool("PistolWalk", false);
                //speed = speedAnterior;
                anim.SetBool("Run", true);
                MoverSemArma(h, v);
            }

            //se nenhuma tecla for premida fica em Idle
            if (!Input.anyKey && !isArmed)
            {
                anim.SetBool("PistolWalk", false);
                anim.SetBool("Run", false);
                anim.SetBool("PistolIdle", false);
                anim.SetBool("PistolStrafeLeft", false);
                anim.SetBool("PistolStrafeRight", false);
                anim.SetBool("Idle", true);
            }
        }
       
    }

    //mover sem animaçao pistol walk
    void MoverSemArma(float h, float v)
    {
        //movement.Set(h, 0.0f, v); //ou new vector3(h,0,v)
        movement = direcaoMovimento;
        RunDirectionManager();
        playerRigidBody.MovePosition(transform.position + movement);
        playerRigidBody.transform.LookAt(transform.position + movement);
    }

    //move com animaçao pistolWalk
    void Move(float h, float v)
    {
        movement = direcaoMovimento;
        RunDirectionManager();

        //verificar angulo entre direcao pra onde esta a apontar e para onde esta a andar
        float anguloEntreDirecoes = Vector3.Angle(movement, playerToMouse);
        //decide se o strafe é para direita ou esquerda
        string LeftOrRight = ChoseStrafeLeftRight();
        //se angulo estiver dentro dos limites faz strafe
        if(anguloEntreDirecoes > 30 && anguloEntreDirecoes < 120)
        {
            
            anim.SetBool("PistolWalk", false);
            anim.SetBool(LeftOrRight, true);
        }
        //senao , nao faz strafe
        else 
        {
            anim.SetBool("PistolWalk", true);
            anim.SetBool(LeftOrRight, false);
        }
        //Debug.Log(LeftOrRight);
        movement = movement.normalized * speedAndar * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

    //vira com animaçao pistolwalk
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength))
        {
            playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0.0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }
    }



    //calcula a direção em que o persongem deve andar
    void RunDirectionManager()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = -Vector3.Cross(direcaoMovimento, Vector3.up);
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = Vector3.Cross(direcaoMovimento, Vector3.up);
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = -direcaoMovimento;
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            movement = Vector3.Cross(direcaoMovimento, Vector3.up) + direcaoMovimento;
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            movement = -Vector3.Cross(direcaoMovimento, Vector3.up) + direcaoMovimento;
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            movement = Vector3.Cross(direcaoMovimento, Vector3.up) + (-direcaoMovimento);
            movement = movement.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            movement = -Vector3.Cross(direcaoMovimento, Vector3.up) + (-direcaoMovimento);
            movement = movement.normalized * speed * Time.deltaTime;
        }
    }

    string ChoseStrafeLeftRight()
    {
        float direita = Vector3.Dot(movement, transform.right);
        float esquerda = Vector3.Dot(movement, -transform.right);
        if(direita>0 && esquerda<0)
        {
            return ("PistolStrafeRight");
            
        }
        else
        {
            return ("PistolStrafeLeft");
        }
    }

}