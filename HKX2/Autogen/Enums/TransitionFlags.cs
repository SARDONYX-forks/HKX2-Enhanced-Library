namespace HKX2
{
    public enum TransitionFlags : short
    {
        FLAG_USE_TRIGGER_INTERVAL = 1,
        FLAG_USE_INITIATE_INTERVAL = 2,
        FLAG_UNINTERRUPTIBLE_WHILE_PLAYING = 4,
        FLAG_UNINTERRUPTIBLE_WHILE_DELAYED = 8,
        FLAG_DELAY_STATE_CHANGE = 16,
        FLAG_DISABLED = 32,
        FLAG_DISALLOW_RETURN_TO_PREVIOUS_STATE = 64,
        FLAG_DISALLOW_RANDOTRANSITION = 128,
        FLAG_DISABLE_CONDITION = 256,
        FLAG_ALLOW_SELF_TRANSITION_BY_TRANSITION_FROANY_STATE = 512,
        FLAG_IS_GLOBAL_WILDCARD = 1024,
        FLAG_IS_LOCAL_WILDCARD = 2048,
        FLAG_FRONESTED_STATE_ID_IS_VALID = 4096,
        FLAG_TO_NESTED_STATE_ID_IS_VALID = 8192,
        FLAG_ABUT_AT_END_OF_FROGENERATOR = 16384,
    }
}

