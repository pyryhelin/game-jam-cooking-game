using UnityEngine;
public static class VariableManager
{
    //Used to store instance data (variables etc.) between scenes.
    //This could be used for general data, and create a separate manager
    //for example player stats.

    //Doesn't need to be assigned to gameObejct as this is static 
    //class, and because of that this class cannot inherit the
    //monobehaviour class.

    //Example of how to implement: 

    private static int Example;
    public static int example
    {
        get
        {
            return Example;
        }
        set
        {
            //can add validation code such as:
            //if(value > 1)
            //  example = value;
            Example = value;
        }
    }
}



//used to store information related to player.
public static class PlayerStats
{


    //store player position
    private static Vector3 Position;
    public static Vector3 position
    {
        get
        {
            return Position;
        }
        set
        {
            Position = value;
        }
    }
}

public static class KitchenSceneObjectReferences{
    
    
    private static GameObject Player;
    public static GameObject player
    {
        get
        {
            return Player;
        }
        set
        {
            Player = value;
        }
    }

    private static GameObject Camera;
    public static GameObject camera
    {
        get
        {
            return Camera;
        }
        set
        {
            Camera = value;
        }
    }
}
