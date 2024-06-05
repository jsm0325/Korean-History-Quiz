using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public RawImage itemKeyImage;

    void Start()
    {
        // Canvas���� "ItemKey_1" �̸��� RawImage ã��
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
        // �������� �ֿ� ���� ���� �ۼ�
        Debug.Log("Picked up " + itemName);
        Destroy(gameObject);

        // RawImage�� ���� �� ����
        if (itemKeyImage != null)
        {
            Color color = itemKeyImage.color;
            color.a = 1.0f; // ���� ���� 100���� ���� (0 ~ 1 ������ �� ���)
            itemKeyImage.color = color;
        }
    }
}
