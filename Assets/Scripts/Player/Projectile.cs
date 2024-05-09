using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float projectileDamage;

    private Vector3 targetDirection;

    void Start()
    {
        speed = 20f;
        rotationSpeed = 30f;

        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rock/rock1");
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rock/rock2");
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rock/rock3");
                break;

            default:
                break;
        }

    }

    public void SetDirection(Vector3 direction)
    {
        targetDirection = direction.normalized;
    }

    public void SetDamage(float damage)
    {
        projectileDamage = damage;
    }

    void Update()
    {
        transform.position += targetDirection * speed * Time.deltaTime;
        // transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        transform.Rotate(0f, 0f, rotationSpeed * rotationSpeed * Time.deltaTime, Space.Self);
        // transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyManager>().TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
        else if (collider.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

