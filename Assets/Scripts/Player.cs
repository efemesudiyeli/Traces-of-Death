using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction = Vector3.zero;
    [SerializeField] private float moveSpeed = 3f;

    private bool _isMovementDisabled = false;
    // Update is called once per frame
    void Update()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }

    private void FixedUpdate()
    {
        if (!_isMovementDisabled)
        {
            Move();
        }
    }

    private void Move()
    {
        RotateCharacterToFaceDirection();
        transform.Translate(_direction * Time.fixedDeltaTime * moveSpeed, Space.World);
    }

    private void RotateCharacterToFaceDirection()
    {
        if (_direction.x > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z), 0.1f);
        }
        else if (_direction.x < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z), 0.1f);
        }
    }

    public void DisableMovement()
    {
        _isMovementDisabled = true;
    }

    public void EnableMovement()
    {
        _isMovementDisabled = false;
    }


}
