//in this script  you will only need using UnityEngine as we just need the script to connect to unity
using UnityEngine;
//this public class doent inherit from MonoBehaviour
//this script is also referenced by other scripts but never attached to anything
public class Item
{
    //basic variables for items that we need are 
    #region Private Variables
    //Identification Number
    //Object Name
    //Value of the Object
    //Description of what the Object is
    //Icon that displays when that Object is in an Inventory
    //Mesh of that object when it is equipt or in the world
    //Enum ItemType which is the Type of object so we can classify them
    #endregion
    #region Constructors
    //A constructor is a bit of code that allows you to create objects from a class. You call the constructor by using the keyword new 
	//followed by the name of the class, followed by any necessary parameters.
    //the Item needs Identification Number, Object Name, Icon and Type
        //here we connect the parameters with the item variables
    #endregion
    #region Public Variables
    //here we are creating the public versions or our private variables that we can reference and connect to when interacting with items
    //public Identification Number 
	//get the private Identification Number
        //and set it to the value of our public Identification Number
    //public Name 
        //get the private Name
        //and set it to the value of our public Name

    //public Value 
        //get the private Value
        //and set it to the value of our public Value
    //public Description 
        //get the private Description
        //and set it to the value of our public Description
    //public Icon 
        //get the private Icon
        //and set it to the value of our public Icon
    //public Mesh 
        //get the private Mesh
        //and set it to the value of our public Mesh
    //public Type 
        //get the private Type
        //and set it to the value of our public Type
    #endregion
}
#region Enums
//The Global Enum ItemType that we have created categories in
#endregion
