using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPlayer : MonoBehaviour
{
    // public: other scripts have access to it, private: only this script has an access to it
    // [SerializeField]: to enable the edit space of mentioned variable in Unity Editor
    [SerializeField] private float speedMultiplier = 10f;
    [SerializeField] private  int health = 100;
    [SerializeField] private float boundariesTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //increment the boundariesCheck var to a real world time
        boundariesTimer += Time.deltaTime;

        // Move player AWSD
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)*speedMultiplier*Time.deltaTime;

        Bounder();
    }

    // void: no return; usually use to initiate a function or a custom function
    void Bounder() 
    {
        if (transform.position.x >= 7.35) 
        {
            transform.position = new Vector3(7.35f, transform.position.y, transform.position.z);
            Hurt();
        }

        if (transform.position.x <= -7.35)
        {
            transform.position = new Vector3(-7.35f, transform.position.y, transform.position.z);
            Hurt();
        }

        if (transform.position.y >= 3.75)
        {
            transform.position = new Vector3(transform.position.x, 3.75f, transform.position.z);
            Hurt();
        }

        if (transform.position.y <= -3.75)
        {
            transform.position = new Vector3(transform.position.x, -3.75f, transform.position.z);
            Hurt();
        }

    }

    void Hurt()
    {
        if (boundariesTimer > 2)
        {
            health -= 1;
            boundariesTimer = 0;
            Debug.Log(health);
        }
    }
}
