using UnityEngine;

public class ItemTypeViewRepository : MonoBehaviour
{
    [SerializeField] private Sprite _idle;
    [SerializeField] private Sprite _target;

    public Sprite GetSpriteByType(ItemType type)
    {
        return type == ItemType.Idle ? _idle : _target;
    }
}