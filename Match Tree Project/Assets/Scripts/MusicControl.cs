using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameObject ObjectMusic;
    private AudioSource AudioSource;
    public GameObject sound_on;
    public GameObject sound_off;

    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        if (AudioSource.isPlaying)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
        }
        else
        {
            sound_on.SetActive(true);
            sound_off.SetActive(false);
        }
    }
    
    // randomkubuaukstis
   //  [SerializeField]
    //private float moveSpeed = 2.5f;

    //[Min(0f)]
    //[SerializeField]
    //private float jumpForce = 2.5f;

    //private float horizontalInput;
    //private float verticalInput;
    //private bool isJumping;
    //private bool isGrounded;
    //private bool change = false;

    //private Rigidbody rb;

    //private GameObject[] cubes;

    //void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

   // private void Start()
   // {
   //     cubes = GameObject.FindGameObjectsWithTag("Cube");
   // }

    // Update is called once per frame
   // void Update()
   // {
   //     ProcessInput();
   // }
  //  void FixedUpdate()
   // {
   //     Movement();
   // }

   // private void Movement()
   // {
   //     rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
    //    if (isJumping && isGrounded)
   //     {
   //         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
   //     }
   //     isJumping = false;
   // }

   // private void ProcessInput()
   // {
   //     horizontalInput = Input.GetAxis("Horizontal");
   //     verticalInput = Input.GetAxis("Vertical");
//
   //     if (Input.GetButtonDown("Jump"))
   //         isJumping = true;
    //}
    //private void OnCollisionEnter(Collision other)
    //{
    //    isGrounded = true;
    //    foreach(GameObject cube in cubes)
    //    {
    //        cube.transform.localScale = new Vector3(cube.transform.localScale.x, Random.Range(0.1f, 3), cube.transform.localScale.z);
     //   }
   // }

  //  private void OnCollisionExit(Collision other)
  //  {
  //      isGrounded = false;
  //  }
    //

    public void MuteMusic()
    {
        AudioSource.Pause();
    }

    public void UnmuteMusic()
    {
        AudioSource.UnPause();
    }
}
