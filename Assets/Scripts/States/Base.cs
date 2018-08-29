using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
  public class Base : MonoBehaviour
  {
    StateController _stateController;

    public void Start() {
      _stateController = GetComponent<StateController>("StateController");
    }

    public void handleInput() {
    }

    public void updateCharacter() {
    }

    protected void trigger(StateController.Trigger trigger) {
      _stateController.machine.Fire(trigger);
    }
  }
}
