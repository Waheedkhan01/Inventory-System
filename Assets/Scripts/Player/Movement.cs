using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Vector2 movement = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // move in X and Z axis with arrow keys
        transform.Translate(speed * Time.deltaTime * new Vector3(movement.x, 0, movement.y));
    }
}
