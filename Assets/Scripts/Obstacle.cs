using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float lifeTime = 20f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

