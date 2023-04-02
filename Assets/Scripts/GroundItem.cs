public class GroundItem : Interact
{
    public Item HeldItem;
    public override void Interacted()
    {
        if (HeldItem.Name == "Lumber")
        {
            if (Inventory.Instance.ItemAmount("Axe") > 0)
            {
                Inventory.Instance.ChangeItemAmount("Axe", -1);
                Inventory.Instance.ChangeItemAmount("Lumber", 1);
                Destroy(gameObject);
            }
        }
        else if (HeldItem.Name == "Ore")
        {
            if (Inventory.Instance.ItemAmount("Pickaxe") > 0)
            {
                Inventory.Instance.ChangeItemAmount("Pickaxe", -1);
                Inventory.Instance.ChangeItemAmount("Ore", 1);
                Destroy(gameObject);
            }
        }
        else if (HeldItem.Name == "Plant")
        {
            if (Inventory.Instance.ItemAmount("Shovel") > 0)
            {
                Inventory.Instance.ChangeItemAmount("Shovel", -1);
                Inventory.Instance.ChangeItemAmount("Plant", 1);
                Destroy(gameObject);
            }
        }
        else
        {
            Inventory.Instance.ChangeItemAmount(HeldItem.Name, 1);
            Destroy(gameObject);
        }
    }
}