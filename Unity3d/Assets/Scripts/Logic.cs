using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Logic : MonoBehaviour {


    public static List<Element> cells;
    public static GameObject[,] cellsArray;

    void Awake() {
        /*var value = 255;
        DNK.Encrypt(ref value,2);
        print(""+value);
        DNK.Decrypt(ref value, 2);
        print("" + value);*/

        World.graphic.OrganiseField(out cellsArray);
        cells = World.GetDataFromTwoDimArray(cellsArray);
        StartCoroutine(BaseUpdate());
    }

    void Start() {
        for (int i = 0; i < Settings.link.womansStart; i++)
            cells[i].Init(new Vect2(Random.Range(0, Settings.link.countX), Random.Range(0, Settings.link.countX)), true);
        for (int i = 0; i < Settings.link.menStart; i++)
            cells[i].Init(new Vect2(Random.Range(0, Settings.link.countX), Random.Range(0, Settings.link.countX)), false);
    }

    private IEnumerator BaseUpdate() {
        while (true)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].LookArround(cells);
            }

            yield return new WaitForSeconds(Settings.link.updateTime);
            cells[Random.Range(0,cells.Count)].MoveTo(new Vect2(Random.Range(0,16),Random.Range(0,16)));
        }
    }//base Update
	
}
