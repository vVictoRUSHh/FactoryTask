using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour, IMovable
{
    public Rigidbody _rb;
    public float _speed;

    public void Moving()
    {
        var input = new InputService(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        Vector3 move = new Vector3(input._inputVector.x, 0, input._inputVector.y).normalized * _speed * Time.deltaTime;

        if (move.magnitude > 0)
        {
            _rb.MovePosition(_rb.position + move);
            Vector3 forwardDirection = new Vector3(input._inputVector.x, 0, input._inputVector.y).normalized;
            if (forwardDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(forwardDirection);
                _rb.rotation = Quaternion.Slerp(_rb.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }

    private void Update()
    {
        Moving();
    }
}