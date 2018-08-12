using UnityEngine;

public partial class PowerUpObject : MonoBehaviour
{

    public PowerUpType PowerUp;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == StaticNames.Player)
        {

            switch (PowerUp)
            {
                case PowerUpType.SlowDownEnemies:
                    GameHelpers.GetPowerUpController(StaticNames.PowerUpSlowDown).Increase(1);
                    break;
                case PowerUpType.HiddenFromEnemies:
                    GameHelpers.GetPowerUpController(StaticNames.PowerUpHidden).Increase(1);
                    break;
                case PowerUpType.IncreaceTime:
                    var rnd = new System.Random();
                    var time = rnd.Next(3, 10);

                    GameHelpers.GetHUDLevelTimeLeft().IncreaseTime(time);
                    break;
                default:
                    break;
            }

            Destroy(gameObject, 0);
        }
    }
}
