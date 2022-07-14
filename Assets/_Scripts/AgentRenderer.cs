using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 pointerInput )
    {

        var direction = (Vector3)pointerInput - transform.position;
        // Result here checks the angle of the vector between vector up and our direction if our z value is positive (left) or negative (right)
        var result = Vector3.Cross(Vector2.up, direction);
        spriteRenderer.flipX = result.z > 0 ? true : result.z < 0 ? false : spriteRenderer.flipX;
    } 


}
