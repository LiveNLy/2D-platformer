using UnityEngine;

public class SpriteFliper : MonoBehaviour
{
    public void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
