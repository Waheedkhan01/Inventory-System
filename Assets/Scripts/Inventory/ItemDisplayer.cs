using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour
{
    public Item DisplayedItem { get; private set; }

    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Type;
    [SerializeField] private TextMeshProUGUI Value;
    [SerializeField] private TextMeshProUGUI Weight;
    [SerializeField] private TextMeshProUGUI Rarity;
    [SerializeField] private Image Icon;

    [SerializeField] private TextMeshProUGUI quantity;

    [SerializeField] private GameObject optionsMenu;
    public Button eqipUseButton;
    public Button dropButton;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        optionsMenu.SetActive(false);
    }

    private void OnClick()
    {
        if (DisplayedItem.Type == Item.ItemCategory.Quest) // No options for quest items. Cannot equip, use, or drop quest items.
        {
            return;
        }
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void DisplayItem(Item item, int quantity)
    {
        DisplayedItem = item;

        Name.text = item.Name;
        Type.text = item.Type.ToString();
        Value.text = item.Value.ToString();
        Weight.text = item.Weight.ToString();
        Rarity.text = item.Rarity.ToString();
        Icon.sprite = item.itemSprite;

        this.quantity.text = quantity.ToString();
    }
}
