using UnityEngine;
using System.Collections;


public class CellGraphicController : MonoBehaviour
{
    public GameObject elementPrefab;

    private SpriteRenderer borderSprite;
    private SpriteRenderer elementSprite;
    public SpriteRenderer background;


    public bool grid = true;
    public bool automaticOffset = true;
    public Vector2 scale = new Vector2(3f, 3f);
    public Vector2 border = new Vector3(0.3f, 0.3f);
    public Color borderColour;
    public Color elementColor;

    Vector3 elementSize = Vector3.zero;
    Vector3 elementPos = Vector3.zero;

    [System.NonSerialized]
    public Vector2 start;
    public const float pictureScale = 0.1f;//1 to 100

    [System.NonSerialized]
    GameObject gridObject;

	void Awake () {


	}

    public void OrganiseField(out GameObject[,] matrix) {
        elementPrefab.SetActive(true);
        Initialize();

        matrix = new GameObject[World.settings.countX, World.settings.countX];
        start = CalculateCenterPosition();
        for (int i = 0; i < Settings.link.countX; i++)
            for (int j = 0; j < Settings.link.countX; j++)
            {
                matrix[i, j] = CreatePositionElement(start, new Vect2(i, j));
                matrix[i, j].GetComponent<Element>().pp = new Vect2(i, j);
                matrix[i, j].transform.GetChild(0).parent = gridObject.transform;
                matrix[i, j].transform.DetachChildren();
            }

        elementPrefab.SetActive(false);
    }

    private Vector2 CalculateOffset()
    {
        return new Vector2(Settings.link.countX * (scale.x * 1.5f * pictureScale + border.x) - border.x - scale.x * 1.5f * pictureScale,
                     Settings.link.countX * (scale.y * 1.5f * pictureScale + border.y) - border.y - scale.y * 1.5f * pictureScale);
    }

    private Vector2 CalculateCenterPosition() {
        Vector2 offset = CalculateOffset();
        return new Vector3(-offset.x * 0.5f, offset.y * 0.5f);
    }

   private void Initialize() {
        gridObject = new GameObject("Grid");
        borderSprite = elementPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>();
        elementSprite = elementPrefab.transform.GetComponent<SpriteRenderer>();
        borderSprite.color = borderColour;
        //borderSprite.gameObject.transform.localScale = scale;
        elementSprite.transform.localScale = scale;
        elementSprite.color = elementColor;
    }
   
    private GameObject CreatePositionElement(Vector2 start,Vect2 vect) {
        GameObject element = (GameObject)Instantiate(elementPrefab);
        element.transform.position = GetPosition(start,vect);
        return element;
    }


    public Vector2 GetPosition(Vect2 vect) {
        return new Vector2(vect.x * (scale.x * 1.5f * pictureScale + border.x) + start.x,
                           vect.y * -(scale.y * 1.5f * pictureScale + border.y) + start.y);
    }

    public Vector2 GetPosition(Vector2 start,Vect2 vect)
    {
        return new Vector2(vect.x * (scale.x * 1.5f * pictureScale + border.x) + start.x, 
                           vect.y *-(scale.y * 1.5f * pictureScale + border.y) + start.y);
    }

}