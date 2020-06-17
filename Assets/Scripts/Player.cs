using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody thisrigidbody = null;
    public float Force = 300;
    public GameObject cube;
 

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        thisrigidbody = GetComponent<Rigidbody>();
        cube.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisrigidbody.AddForce(Vector3.up * Force);
            thisAnimation.Play();
        }

        if(transform.position.y <= -4.74f)
        {
            SceneManager.LoadScene("GameOver");
        }
        

       
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
            GameManager.thisManager.GameOver();
        }
    }
}
