
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerDirection : MonoBehaviour
{
    [Header("Sprites das 8 direcoes")]
    [SerializeField] private Sprite[] directionSprites = new Sprite[8];

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateDirection(Vector2 movement)
    {
        if (movement.sqrMagnitude < 0.001f)
        {
            return;
        }

        float angle = Mathf.Atan2(
            movement.y,
            movement.x
        ) * Mathf.Rad2Deg;

        int index = Mathf.RoundToInt(
            (90f - angle) / 45f
        );

        index = (index % 8 + 8) % 8;
        index = (index + 4) % 8;

        if (directionSprites[index] != null)
        {
            spriteRenderer.sprite = directionSprites[index];
        }
    }
}
