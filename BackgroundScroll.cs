using UnityEngine;
using System.Collections;
        //scrolls the background texture
public class BackgroundScroll : MonoBehaviour {

    public float m_scrollSpeed;

    private Renderer m_texture;

    void Start()
    {
        m_texture = gameObject.GetComponent<Renderer>();
    }

 	void Update ()
    {
        Vector3 offset = new Vector3(Time.time * m_scrollSpeed, 0f, 0f);

        m_texture.material.mainTextureOffset = offset;
	}
}
