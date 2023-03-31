using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerControls PC { get; private set; }

    // ALWAYS GET REFERENCES TO PC (S.I.IM.PC) IN START, NOT ONENABLE OR AWAKE!
    // NEEDS TO HAPPEN AFTER THIS AWAKE METHOD GETS CALLED!
    private void Awake()
    {
        PC = new PlayerControls();

        // Enable "Gameplay" as default action map
        PC.Disable();
        PC.Gameplay.Enable();
    }

    public void EnablePauseAction()
    {
        PC.Gameplay.Pause.Enable();
    }

    public void DisablePauseAction()
    {
        PC.Gameplay.Pause.Disable();
    }
}