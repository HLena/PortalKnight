using System;
using UnityEngine;
using UnityEngine.EventSystems;

//public class ItemData : MonoBehaviour
public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Item item;
	public int amount;
	public int slotId;

	Inventory inv;
	//private Tooltip tooltip;
	public Vector2 offset;

	void Start()
	{
		inv = GameObject.Find("Play").GetComponent<Inventory>();
      //  tooltip = inv.GetComponent<Tooltip>();
        this.transform.position = inv.slots[slotId].transform.position;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (item.Id != -1)
		{
			this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            //this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (item.Id != 1)
		{
            this.transform.position = eventData.position - offset;
            //this.transform.position = eventData.position;
        }
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(inv.slots[slotId].transform);
		this.transform.position = inv.slots[slotId].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//tooltip.Activate(item);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//tooltip.Deactivate();
	}
}
