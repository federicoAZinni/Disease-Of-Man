using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Esto se encarga del Equipo
public class StaticInterface : UserInterface
{
    public GameObject[] slots;

    public override void CreateSlots()
    {
        //Crea diccionario de objetos mostrados
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

        //Busca los objetos dentro de la base de datos para que mostrar, los une al lugar donde se encuentran
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = slots[i];

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            slotsOnInterface.Add(obj, inventory.Container.Items[i]);
        }
    }
}