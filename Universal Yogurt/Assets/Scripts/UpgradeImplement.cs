using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeImplement : MonoBehaviour
{

    public Upgrades upgrade;

    private uint Price;
    private uint Amount;
    private uint ClickNumber;
    private uint AutoNumber;

    public TMP_Text Text_Name;
    public TMP_Text Text_Price;
    public TMP_Text Text_ClickNumber;
    public TMP_Text Text_AutoNumber;
    public TMP_Text Text_Amount;
    public Button MakeButton;
    // public string[] upgradeDescription;

    private bool isStartAuto = false;


    
    
    private void Start()
    {
        CheckNull();
        InitializeVariables();
        InitializeUpgrade();
    }

    private void Update()
    {
        UpgradeButtonStatus();
        UpgradeAmount();

    }
    
    void InitializeVariables()
    {
        Price = upgrade.upgradePrice;
        Amount = 0;
        ClickNumber = upgrade.upgradeClickNumber;
        AutoNumber = upgrade.upgradeAutoNumber;
    }
    void InitializeUpgrade()
    {
        Text_Name.text = upgrade.upgradeName;
        Text_Price.text = upgrade.upgradePrice.ToString();
        Text_ClickNumber.text = ClickNumber.ToString();
        Text_AutoNumber.text = AutoNumber.ToString() + "/s";
        Text_Amount.text = "0";
        InitializeButton();
    }

    void CheckNull()
    {
        if (upgrade == null)
        {
            throw new NullReferenceException();
        }

        if (MakeButton == null)
        {
            throw new NullReferenceException();
        }
    }

    void UpgradeButtonStatus()
    {
        if (GameManager.Yogurt_Drop_Number >= Price)
        {
            MakeButton.interactable = true;
        }
        else
        {
            MakeButton.interactable = false;
        }
    }

    void InitializeButton()
    {
        MakeButton.onClick.AddListener(()=> ClickMakeButton());
    }

    void ClickMakeButton()
    {
        GameManager.Yogurt_Drop_Number -= Price;
        Amount++;
        GameManager.clickAmount += ClickNumber;

        if (!isStartAuto)
        {
            StartCoroutine(AutoMake());
            isStartAuto = true;
        }
    }

    void UpgradeAmount()
    {
        Text_Amount.text = Amount.ToString();
    }


    IEnumerator AutoMake()
    {
        float upgradeSpeed = .2f;

        while (true)
        {
            GameManager.Yogurt_Drop_Number += (uint)(upgradeSpeed * AutoNumber * Amount);
            yield return new WaitForSeconds(upgradeSpeed);
        }
    }
    



}
