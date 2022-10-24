using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioManager ballAudio;

    public float bounceForce = 6;

    // Start is called before the first frame update
    void Start()
    {
        ballAudio = FindObjectOfType<AudioManager>();

        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        ballAudio.Play("bounce");

        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            // The ball is in safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            // The game is over
            ballAudio.Play("game over");
            GameManager.gameOver = true;
        }
        else if (materialName == "Last Ring (Instance)")
        {
            // The Level is Completed
            ballAudio.Play("level completed");
            GameManager.levelCompleted = true;
        }
    }
}
