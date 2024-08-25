using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    private Vector2 _direction;

    public void SetDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    private void Update()
    {
        transform.Translate(_direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
