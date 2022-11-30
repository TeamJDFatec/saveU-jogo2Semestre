using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoInfinito : MonoBehaviour
{

    public Renderer renderer;
    public float velocidade;

    private Material material;
    private Vector2 offsetMaterial;

    // Start is called before the first frame update
    void Start()
    {
        material = renderer.material;
        offsetMaterial = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offsetMaterial.y = offsetMaterial.y - velocidade * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offsetMaterial);
    }
}
