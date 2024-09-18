using UnityEngine;
public class InputService
{
    public Vector2 _inputVector {get; set;}

    public InputService(float horizontal, float vertical)
    {
        _inputVector = new Vector2(horizontal,vertical);
    }
}
