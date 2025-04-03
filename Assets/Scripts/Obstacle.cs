using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            PlayerCollision();
    }

    protected virtual void PlayerCollision()
    {
        PlayerEvents.CallOnPlayerHit();
        print("Player collided with: " + name);
    }
}
