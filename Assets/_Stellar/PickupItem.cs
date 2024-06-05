using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public RawImage itemKeyImage;

    void Start()
    {
        // Canvas에서 "ItemKey_1" 이름의 RawImage 찾기
        if (itemKeyImage == null)
        {
            GameObject itemKeyObj = GameObject.Find("ItemKey_1");
            if (itemKeyObj != null)
            {
                itemKeyImage = itemKeyObj.GetComponent<RawImage>();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        // 아이템을 주울 때의 로직 작성
        Debug.Log("Picked up " + itemName);
        Destroy(gameObject);

        // RawImage의 알파 값 변경
        if (itemKeyImage != null)
        {
            Color color = itemKeyImage.color;
            color.a = 1.0f; // 알파 값을 100으로 변경 (0 ~ 1 사이의 값 사용)
            itemKeyImage.color = color;
        }
    }
}
