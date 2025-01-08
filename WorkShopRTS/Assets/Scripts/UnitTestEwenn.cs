using UnityEngine;

public class UnitTestEwenn : Unit
{
    public RessourcePool ressourcePool;

    void Start()
    {
        ressourcePool.Interact(this);
    }
}
