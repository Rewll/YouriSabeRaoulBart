using UnityEngine;
public class PotionClass : MonoBehaviour
{
    private ISideEffect[] sideEffects;
    private IMainEffect[] mainEffects;
    private void Update()
    {
        if (!transform.parent)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) //throw
        {
            //mainEffect
            mainEffects = GetComponents<IMainEffect>();
            foreach (var mainEffect in mainEffects)
            {
                mainEffect.ThrowEffect();
            }
            //sideEffects
            sideEffects = GetComponents<ISideEffect>();
            foreach (var sideEffect in sideEffects)
            {
                sideEffect.ThrowEffect();
            }
            Destroy(gameObject);    
        }
        if (Input.GetMouseButtonDown(1)) //drink
        {
            //mainEffect
            mainEffects = GetComponents<IMainEffect>();
            foreach (var mainEffect in mainEffects)
            {
                mainEffect.DrinkEffect();
            }
            //sideEffects
            sideEffects = GetComponents<ISideEffect>();
            foreach (var sideEffect in sideEffects)
            {
                sideEffect.DrinkEffect();
            }
            Destroy(gameObject);
        }
    }
}
