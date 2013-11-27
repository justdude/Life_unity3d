using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellHandler : MonoBehaviour {

    List<Vect2> filled;


    public void GenerateNumbers() {
        for (int i = 0; i < World.settings.countX; i++)
            for (int j = 0; j < World.settings.countX; j++)
                filled [World.ConvertArrToL(i, j, World.settings.countX)] = new Vect2(i,j);
    }



    private bool ValueExist(Vect2 vect) {
        return filled.Exists(p => p.x == vect.x && p.y == vect.y);
    }

    public void CreateMen(List<Cell> cells, ref GameObject[,] field)
    {
        for (int i = 0; i < World.settings.menStart; i++)
        {
            int x = Random.Range(0, World.settings.countX);
            int y = Random.Range(0, World.settings.countX);

        }

    
    }
}
