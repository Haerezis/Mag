using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
  public class Falling : Base
  {
    PlayerPhysics _playerPhysics;
    StateController _stateController;

    void Start() {
      base.Start();
      _playerPhysics = GetComponent<PlayerPhysics>("PlayerPhysics");
      _stateController = GetComponent<StateController>("StateController");
    }

    void handleInput()
    {
      //TODO
    }

    void updateCharacter()
    {
      //TODO
      if (_playerPhysics.isGrounded()) {
        _stateController.machine.Fire(Trigger.Land);
      }
    }
  }
}
