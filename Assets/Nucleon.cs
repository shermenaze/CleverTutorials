using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour
{
    public float AttractionForce;

    int fps;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddForce(transform.localPosition * -AttractionForce);
    }
}
