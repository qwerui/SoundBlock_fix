using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    protected RectTransform rect;
    protected Image image;
    protected float speed;

    private Note _note;
    public Note note
    {
        set
        {
            _note = value;
        }
        get 
        {
            return _note;
        }
    }

    void Awake()
    {
        speed = GameManager.Instance.noteSpeed;
        TryGetComponent<RectTransform>(out rect);
        TryGetComponent<Image>(out image);

    }

    [System.Obsolete]
    public virtual void SetColor(float r, float g, float b)
    {
        image.color = new Color(r,g,b,1f);
    }

    public virtual void SetColor(Color color)
    {
        image.color = color;
    }
    public virtual void SetPosition(Note n, Key key)
    {
        rect.anchoredPosition = new Vector2(0, n.y*speed);
        note = n;
    }
}