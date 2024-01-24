using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _jump = 5f;
    [SerializeField] float _gravityModifier = 1;
    [SerializeField] bool _isGrounded = true;
    public bool _gameOver;

    [SerializeField] ParticleSystem dirtParticle;
    [SerializeField] ParticleSystem explosionParticle;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip jumpSound;

    AudioSource playerAudio;
    Rigidbody playerRb;
    Animator playerAnim;



    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier;

        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_gameOver)
        {
            playerRb.AddForce(Vector3.up * _jump, ForceMode.Impulse);
            _isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacal"))
        {
            _gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Gameover");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
    }

}
