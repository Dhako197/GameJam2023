using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private float ScrollSpeed=1000f;
    private float Offset;
    private Material mat;

    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        mat= GetComponent<Renderer>().material;
    }

    void Update()
    {
        Offset += (rb.velocity.y)/ ScrollSpeed;
        //Offset += (Time.deltaTime * ScrollSpeed)/10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0,Offset));
    }
}
