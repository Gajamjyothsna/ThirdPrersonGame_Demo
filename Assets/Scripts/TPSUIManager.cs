using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TPSObject;

public class TPSUIManager : MonoBehaviour
{
    public static TPSUIManager Instance;
    [System.Serializable]
    public class spriteData
    {
        public Sprite icon;
        public ObjectType objectType;
    }
    [SerializeField] private List<spriteData> spriteDatas;
    [SerializeField] private Transform panel;
    [SerializeField] private GameObject imagePrefab;

    internal void AddObjectToUI(ObjectType _type)
    {
        GameObject obj = Instantiate(imagePrefab, panel.transform);
        obj.GetComponent<Image>().sprite = spriteDatas.Find(x => x.objectType == _type).icon;
    }
}
