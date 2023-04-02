using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public string Name;
    public int Min;
    public int Max;
    public float Chance;
    public Sprite Sprite;
}