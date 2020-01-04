using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float yRotSpeed;
    public float currentYRot;
    public float currentCamRoat;
    public float jumpForce = 2f;
    public float mouseX;

    public float swingSpeed = .5f;
    private float timeUntilSwing = 0;
    public GameObject sword;
    public Animator swordAnim;
    public ParticleSystem swordPart;

    public float fireSpeed = 1f;
    private float timeUntilFire = 0;
    public GameObject bullet;
    public Transform bulletPos;
    public ParticleSystem gunPart;
    public Transform cameraAim;

    public bool isMoving = false;

    private InWater selfInWater;
    private Rigidbody rb;

    


  //  public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        selfInWater = GetComponent<InWater>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSwing = Mathf.Max(0, timeUntilSwing - Time.deltaTime);
        timeUntilFire = Mathf.Max(0, timeUntilFire - Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
            float moveForward = 0;
            float moveRight = 0;
            moveForward += Input.GetAxis("Vertical");
            moveRight += Input.GetAxis("Horizontal");

            Vector3 moveVector = (transform.forward * moveForward) + (transform.right * moveRight);

            moveVector.Normalize();
            moveVector *= speed * Time.deltaTime;
            transform.position += moveVector;
        }
        else
        {
            isMoving = false;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (timeUntilSwing <=0)
            {
                timeUntilSwing = swingSpeed;
                SwordSwing();
            }
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (timeUntilFire <= 0)
            {
                timeUntilFire = fireSpeed;
                GunFire();
            }
        }

        //if (Input.GetAxis("Mouse X") != 0)
        //{
        //    float dHor = Input.GetAxis("Mouse X") * yRotSpeed;
        //    currentYRot += dHor;
        //    transform.rotation = Quaternion.Euler(0, currentYRot, 0);

        //}


        //if (Input.)

        //if (Input.GetAxis("Mouse Y") != 0)
        //{
        //    float dVert = Input.GetAxis("Mouse Y") * yRotSpeed;
        //    currentCamRoat += dVert;
        //    camera.rotation = Quaternion.Euler(currentCamRoat, 0, 0);

        //}

        if (Input.GetAxis ("Jump") != 0)
        {

            Debug.Log("Jump is called");

            if (selfInWater.inWater == true)
            {
                Debug.Log("Jumper should jump");
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }

        //mouseX = Input.GetAxis("Mouse X");
        //transform.rotation *= Quaternion.Euler(0, mouseX, 0);


    }
    private void SwordSwing ()
    {
        sword.SetActive(true);
        swordAnim.SetBool("isSwinging", true);
        swordPart.Play();
        Invoke("SwordVanish", .05f);
    }


    private void SwordVanish ()
    {
        sword.SetActive(false);
        swordAnim.SetBool("isSwinging", false);
        swordPart.Stop();

    }

    private void GunFire ()
    {
        GameObject myBullet = Instantiate(bullet, bulletPos.position, cameraAim.rotation);
        gunPart.Play();
    }

}
