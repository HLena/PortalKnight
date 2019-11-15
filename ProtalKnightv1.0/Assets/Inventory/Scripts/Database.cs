using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class DatabaseBlock : ScriptableObject
{
    [System.Serializable]
    public struct CubeDatabase
    {
        public int idBlock;
        public string nameBlock;
        public Sprite spriteBlocl;
        public int resistencia;
        //public Use use
    }

    /*public enum Use
    {
        acumulable,
        equipable,
        consumible
    }*/

    public CubeDatabase[] DB;

}
