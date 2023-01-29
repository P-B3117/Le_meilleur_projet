using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Filename : UniversalVariable
 * 
 * Goal : Provides a public single instance of universal physic constants, those constants will be used in every physics based calculations
 * 
 * Requirements : NaN
 */
public static class UniversalVariable
{
    private static float gravity = 9.81f;



    public static float GetGravity() 
    {
        return gravity;
    }
}
