using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputManager InputAksi;
    [SerializeField] private Transform _CameraTransform;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    [Header("Movement Settings")]
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpForce = 7f;
    [SerializeField] private float GroundCheckRadius = 0.3f;
    [SerializeField] private float SprintSpeed = 10f;  
    private bool isSprinting;

    [Header("Movement Settings")]
    private Rigidbody rb;
    private Vector2 inputDirection;
    private bool isGrounded;
    private Animator animation;
    private bool isJumping;

    [Header("Score Settings")]
    private float Score;
    public TMP_Text text;
    public TMP_Text textfinal;
    [Header("HealthBar Settings")]
    private float Health = 100; 
    public Slider healthBar;

    public GameObject lampuParent;
    public Light[] allLights;

    [Header("Game Over Settings")]
    public GameObject gameOverCanvas;
    public float gameTime = 60f; 
    private bool isGameOver = false;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip walkClip;
    public AudioClip runClip;
    public AudioClip coinClip;
    public AudioClip gameOverClip;
    public AudioClip badCoinClip;

   

    private CountDown countDownScript;

    public void RestartGame()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Merah"))
        {
            Debug.Log("Merah");
            Score += 20;
            audioSource.PlayOneShot(coinClip);
        }
        else if (other.gameObject.CompareTag("Hijau"))
        {
            Debug.Log("Hijau");
            Score += 100;
            audioSource.PlayOneShot(coinClip);
        }
        else if (other.gameObject.CompareTag("Kuning"))
        {
            Debug.Log("Kuning");
            Score += 10;
            TurnOnAllLights();
            audioSource.PlayOneShot(coinClip);
        }
        else if (other.gameObject.CompareTag("Hitam"))
        {
            Debug.Log("Hitam");
            Health -= 10;
            if (Health < 0) Health = 0;
            TurnOffAllLights();
            audioSource.PlayOneShot(badCoinClip);
        }
        else if (other.gameObject.CompareTag("Biru"))
        {
            Debug.Log("Biru");
            Health += 20;
            if (Health > 100) Health = 100;
            audioSource.PlayOneShot(coinClip);
        }

        Destroy(other.gameObject);
        text.text = Score.ToString();
        textfinal.text = Score.ToString();
        healthBar.value = Health;
    }



    void TurnOnAllLights()
    {
        foreach (Light lamp in allLights)
        {
            lamp.enabled = true;
        }
    }

    void TurnOffAllLights()
    {
        foreach (Light lamp in allLights)
        {
            lamp.enabled = false;
        }
    }



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Kunci cursor di tengah
        Cursor.visible = false; // Sembunyikan cursor

        InputAksi.PlayerMovement += OnMove;
        InputAksi.JumpAksi += OnJump;
        healthBar.maxValue = 100;
        healthBar.value = Health;
        allLights = lampuParent.GetComponentsInChildren<Light>();

        countDownScript = FindObjectOfType<CountDown>();
    }


    private void OnDestroy()
    {
        InputAksi.PlayerMovement -= OnMove;
        InputAksi.JumpAksi -= OnJump;
    }

    private void Update()
    {
        if (isGameOver) return;

        CheckGround();
        RotateTowardsCamera();
        CheckSprint();

        // Cek GameOver dari Health atau dari Timer
        if (Health <= 0 || (countDownScript != null && countDownScript.isTimeOut))
        {
            GameOver();
        }
    }



    private void FixedUpdate()
    {
        Move();
    }

    private void OnMove(Vector2 direction)
    {
        inputDirection = direction;
    }

    private void CheckSprint()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }


    private void OnJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
            isJumping = true;
            animation.SetBool("isJumping", true);
        }
    }


    private void Move()
    {
        Vector3 camForward = _CameraTransform.forward;
        Vector3 camRight = _CameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * inputDirection.y + camRight * inputDirection.x;

        float currentSpeed = isSprinting ? SprintSpeed : Speed;

        Vector3 newVelocity = new Vector3(moveDirection.x * currentSpeed, rb.velocity.y, moveDirection.z * currentSpeed);
        rb.velocity = newVelocity;

        HandleAnimations(moveDirection);
    }



    private void RotateTowardsCamera()
    {
        if (isGameOver) return; // Tambahin ini supaya kamera stop muter

        if (inputDirection != Vector2.zero)
        {
            Vector3 moveDir = _CameraTransform.forward * inputDirection.y + _CameraTransform.right * inputDirection.x;
            moveDir.y = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }


    private void CheckGround()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayer);

        if (isGrounded && !wasGrounded)
        {
            isJumping = false;
            animation.SetBool("isJumping", false);
        }
    }


    private void HandleAnimations(Vector3 moveDirection)
    {
        float targetSpeed = 0f;

        if (moveDirection.magnitude > 0.1f) // Gerak sedikit aja sudah dianggap bergerak
        {
            if (isSprinting)
            {
                targetSpeed = 1f; // Lari
                PlaySound(walkClip, runClip);
            }
            else
            {
                targetSpeed = 0.5f; // Jalan
                PlaySound(walkClip, walkClip);
            }
        }
        else
        {
            targetSpeed = 0f; // Idle
            if (audioSource.isPlaying) audioSource.Stop(); // Stop suara kalau diem
        }

        animation.SetFloat("speed", targetSpeed, 0.1f, Time.deltaTime); // Smooth speed perubahan
    }


    void PlaySound(AudioClip walkClip, AudioClip sprintClip)
    {
        if (audioSource.clip != (isSprinting ? sprintClip : walkClip) || !audioSource.isPlaying)
        {
            audioSource.clip = isSprinting ? sprintClip : walkClip;
            audioSource.Play();
        }
    }





    void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        // Play sound effect game over
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(gameOverClip);
        }

        gameOverCanvas.SetActive(true);

        // Freeze gerakan
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        // Matikan animasi
        animation.SetFloat("speed", 0f);

        // Matikan input
        InputAksi.PlayerMovement -= OnMove;
        InputAksi.JumpAksi -= OnJump;

        // Cursor muncul kembali
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }








}
