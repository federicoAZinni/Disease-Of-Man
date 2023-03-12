using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Esto se encarga del Inventario
public class DynamicInterface : UserInterface
{
    public GameObject inventoryPrefab;

    public int XSpaceBetweenItems;
    public int YSpaceBetweenItems;
    public int NumberOfColumn;

    public int XStart;
    public int YStart;

    public override void CreateSlots()
    {
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            slotsOnInterface.Add(obj, inventory.Container.Items[i]);
        }
    }

    //Se encarga de manejar la posicion de los slots del inventario.
    private Vector3 GetPosition(int i)
    {
        return new Vector3(XStart + (XSpaceBetweenItems * (i % NumberOfColumn)), YStart + (-YSpaceBetweenItems * (i / NumberOfColumn)), 0f);
    }
}
