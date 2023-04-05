using UnityEngine;
using UnityEngine.UI;

public abstract class Interact : MonoBehaviour
{
    public Image InteractNotifier;
    private float timer = 0.0f;
    protected void Update()
    {
        if (!InteractNotifier.gameObject.activeSelf && Vector2.Distance(transform.position, CharacterControler.Instance.transform.position) < 3)
            InteractNotifier.gameObject.SetActive(true);
        else if (InteractNotifier.gameObject.activeSelf && Vector2.Distance(transform.position, CharacterControler.Instance.transform.position) >= 3)
        {
            InteractNotifier.gameObject.SetActive(false);
            timer = 0.0f;
        }
        if(InteractNotifier.gameObject.activeSelf && Input.GetKey(KeyCode.E))
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