using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;

    [SerializeField] private float timer;

    void Update()
    {
        // float attackSpeed = GetComponent<PlayerManager>();
        float attackSpeed = 0.4f;
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= attackSpeed)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePos - spawnPoint.position).normalized;

            newProjectile.GetComponent<Projectile>().SetDirection(direction);
            newProjectile.GetComponent<Projectile>().SetDamage(GetComponent<PlayerManager>().attackStrength);
            timer = 0f;
        }
    }
}
