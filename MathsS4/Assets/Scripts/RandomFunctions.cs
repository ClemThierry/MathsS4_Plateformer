using UnityEngine;

public class RandomFunctions : MonoBehaviour
{
    float randomByTime(float gamma)
    {
        return gamma * Mathf.Log(1-(Random.Range(0f, 1f)));
    }
}
