using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  private const int SLOTS = 6;

  private List<InventoryItem> inventoryItems = new List<InventoryItem>();

  public event EventHandler<InventoryItemEventArgs> ItemAdded;

  public void AddItem(InventoryItem item) {
    if (inventoryItems.Count < SLOTS) {
      inventoryItems.Add(item);
      item.OnPickup();

      if (ItemAdded != null) {
        ItemAdded.(this, new InventoryItemEventArgs(item));
      }
    }
  }
}
