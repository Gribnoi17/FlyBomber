using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100;
    [SerializeField] public Transform laserFirePoint;
    [SerializeField] public LineRenderer m_lineRenderer;
    [SerializeField] public GameObject target;
    
    Transform m_transform;
    private bool shoot = true;
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Boss.health < 40 && shoot)
        {
            ShootLaser();
            
        }
    }
    public void ShootLaser()
    {
        RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.up);
        if (_hit.transform.position == target.transform.position)
        {
            Player.health--;
        }
        Draw2DRay(laserFirePoint.position, _hit.point);
        StartCoroutine(WaitForShootLaser());
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)

    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
    private IEnumerator WaitForShootLaser()
    {
        yield return new WaitForSeconds(3f);
        shoot = false;
        m_lineRenderer.enabled = false;
        
        yield return new WaitForSeconds(3f);
        m_lineRenderer.enabled = true;
        shoot = true;

    }

}
