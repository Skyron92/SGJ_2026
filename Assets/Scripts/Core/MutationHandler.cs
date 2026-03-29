using UnityEngine;

public class MutationHandler : MonoBehaviour
{
    public static MutationHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if(Instance != this) Destroy(gameObject);
    }

    private Mutation _currentMutation;

    public void SetMutation(Mutation mutation)
    {
        _currentMutation = mutation;
    }

    public Mutation GetCurrentMutation() => _currentMutation;

    private bool SupportWarm(int warm) => _currentMutation.MaxHeat < warm;
    private bool SupportPh(int ph) => _currentMutation.MaxPh > ph && _currentMutation.MinPh < ph;
    private bool SupportUv() => _currentMutation.SupportUV >= 0;
    private bool SupportPulsed() => _currentMutation.SupportPulsed >= 0;

    public bool CheckMutationResistance(int warm, int ph, bool supportUv, bool supportPulsed) {
        var result = SupportWarm(warm) && SupportPh(ph) && SupportUv() == supportUv && SupportPulsed() == supportPulsed;
        if(!result) KillMutation();
        return result;
    }

    private void KillMutation() => _currentMutation = null;
}