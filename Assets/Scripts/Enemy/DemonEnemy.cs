using UnityEngine;

public class DemonEnemy : EnemyManager
{
    protected override void onStart()
    {
        attackDamage = 0.3f;
        attackSpeed = 0.3f;
        aIPath.maxSpeed = 5;
        health = 5;
        float enemyType = Random.Range(0, 8);
        switch (enemyType)
        {
            case 0:
                loadSprites("Sprites/Demon Animations/lvl1/Depraved Blackguard/DepravedBlackguard");
                break;
            case 1:
                loadSprites("Sprites/Demon Animations/lvl1/Rascally Demonling/RascallyDemonling");
                break;
            case 2:
                loadSprites("Sprites/Demon Animations/lvl1/Warp Skull/WarpSkull");
                break;

            case 3:
                loadSprites("Sprites/Demon Animations/lvl2/Crimson Imp/CrimsonImp");
                break;
            case 4:
                loadSprites("Sprites/Demon Animations/lvl2/Nefarious Scamp/NefariousScamp");
                break;
            case 5:
                loadSprites("Sprites/Demon Animations/lvl2/Pointed Demonspawn/PointedDemonspawn");
                break;

            case 6:
                loadSprites("Sprites/Demon Animations/lvl3/Antlered Rascal/AntleredRascal");
                break;
            case 7:
                loadSprites("Sprites/Demon Animations/lvl3/Foul Gouger/FoulGouger");
                break;
            case 8:
                loadSprites("Sprites/Demon Animations/lvl3/Grinning Gremlin/GrinningGremlin");
                break;

            default:
                break;
        }
    }
}
