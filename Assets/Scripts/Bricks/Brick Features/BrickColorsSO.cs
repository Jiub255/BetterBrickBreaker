using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(menuName = "Scriptable Objects/Brick Colors SO", fileName = "New Brick Colors SO")]
public class BrickColorsSO : ScriptableObject
{
    [SerializeField, Tooltip("Top color is for 1 health, next for 2 health, etc.")]
    private List<Color> _colors;

    public List<Color> Colors { get { return _colors; } }
}