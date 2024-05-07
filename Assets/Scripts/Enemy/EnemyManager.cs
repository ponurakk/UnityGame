using UnityEngine;
using Pathfinding;

public abstract class EnemyManager : MonoBehaviour
{
    [SerializeField] protected GameObject playerObject;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attackSpeed;

    [SerializeField] private float timer;
    public AIPath aIPath;

    void Start()
    {
        timer = attackSpeed;
        onStart();
    }

    protected abstract void onStart();

    void Update()
    {
        timer += Time.deltaTime;

        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        onUpdate();
    }

    protected abstract void onUpdate();

    protected void loadSprites(string spritePath)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritePath);
        GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(spritePath);
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
}