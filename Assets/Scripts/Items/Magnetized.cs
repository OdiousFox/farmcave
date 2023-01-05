using Unity.VisualScripting;
using UnityEngine;

public class Magnetized : MonoBehaviour {
    private GameObject destination;
    [SerializeField] private float power;
    private bool magnet = false;
    private bool inTrigger = false;
    private bool onFirstPass = false;
    private Rigidbody2D rb;

    private bool waitFirstCollect = false;

    public bool WaitFirstCollect {
        get => waitFirstCollect;
        set => waitFirstCollect = value;
    }
    
    public bool OnFirstPass {
        get => onFirstPass;
        set => onFirstPass = value;
    }

    private void OnEnable() {
        Inventory.OnBackPackFull += backPackState;
    }
    
    private void OnDisable() {
        Inventory.OnBackPackFull += backPackState;

    }

    private void backPackState(bool full) {
        if (full) {
            magnet = false;
        } else if (inTrigger) {
            magnet = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col) {
        inTrigger = true;
        if (col.gameObject.CompareTag("Magnet")) {
            if (!onFirstPass && !destination.gameObject.GetComponent<Inventory>().Full) {
                magnet = true;
            } else onFirstPass = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        inTrigger = false;
        magnet = false;
    }

    private void Start() {
        destination = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (magnet) {
            Vector2 targetDirection = (destination.transform.position - transform.position).normalized * Time.deltaTime;
            Vector2 previousDirection = rb.transform.forward;
            rb.velocity = (previousDirection + new Vector2(targetDirection.x, targetDirection.y)) * power;
        }
    }
}
