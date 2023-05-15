using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static uint Yogurt_Drop_Number = 0;
    public static uint clickAmount = 1;
    
    public Button Button_Yogurt_Drop;

    public TMP_Text Text_Yogurt_Drop_Number;




    void Start()
    {
        // Initialize Buttons
        InitializeYogurtButton();
        
        // Initialize Texts
        
    }
    void Update()
    {
        ShowYogurtNumber();
    }
    
    
    
    
    
    
    
    // Initialize the first Yogurt Button
    void InitializeYogurtButton()
    {
        if (Button_Yogurt_Drop == null)
        {
            Button_Yogurt_Drop = GameObject.Find("Button_Yogurt_Drop").GetComponent<Button>();
        }
        Button_Yogurt_Drop.onClick.AddListener(()=> AddYogurtDrop());
    }

    // Button Click - Add one Yogurt
    void AddYogurtDrop()
    {
        Yogurt_Drop_Number += clickAmount;
        float scale = Button_Yogurt_Drop.gameObject.transform.localScale.x;
        
        // Other operations
        Button_Yogurt_Drop.gameObject.transform.DOScale(Button_Yogurt_Drop.gameObject.transform.localScale.x*1.2f, 0.05f).
            OnComplete(()=> 
                Button_Yogurt_Drop.gameObject.transform.DOScale(scale,0.05f));
    }

    void InitializeYogurtNumberText()
    {
        if (Text_Yogurt_Drop_Number == null)
        {
            Text_Yogurt_Drop_Number = GameObject.Find("Text_Yogurt_Drop_Number").GetComponent<TMP_Text>();
        }
    }

    void ShowYogurtNumber()
    {
        Text_Yogurt_Drop_Number.text = Yogurt_Drop_Number.ToString();
    }

    
    
    
    
    
}
