using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Message
{

    public static Message Unpack(object mess)
    {
        return (Message)mess;
    }

    public static object Pack(Message mess)
    {
        return (object)mess;
    }
}



interface IReceiver
{
    void ReceiveMessage(object mess);
    void SendMessage(object mess);
}

interface IBot {
    void LookArround(object arr);
    void SpeakTo(object friend);
    void FightWith(object enemy);
    void MoveTo(object pos);
}


public class Element : MonoBehaviour, IReceiver {
    private Graphic graphic;
    private Cell cell;
    public Vect2 pp;


    private void Awake()
    {
        graphic = new Graphic(transform);
    }

    public Graphic GetGraphic()
    {
        return graphic;
    }

    public Cell GetCell()
    {
        return cell;
    }

    public void Init(Vect2 pPos, bool iWantBeAGirl)
    {
        pp = pPos;
        if (iWantBeAGirl) cell = new Woman();
        else cell = new Man();
        graphic.Init(pp);
    }

    private void Update()
    {

    }

    public void ReceiveMessage(object mess) 
    {
        Color color = new Color(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        graphic.ChangeColor(color);
        print("receive...");

    }

    public void SendMessage(object mess) 
    {
        print("send");
    }

    public void LookArround(object arr) 
    {
        List<Element> elements = (List<Element>)arr;
        print("look arraound");
    
    }
    public void SpeakTo(object friend) { }
    public void FightWith(object enemy) { }
    public void MoveTo(object pos) 
    {
        Vect2 pos1 = (Vect2)pos;
        float time = new Vector2 (Mathf.Abs(pos1.x - pp.x) * World.settings.animatingMoveSpeed,
                                     Mathf.Abs(pos1.y - pp.y) * World.settings.animatingMoveSpeed).magnitude;
        graphic.MoveTo(new Movement(time, pos1));
    }

}

public class Movement
{
    public Movement(float time_, Vect2 point_)
    {
        time = time_;
        point = point_;
    }
    public float time;
    public Vect2 point;
}

public class Graphic:IBot{
    private Transform transform;
    private SpriteRenderer sprite;
    public Transform GetTransform()
    {
        return transform;
    }

    public Graphic(Transform tr)
    {
        transform = tr;
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        sprite.color = color;
    }

    public void SetPosition(Vect2 pos)
    {
        transform.position = World.graphic.GetPosition(pos);
    }

    public void Init(Vect2 pos)
    {
        SetPosition(pos);
        ChangeColor(new Color(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
    }

    public void LookArround(object arr) { }
    public void SpeakTo(object friend) { }
    public void FightWith(object enemy) { }
    public void MoveTo(object pos) 
    {
        Movement movement = (Movement)pos;
        Debug.Log(movement.point.ToString());
        iTween.MoveTo(transform.gameObject, iTween.Hash("position", World.graphic.GetPosition(movement.point), "time", movement.time));
    }

}

