using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionBase : UIBase, UIInterface.IKeyboardAction
{
    protected enum TextEnum
    {
        OptionValue
    }

    protected enum ImageEnum
    {
        Background
    }

    protected struct Option
    {
        public string name;
        public System.Action action;
        public Option(string _name, System.Action _action)
        {
            name = _name;
            action = _action;
        }
    }

    private Color selectedColor; 
    private Color defaultColor;

    protected LinkedList<Option> optionList;
    protected LinkedListNode<Option> currentOption;

    virtual protected void Awake() 
    {
        optionList = new LinkedList<Option>();
        Bind<TMP_Text>(typeof(TextEnum));
        Bind<Image>(typeof(ImageEnum));
        selectedColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        defaultColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    }

    virtual protected void Start()
    {
        currentOption = optionList.First;
        Get<TMP_Text>((int)TextEnum.OptionValue)?.SetText(currentOption.Value.name ?? "NoTitle");
    }

    public void OnNavigate(Vector2 input)
    {
        if (optionList.Count > 0)
        {
            if (input.x > 0)
            {
                currentOption = currentOption.Next ?? currentOption.List.First;
            }
            else
            {
                currentOption = currentOption.Previous ?? currentOption.List.Last;
            }
            Get<TMP_Text>((int)TextEnum.OptionValue)?.SetText(currentOption.Value.name);
        }
    }

    public void OnSubmit()
    {
        currentOption.Value.action.Invoke();
    }

    public void Activate(bool isActivate)
    {
        if(isActivate)
        {
            Get<Image>((int)ImageEnum.Background).color = selectedColor;
        }
        else
        {
            Get<Image>((int)ImageEnum.Background).color = defaultColor;
        }
    }
}
