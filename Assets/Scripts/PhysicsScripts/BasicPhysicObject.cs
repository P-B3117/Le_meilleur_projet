using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Filename : BasicPhysicObjects
 * 
 * Goal : Encapsulates and calculates physics properties of the object
 * 
 * Requirements : Attach this script to physical objects of the Scene
 */
public class BasicPhysicObject : MonoBehaviour
{
    [SerializeField]
    Transform centerOfMass;
    [SerializeField]
    float mass = 5;
    [SerializeField]
    float dynamicFriction = 0.5f;
    [SerializeField]
    float staticFriction = 0.5f;
    [SerializeField]
    float bounciness = 0.5f;

    Vector3 resultingForce;
    Collider objectCollider;



}
