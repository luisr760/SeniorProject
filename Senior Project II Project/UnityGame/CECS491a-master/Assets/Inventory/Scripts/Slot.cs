using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    #region variables

    /// <summary>
    /// The items that the slot contains
    /// </summary>
    private Stack<Item> items;

    /// <summary>
    /// Indicates the number of items stacked on the slot
    /// </summary>
    public Text stackTxt;

    /// <summary>
    /// The slot's empty sprite
    /// </summary>
    public Sprite slotEmpty;

    /// <summary>
    /// The slot's highlighted sprite
    /// </summary>
    public Sprite slotHighlight;

    #endregion

    #region properties

    /// <summary>
    /// A property for accessing the stack of items
    /// </summary>
    public Stack<Item> Items
    {
        get { return items; }
        set { items = value; }
    }

    /// <summary>
    /// Indicates if the slot is empty
    /// </summary>
    public bool IsEmpty
    {
        get { return items.Count == 0; }
    }

    /// <summary>
    /// Indicates if the slot is avaialble for stacking more items
    /// </summary>
    public bool IsAvailable
    {
        get {return CurrentItem.maxSize > items.Count; }
    }
    
    /// <summary>
    /// Returns the current item in the stack
    /// </summary>
    public Item CurrentItem
    {
        get { return items.Peek(); }
    }

    #endregion  

    // Use this for initialization
	void Start () 
    {   
        //Instantiates the items stack
        items = new Stack<Item>();

        //Creates a reference to the slot slot's recttransform
        RectTransform slotRect = GetComponent<RectTransform>();

        //Calculates the scalefactor of the text by taking 60% of the slots width
        int txtScleFactor = (int)(slotRect.sizeDelta.x * 0.60);
    
	}
	
    /// <summary>
    /// Adds a single item to th inventory
    /// </summary>
    /// <param name="item">The item to add</param>
    public void AddItem(Item item)
    {
        items.Push(item); //Adds the item to the stack

        ChangeSprite(item.spriteNeutral, item.spriteHighlighted); //Changes the sprite so that it reflects the item the slot is occupied by
    }

    /// <summary>
    /// Adds a stack of items to the slot
    /// </summary>
    /// <param name="items">The stack of items to add</param>
    public void AddItems(Stack<Item> items)
    {
        this.items = new Stack<Item>(items); //Adds the stack of items to the slot

        ChangeSprite(CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted); //Changes the sprite so that it reflects the item the slot is occupied by
    }

    /// <summary>
    /// Changes the sprite of a slot
    /// </summary>
    /// <param name="neutral">The neutral sprite</param>
    /// <param name="highlight">The highlighted sprite</param>
    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        //Sets the neutralsprite
        GetComponent<Image>().sprite = neutral;

        //Creates a spriteState, so that we can change the sprites of the different states
        SpriteState st = new SpriteState();
        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;

        //Sets the sprite state
        GetComponent<Button>().spriteState = st;
    }

    /// <summary>
    /// Uses an item on the slot.
    /// </summary>
    private void UseItem()
    {
        if (!IsEmpty) //If there is an item on the slot
        {
            items.Peek().Use();

            if (IsEmpty) //Checks if we just removed the last item from the inventory
            {
                ChangeSprite(slotEmpty, slotHighlight); //Changes the sprite to empty if the slot is empty

                Inventory.EmptySlots++; //Adds 1 to the amount of empty slots
            }
        }
    }

    /// <summary>
    /// Clears the slot
    /// </summary>
    public void ClearSlot()
    {   
        //Clears all items on the slot
        items.Clear();

        //Changes the sprite to empty
        ChangeSprite(slotEmpty, slotHighlight);
	
    }

    /// <summary>
    /// Handles OnPointer events
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {   
        //If the right mousebutton was clicked
        if (eventData.button == PointerEventData.InputButton.Right) 
        {
            //Uses an item on the slot
            UseItem();
        }
    }
}
