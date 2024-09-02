using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Item))]
[RequireComponent(typeof(Button))]
public class ItemView : ButtonListener
{
    [SerializeField] private ItemTypeRepository _typeRepository;
    [SerializeField] private ItemTypeViewRepository _typeViewRepository;
    [SerializeField] private ClickedItemsCounter _clickedItemsCounter;

    private Item _item;
    private Image _image;
    private Button _button;

    public Item Item => _item;

    protected override void HandleInitialized()
    {
        _item =  GetComponent<Item>();
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    public void Actualize()
    {
        if (_item == null || _image == null || _button == null)
        {
            HandleInitialized();
        }

        _item.Reset();

        _image.sprite = _typeViewRepository.GetSpriteByType(_item.Type);
        _button.interactable = true;
    }

    protected override void Listen()
    {
        if (_clickedItemsCounter.Count == _typeRepository.TargetCount - 1)
        {
            _item.TryClick();
            return;
        }

        if (!_item.TryClick()) return;

        _button.interactable = false;
    }
}