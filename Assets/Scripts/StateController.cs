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

  public StateMachine<State, Trigger> machine;
  protected Dictionnary<State, States.Base> _stateHandlers

  void Start()
  {
    machine = new StateMachine<State, Trigger>(State.Normal);

    machine.Configure(State.Normal)
      .Permit(Trigger.Fall, State.Falling)
      .Permit(Trigger.Jump, State.Jumping);

    machine.Configure(State.Jumping)
      .Permit(Trigger.Fall, State.Falling);

    machine.Configure(State.Falling)
      .Permit(Trigger.Land, State.Landing);

    machine.Configure(State.Landing)
      .Permit(Trigger.BackToNormal, State.Normal);


    foreach(var state in Enum.GetValues(typeof(State))) {
      _stateHandlers[state] = GetComponent<States.Base>(string.Format("States.{0}", state.ToString()));
    }
  }

  void Update()
  {
    States.Base handler = _stateHandlers[machine.State]

    if(handler)
    {
      handler.handleInput();
      handler.updateCharacter();
    }
  }
}
