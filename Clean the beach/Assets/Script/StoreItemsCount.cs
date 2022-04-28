using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreItemsCount : MonoBehaviour
{
    public int metal;
    public int Plastic;
    public int Paper;

    public TMP_Text MetalCount;
    public TMP_Text PlasticCount;
    public TMP_Text PaperCount;
    
    public TMP_Text BooksCount;
    public TMP_Text FlowerVaseCount;
    public TMP_Text MetalSheetCount;


    int metalCost, PlasticCost, paperCost;
    public int Books = 0;
    public int FlowerVase = 0;
    public int MetalSheet = 0;


    // Start is called before the first frame update
    void Start()
    {
        metal = PlayerPrefs.GetInt("MetalNum", 0);
        Plastic = PlayerPrefs.GetInt("PlasticNum", 0);
        Paper = PlayerPrefs.GetInt("PaperNum", 0);


        Books =PlayerPrefs.GetInt("BooksCount",0);
        FlowerVase =PlayerPrefs.GetInt("FlowerVaseCount",0);
        MetalSheet= PlayerPrefs.GetInt("MetalSheetCount",0);

        BooksCount.text = Books.ToString();
        FlowerVaseCount.text = FlowerVase.ToString();
        MetalSheetCount.text = MetalSheet.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        MetalCount.text = metal.ToString();
        PlasticCount.text = Plastic.ToString();
        PaperCount.text = Paper.ToString();
    }

    public void Recycle(string name)
    {
        
        if (name.Equals("Books"))
        {
            metalCost = 0;
            PlasticCost = 1;
            paperCost = 1;
            Debug.Log("GOod");
        }
        else if (name.Equals("Flower Vase"))
        {
            metalCost = 5;
            PlasticCost = 3;
            paperCost = 2;
            Debug.Log("GOod");
        }
        else if (name.Equals("MetalSheet"))
        {
            metalCost = 2;
            PlasticCost = 3;
            paperCost = 1;
            Debug.Log("GOod");
        }

        if(metal>= metalCost && Plastic >= PlasticCost && Paper >= paperCost)
        {

            if (name.Equals("Books"))
                Books++;
            else if (name.Equals("Flower Vase"))
                FlowerVase++;
            else if (name.Equals("MetalSheet"))
                MetalSheet++;

            metal -= metalCost;
            Plastic -= PlasticCost;
            Paper -= paperCost;

            PlayerPrefs.SetInt("MetalNum", metal);
            PlayerPrefs.SetInt("PlasticNum", Plastic);
            PlayerPrefs.SetInt("PaperNum", Paper);
         
        }
        BooksCount.text=Books.ToString();
        FlowerVaseCount.text=FlowerVase.ToString();
        MetalSheetCount.text=MetalSheet.ToString();

        PlayerPrefs.SetInt("BooksCount", Books);
        PlayerPrefs.SetInt("FlowerVaseCount", FlowerVase);
        PlayerPrefs.SetInt("MetalSheetCount", MetalSheet);
    }

}
