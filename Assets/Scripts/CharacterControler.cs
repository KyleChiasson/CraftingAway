using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControler : Singleton<CharacterControler>
{
    public float Speed = 5f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Vector2 translate = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            translate.y += 1;
        if (Input.GetKey(KeyCode.S))
            translate.y -= 1;
        if (Input.GetKey(KeyCode.A))
            translate.x -= 1;
        if (Input.GetKey(KeyCode.D))
            translate.x += 1;
        translate *= Speed * Time.deltaTime;
        translate.y *= .5f;
        rb.AddForce(translate);
        if (translate == Vector2.zero)
            rb.drag = 10;
        else rb.drag = 1;
    }
}