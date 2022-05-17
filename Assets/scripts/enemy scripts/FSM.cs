using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FSM<T> where T : Enum
{
    T _currentState;
    Dictionary<T, State> States;

    public FSM(T initialState)
    {
        States = new Dictionary<T, State>();
        foreach (T estat in Enum.GetValues(typeof(T)))
        {
            States.Add(estat, new State());
        }
        _currentState = initialState;
    }

    public void Update()
    {
        States[_currentState].OnStay?.Invoke();
    }
    public void ChangeState(T newState)
    {
        States[_currentState].OnExit?.Invoke();
        States[newState].OnEnter?.Invoke();
        _currentState = newState;
    }

    public void SetOnEnter(T state, Action f)
    {
        States[state].OnEnter = f;
    }

    public void SetOnExit(T state, Action f)
    {
        States[state].OnExit = f;
    }

    public void SetOnStay(T state, Action f)
    {
        States[state].OnStay = f;
    }
}
