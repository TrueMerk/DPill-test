using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : SingleTone<ServiceLocator>
{
    private IDictionary<Type, MonoBehaviour> _serviceReferences;

    protected void Awake()
    {
        SingletonBuilder(this);
        _serviceReferences = new Dictionary<Type, MonoBehaviour>();
    }

    public T GetService<T>() where T : MonoBehaviour, new()
    {
        UnityEngine.Assertions.Assert.IsNotNull(_serviceReferences,"Someone has requested a service prior to the locator`s initialization");

        var serviceLocated = _serviceReferences.ContainsKey(typeof(T));
        if (!serviceLocated)
        {
            _serviceReferences.Add( typeof(T),FindObjectOfType<T>());
        }
        
        UnityEngine.Assertions.Assert.IsTrue(_serviceReferences.ContainsKey(typeof(T)),"Could not find service");
        var service = (T) _serviceReferences[typeof(T)];
        UnityEngine.Assertions.Assert.IsNotNull( service,typeof(T).ToString()+ " could not be found.");
        return service;
    }
}
