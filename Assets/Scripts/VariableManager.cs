public static class VariableManager
{
    //Used to store instance data (variables etc.) between scenes.
    //This could be used for general data, and create a separate manager
    //for example player stats.

    //Doesn't need to be assigned to gameObejct as this is static 
    //class, and because of that this class cannot inherit the
    //monobehaviour class.
    
    //Example of how to implement: 
    public static int example {
        get
        {
            return example;
        }
        set
        {
            //can add validation code such as.
            //if(value > 1)
            //  example = value;
            example = value;
        }
    } 
}
