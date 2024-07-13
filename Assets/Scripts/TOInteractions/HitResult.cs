public record HitResult
{
    public enum Result
    {
        Miss, Early, Late, Okay, Good, Perfect, Why // потенциально не все статусы будут использоваться
    }

    public Result ResultState { get; set; }

    public int BaseDamage { get; set; } //todo вот это вообще криво сделано
}