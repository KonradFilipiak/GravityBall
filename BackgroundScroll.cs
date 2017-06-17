using UnityEngine;
using System.Collections;
    // Scrolls the background texture
public class BackgroundScroll : MonoBehaviour {

    public float scrollSpeed;

    private Renderer texture;

    void Start()
    {
        texture = gameObject.GetComponent<Renderer>();
    }

 	void Update ()
    {
        Vector3 offset = new Vector3(Time.time * scrollSpeed, 0f, 0f);

        texture.material.mainTextureOffset = offset;
	}
}
