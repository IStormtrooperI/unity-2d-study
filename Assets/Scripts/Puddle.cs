using System.Collections;
using UnityEngine;

public class Puddle : CanvasShow
{
    public delegate void TriggerEvent();

    public static event TriggerEvent PickUp;
    public static event TriggerEvent PickDown;

    private bool mopIsReady;

    private SpriteRenderer _renderer;

    void Start()
    {
        Mop.PickUp += PickUpMop;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void PickUpMop()
    {
        mopIsReady = true;
    }

    private void Update()
    {
        if (mopIsReady && isTrigger && Input.GetKeyDown(KeyCode.F) && _renderer.enabled)
        {
            PickUp?.Invoke();
            StartCoroutine(Up());
            _renderer.enabled = false;
            bloced = true;
        }
    }

    private IEnumerator Up()
    {
        yield return new WaitForSeconds(45f);
        PickDown?.Invoke();
        _renderer.enabled = true;
        bloced = false;
    }
}