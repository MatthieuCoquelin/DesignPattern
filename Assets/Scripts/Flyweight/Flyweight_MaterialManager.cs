using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When using the same material on lots of instances the program is object to memory leeks
/// To prevent from it we use a property comment to each instance, a material property : MaterialPropertyBlock
/// That is one of the forms of Flyweight Pattern
/// </summary>

public class Flyweight_MaterialManager : MonoBehaviour
{
    /// <summary>
    /// The lerped colors applied on our material
    /// </summary>
    [SerializeField]
    private Color m_color1, m_color2;

    /// <summary>
    /// Speed of the color variation
    /// </summary>
    [SerializeField]
    private float m_speed = 1;

    /// <summary>
    /// Starting color value from -1 to 1 (-1: blue ; 1: green)
    /// </summary>
    [SerializeField]
    private float m_offset;

    /// <summary>
    /// Renderer of our material
    /// </summary>
    private Renderer m_renderer;

    /// <summary>
    /// Property of the material
    /// </summary>
    private MaterialPropertyBlock m_materialPropertyBlock;

    /// <summary>
    /// Prepare the material property
    /// </summary>
    private void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_materialPropertyBlock = new MaterialPropertyBlock();
    }

    /// <summary>
    /// Modifie the property block value
    /// </summary>
    private void Update()
    {
        // Get the current value of the material properties in the renderer
        m_renderer.GetPropertyBlock(m_materialPropertyBlock);
        // Assign our new value
        m_materialPropertyBlock.SetColor("_Color", Color.Lerp(m_color1, m_color2, (Mathf.Sin(Time.time * m_speed + m_offset) + 1) / 2f));
        // Apply the edited values to the renderer
        m_renderer.SetPropertyBlock(m_materialPropertyBlock);
    }
}