using UnityEngine;
using Pathfinding;

public abstract class EnemyManager : MonoBehaviour
{
    [SerializeField] protected GameObject playerObject;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float health;

    [SerializeField] private float timer;
    public AIPath aIPath;

    void Start()
    {
        timer = attackSpeed;
        aIPath = GetComponent<AIPath>();
        onStart();
    }

    protected abstract void onStart();

    void Update()
    {
        timer += Time.deltaTime;

        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (health <= 0f)
        {
            Destroy(gameObject);
            playerObject.GetComponent<EnemySpawner>().enemyCount--;
        }
    }

    public void loadPlayerObject(GameObject player)
    {
        playerObject = player;
        GetComponent<AIDestinationSetter>().target = playerObject.transform;
    }

    protected void loadSprites(string spritePath)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritePath);
        GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(spritePath);
    }

    public void TakeDamage(float damage)
    {
        if (health >= damage) { health -= damage; }
        else { health = 0; }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<PlayerManager>().TakeDamage(attackDamage);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (timer >= attackSpeed)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                playerObject.GetComponent<PlayerManager>().TakeDamage(attackDamage);
            }
            timer = 0f;
        }
    }

    void OnTriggerLeave2D(Collider2D collider)
    {
        timer = attackSpeed;
    }

    void OnMouseOver()
    {
        Texture2D cursor = Resources.Load<Texture2D>("Cursors/Cursor_Attack");
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
