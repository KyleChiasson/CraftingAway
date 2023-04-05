using UnityEngine;
public class GroundItem : Interact
{
    public string HeldItem;
    private new void Update()
    {
        base.Update();
        ResourceItem resource = (ResourceItem)GameManger.Items[HeldItem];
        if (resource.RequiredItem != null && Inventory.Instance.ItemAmount(resource.RequiredItem.Name) == 0)
            InteractNotifier.color = Color.red;
        else InteractNotifier.color = Color.white;
    }
    public override void Interacted()
    {
        ResourceItem resource = (ResourceItem)GameManger.Items[HeldItem];
        if (resource.RequiredItem != null)
        {
            if (Inventory.Instance.ItemAmount(resource.RequiredItem.Name) == 0)
                return;
            Inventory.Instance.ChangeItemAmount(resource.RequiredItem.Name, -1);
        }
        Inventory.Instance.ChangeItemAmount(HeldItem, 1);
        Destroy(gameObject);
    }
}