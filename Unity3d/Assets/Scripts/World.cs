using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {

    public static Settings settings;
    public static CellGraphicController graphic;

    public Settings settings_;
    public CellGraphicController graphic_;

    void Awake() {
        settings = settings_;
        graphic = graphic_;
    }

    public static List<Element>  GetDataFromTwoDimArray(GameObject[,] elements)
    {
        int n = elements.GetLength(0);
        int m = elements.GetLength(1);
        List<Element> elementsL = new List<Element>();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                elementsL.Add(elements[i, j].GetComponent<Element>());
            }
        return elementsL;
    }

    public static Vect2 ConvertLToArr(int i, int I, int J)
    {
        return new Vect2(i / I, i % J);
    }

    public static Vect2 ConvertLToArr(int i, int I)
    {
        return new Vect2(i / I, i % I);
    }

    public static int ConvertArrToL(int i, int j, int I)
    {
        return i*I + j;
    }
}
