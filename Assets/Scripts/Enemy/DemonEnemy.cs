using UnityEngine;

public class DemonEnemy : EnemyManager
{
    protected override void onStart()
    {
        attackDamage = 0.3f;
        attackSpeed = 0.3f;
        loadSprites("Sprites/Demon Animations/antlered rascal/AntleredRascal");
    }

    protected override void onUpdate()
    {
        Debug.Log("chuj1");
    }
}
