using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryItem {
  string Name { get; }
  Sprite Image { get; }
  void OnPickup();
}

public class InventoryItemEventArgs : EventArgs {
  public InventoryItem item;

  public InventoryItemEventArgs(InventoryItem item) {
    Item = item;
  }
}
