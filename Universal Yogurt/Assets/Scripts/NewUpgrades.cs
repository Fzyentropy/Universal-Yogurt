using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUpgrades : MonoBehaviour
{

    public GameObject YogurtMachine;
    private bool isYogurtMachine = false;
    
    public GameObject YogurtFactory;
    private bool isYogurtFactory = false;
    
    private GameObject newUpgrade;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NewUpgrade();
    }

    void NewUpgrade()
    {
        
        if ((GameManager.Yogurt_Drop_Number >= 10
            ) && (!isYogurtMachine))
        {
            isYogurtMachine = true;
            ImplementUpgrade(YogurtMachine);
        }
        
        if ((GameManager.Yogurt_Drop_Number >= 1000
            ) && (!isYogurtFactory))
        {
            isYogurtFactory = true;
            ImplementUpgrade(YogurtFactory);
        }

    }

    void ImplementUpgrade(GameObject upgrade)
    {
        float yPos;
        
        if (newUpgrade == null)
        {
            yPos = -250;
        }
        else
        {
            yPos = newUpgrade.transform.localPosition.y - 170 ;
        }
            
        newUpgrade = Instantiate(upgrade, GameObject.Find("UPGRADES").transform);
        newUpgrade.transform.localPosition = new Vector3(0, yPos);
    }
    
    
    
}
