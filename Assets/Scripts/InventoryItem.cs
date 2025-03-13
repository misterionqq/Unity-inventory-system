using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Item item;
    
    [HideInInspector] 
    public int count = 1; 
    
    [Header("UI")]
    public Image image;
    public TMPro.TextMeshProUGUI countText;

    [HideInInspector]
    public Transform parentAfterDrag;
    private CanvasGroup canvasGroup;

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
        if(canvasGroup == null){
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        //InitializeItem(item);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        canvasGroup.blocksRaycasts = true;
        transform.localPosition = Vector3.zero;
    }
}