using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components

    public Animator anim { get; private set; }

    public Rigidbody rb { get; private set; }

    #endregion


    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        
    }

    public virtual void Die()
    {

    }
}
