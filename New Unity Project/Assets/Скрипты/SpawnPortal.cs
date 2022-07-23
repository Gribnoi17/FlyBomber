using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
    
{
    [SerializeField] GameObject portal;
    public Transform PotralSpawn;
    [SerializeField] float timeforExistPortal;
    [SerializeField] float timeforDelayExitPortal;
    [SerializeField] bool portalopen;
    [SerializeField] float delayforopen;
    void Start()
    {
        
        StartCoroutine(WaitForSpawn());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator WaitForSpawn()
    {
        if (portalopen==true)
        {
            yield return new WaitForSeconds(delayforopen);
            var newportal = Instantiate(portal, PotralSpawn.position, PotralSpawn.rotation);
            yield return new WaitForSeconds(timeforExistPortal);
            Destroy(newportal);
            
        }
        else if (portalopen == false)
        {
            yield return new WaitForSeconds(timeforDelayExitPortal);
            var newpotral2 = Instantiate(portal, PotralSpawn.position, PotralSpawn.rotation);
            yield return new WaitForSeconds(timeforExistPortal);
            Destroy(newpotral2);
            
        }
    }
        
        
    
    
}
