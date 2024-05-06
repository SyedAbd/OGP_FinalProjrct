using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName ="New weapon", menuName = "Weapon")]

public class Guns : ScriptableObject
{
    public GameObject gun;
    public new string name;
    public int magazine;
    public int damage;
    public float fireRate;
    public bool auto;
}
