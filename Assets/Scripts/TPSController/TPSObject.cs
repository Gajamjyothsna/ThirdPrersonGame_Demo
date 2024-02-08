using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPSObject : MonoBehaviour
{
    #region DataModel
    [System.Serializable]
    public enum ObjectType
    {
        Snipper,
        Pistol,
        HealthKit,
        RedBull
    }
    #endregion
    
    [SerializeField] private ObjectType type;

    private string objectName;
    private ObjectType _type;
    private void Start()
    {
        this._type = type;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("type" + _type);

            TPSUIManager.Instance.AddObjectToUI(_type);
            Debug.Log(other.gameObject.tag);
            Destroy(gameObject, 2f);
        }
    }
}
