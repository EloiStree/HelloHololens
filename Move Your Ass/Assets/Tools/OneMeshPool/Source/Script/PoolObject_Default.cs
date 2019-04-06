using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolObject_Default : PoolObject
{

  
    public override int GetRecyclablePriority()
    {
        return 0; // Exemple(SecondAlive, RangeOfThePlayer, IsInPlayerView)
    }

    public override bool IsActive()
    {
        return _isObjectActive;
    }   

    public override void SetAsActive(bool isActive)
    {

        IsObjectActive = isActive;
        if(m_stateListener!=null)
            m_stateListener(isActive);
    }

    public override bool IsRecyclable()
    {
        return !IsActive(); // Exemple( HasBeenDestroyed, IsFarEnoughOfThePlayer, IsInPlayerView ) 
    }

    public override void ResetToDefaultValue()
    {

        //Depending of your code, you can define here some value to reset
        //- Velocity to zero
        //- Life of the Unit
        //- Path coordinate
        //- What ever you want ;)
        // For my part, I prefer to use the OneMesh strategy only for visual effect and not the logic.

    }

    [Space(10)]
    [Header("Debug (Do not touch)", order = 11)]
    [SerializeField]
    private bool _isObjectActive;

    private bool IsObjectActive
    {
        get { return _isObjectActive; }
        set
        {
            bool oldValue = _isObjectActive, newValue = value;
            _isObjectActive = value;
            if (oldValue != newValue)
            {
                if (m_stateListener != null)
                    base.m_stateListener(newValue);
                _onActivation.Invoke(newValue);
               
            }
        }
    }
    
    [Serializable]
    public class OnActivationEvent : UnityEvent<bool>{ }
    [SerializeField]
    public OnActivationEvent _onActivation;
}


public interface PoolObjectInterface {
 
    /// <returns>Does the object is  visually active ?</returns>
    bool IsActive();

    /// <summary>
    /// Give possibility to activate or deactivate the object
    /// </summary>
    /// <param name="isActive">Is the object must be active or not ?</param>
    void SetAsActive(bool isActive);
    /// <returns>Does the object is reusable by the pool ?</returns>
    bool IsRecyclable();
    /// <returns>Determine if the object is important or not in the scen to be recycled 0=last recycled, maxint=first recycled ?</returns>
    int GetRecyclablePriority();

    /// <returns>What should be reset to zero when called by the pool</returns>
    void ResetToDefaultValue();
    /// <summary>
    /// Quick acces to the gameobject of the object
    /// </summary>
    GameObject gameObject { get; }
    /// <summary>
    /// Quick acces to the transform of the object
    /// </summary>
    Transform transform { get; }


    void AddStateListener(OnMeshChangeState stateListener);
}
public delegate void OnMeshChangeState(bool active);
public abstract class PoolObject : MonoBehaviour, PoolObjectInterface
{
    #region Initialize the PoolObject by default
    protected virtual void Awake()
    {
        SetRootAccess();
        SetAsActive(false);
    }
    public virtual void OnValidate()
    {
        SetRootAccess();
    }
    protected void SetRootAccess()
    {
        if (_transformDirectAccess==null)
            _transformDirectAccess = base.transform;

        if (_gameObjectDirectAccess == null)
            _gameObjectDirectAccess = base.gameObject;
    }
    #endregion

    /// <returns>Does the object is  visually active ?</returns>
    public abstract bool IsActive();

    /// <summary>
    /// Give possibility to activate or deactivate the object
    /// </summary>
    /// <param name="isActive">Is the object must be active or not ?</param>
    public abstract void SetAsActive(bool isActive);

    /// <returns>Does the object is reusable by the pool ?</returns>
    public abstract bool IsRecyclable();

    /// <returns>What should be reset to zero when called by the pool</returns>
    public abstract void ResetToDefaultValue();

    /// <returns>Determine if the object is important or not in the scen to be recycled 0=last recycled, maxint=first recycled ?</returns>
    public abstract int GetRecyclablePriority();

    internal static void TryToUnpool(GameObject detector)
    {
        PoolObjectInterface poolable = detector.GetComponent<PoolObjectInterface>();
        if (poolable != null)
        {
            poolable.SetAsActive(false);
        }
    }
    protected OnMeshChangeState m_stateListener;
    public  void AddStateListener(OnMeshChangeState stateListener)
    {
        m_stateListener += stateListener;
    }

    public GameObject gameObject { get { return this._gameObjectDirectAccess; } }
    public Transform transform { get { return this._transformDirectAccess; } }


    [Space(10)]
    [Header("Roots", order = 11)]
    [SerializeField]
    protected GameObject _gameObjectDirectAccess;

    [SerializeField]
    protected Transform _transformDirectAccess;
}
