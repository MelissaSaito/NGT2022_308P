using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContlroller : MonoBehaviour
{
    //speedMagnification�̓X�s�[�h���ߗp
    public float speedMagnification;

    public Vector3 movingForce;
    private Vector3 movingDirection, movingVelocity;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movingDirection = new Vector3(x, 0, z);
        movingDirection.Normalize();
        movingVelocity = movingDirection * speedMagnification;
    }

    void FixedUpdate()
    {
        this.rigidbody.AddForce(movingVelocity, ForceMode.Force);
    }
}
