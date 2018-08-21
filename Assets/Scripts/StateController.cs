using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stateless;

public class StateController : MonoBehaviour
{
  enum Trigger
  {
    Jump,
    Fall,
    Land,
    BackToNormal
  }

  enum State
  {
    Normal,
    Jumping,
    Falling,
    Landing
  }

  StateMachine<State, Trigger> _machine;

  void Start()
  {
    _machine = new StateMachine<State, Trigger>(State.Normal);

    _machine.Configure(State.Normal)
      .Permit(Trigger.Fall, State.Falling)
      .Permit(Trigger.Jump, State.Jumping);

    _machine.Configure(State.Jumping)
      .Permit(Trigger.Fall, State.Falling);

    _machine.Configure(State.Falling)
      .Permit(Trigger.Land, State.Landing);

    _machine.Configure(State.Landing)
      .Permit(Trigger.BackToNormal, State.Normal);
  }

  void Update()
  {
    States.Base handler = GetComponent(string.Format("States.{}", _machine.State.ToString())) as States.Base;

    if(handler)
    {
      handler.handleInput();
      handler.updateCharacter();
    }
  }
}
