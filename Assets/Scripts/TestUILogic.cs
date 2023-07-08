using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUILogic : MonoBehaviour
{
    [SerializeField]
    GameObject m_sphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySphere()
    {
        Instantiate(m_sphere, m_sphere.transform);
        Destroy(m_sphere);
    }
}
