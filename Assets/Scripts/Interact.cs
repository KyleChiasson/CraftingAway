using UnityEngine;

public abstract class Interact : MonoBehaviour
{
    public GameObject InteractNotifier;
    private float timer = 0.0f;
    private void Update()
    {
        if (!InteractNotifier.activeSelf && Vector2.Distance(transform.position, CharacterControler.Instance.transform.position) < 3)
            InteractNotifier.SetActive(true);
        else if (InteractNotifier.activeSelf && Vector2.Distance(transform.position, CharacterControler.Instance.transform.position) >= 3)
        {
            InteractNotifier.SetActive(false);
            timer = 0.0f;
        }
        if(InteractNotifier.activeSelf && Input.GetKey(KeyCode.E))
            timer += Time.deltaTime;
        if(timer >= 1f)
        {
            Interacted();
            timer = .5f;
        }
        if (Input.GetKeyUp(KeyCode.E))
            timer = 0.0f;
    }
    public abstract void Interacted();
}