using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public int jumpAmount;
    int currJumps;
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        currJumps = jumpAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space) && currJumps > 0)//hasjump es similar a hasjump == true pero mejor escrito
        {
            //transform.Translate(0, jumpForce, 0);
            RB.velocity = new Vector3(RB.velocity.x, 0, RB.velocity.z);
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currJumps--;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        currJumps = jumpAmount;
    }
}
