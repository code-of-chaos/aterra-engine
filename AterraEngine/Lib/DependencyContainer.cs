// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace AterraEngine.Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IDependencyContainer {
    void register<TInterface, TImplementation>() where TImplementation : TInterface;
    T resolve<T>();

    static IDependencyContainer instance = null!;
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DependencyContainer : IDependencyContainer {
    private static DependencyContainer? _instance; 
    private readonly Dictionary<Type, Type> _types = new Dictionary<Type, Type>();
    private readonly Dictionary<Type, object> _singletons = new Dictionary<Type, object>();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    // Private constructor locks it from being init from anywhere else
    private DependencyContainer(){}
    
    public static DependencyContainer instance {
        get { return _instance ??= new DependencyContainer(); }
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Register and get instances
    // -----------------------------------------------------------------------------------------------------------------
    public void register<TInterface, TImplementation>() where TImplementation : TInterface {
        Type interfaceType = typeof(TInterface);
        Type implementationType = typeof(TImplementation);

        _types.TryAdd(interfaceType, implementationType);
    }

    public TInterface resolve<TInterface>() {
        Type interfaceType = typeof(TInterface);

        if (!_types.ContainsKey(interfaceType)) {
            throw new InvalidOperationException($"Type {interfaceType} not found");
        }

        TInterface object_instance;
        
        if (!_singletons.ContainsKey(interfaceType)){
            Type implementationType = _types[interfaceType];
            object_instance = (TInterface)Activator.CreateInstance(implementationType)!;
            _singletons.TryAdd(interfaceType, object_instance);
        }
        else {
            object_instance = (TInterface)_singletons[interfaceType];
        }
        
        return object_instance;
    }
    
}