using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public SceneHandler sceneHandler;
    public BoxCollider boxCollider;
    public GameObject portalReactVortex;
    public bool bossScene = false;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        if(portalReactVortex!=null)portalReactVortex.SetActive(false);
        sceneHandler = GameObject.FindWithTag("SceneHandler").GetComponent<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPortal()
    {
        FindObjectOfType<SoundManager>().Play("Portal");
        boxCollider.enabled = true;
        if (portalReactVortex != null) portalReactVortex.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneHandler.LoadNextLevel();
        }
    }
}