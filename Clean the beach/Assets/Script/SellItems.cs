using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellItems : MonoBehaviour
{
    [SerializeField]
    int MetalSheet = 0;
    [SerializeField]
    int Books = 0;
    [SerializeField]
    int FlowerVase = 0;

    int MetalSheetCost;
    int BooksCost;
    int FlowerVaseCost;

    public GameObject JohnPanel;
    public GameObject MiraPanel;

    public int Money=10;
    public TMP_Text MoneyValue;
    public TMP_Text BooksCount;
    public TMP_Text FlowerVaseCount;
    public TMP_Text metalSheetCount;

    // Start is called before the first frame update
    void Start()
    {
        Money = PlayerPrefs.GetInt("MoneyValue", 0);

        MetalSheet = PlayerPrefs.GetInt("MetalSheetCount", 0);
        Books = PlayerPrefs.GetInt("BooksCount", 0);
        FlowerVase = PlayerPrefs.GetInt("FlowerVaseCount", 0);
        MoneyValue.text = Money.ToString();

        BooksCount.text = Books.ToString();
        FlowerVaseCount.text = FlowerVase.ToString();
        metalSheetCount.text = MetalSheet.ToString();

    }

    public void Sell(string name)
    {
       
        if (name.Equals("John"))
        {
            MetalSheetCost = 3;
            BooksCost = 2;
            FlowerVaseCost = 1;
           
        }
        else if (name.Equals("Mira"))
        {
            MetalSheetCost = 0;
            BooksCost = 3;
            FlowerVaseCost = 0;
           
        }
  

        if (MetalSheet >= MetalSheetCost && FlowerVase >= FlowerVaseCost && Books >= BooksCost)
        {

            if (name.Equals("John"))
            {
                JohnPanel.SetActive(false);
                Money += 100;
            }   
            else if (name.Equals("Mira"))
            {
                MiraPanel.SetActive(false);
                Money += 50;
            }              
            MetalSheet -= MetalSheetCost;
            FlowerVase -= FlowerVaseCost;
            Books -= BooksCost;
            Debug.Log("Sold");

          

            PlayerPrefs.SetInt("MetalSheetCount", MetalSheet);
            PlayerPrefs.SetInt("FlowerVaseCount", FlowerVase);
            PlayerPrefs.SetInt("BooksCount", Books);

           // MoneyValue.text = Money.ToString();
            PlayerPrefs.SetInt("MoneyValue", Money);
            MoneyValue.text = PlayerPrefs.GetInt("MoneyValue", 0).ToString();

            BooksCount.text = Books.ToString();
            FlowerVaseCount.text = FlowerVase.ToString();
            metalSheetCount.text = MetalSheet.ToString();
        }

        /*PlayerPrefs.SetInt("BooksCount", Books);
        PlayerPrefs.SetInt("FlowerVaseCount", FlowerVase);
        PlayerPrefs.SetInt("MetalSheetCount", MetalSheet);*/
    }
}
