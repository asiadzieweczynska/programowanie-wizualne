namespace projekt6;

public sealed record GameSettings
{
    public int BoardWidth { get; init; } = 3;
    public int BoardHeight { get; init; } = 3;
    public int TimeSeconds { get; init; } = 30;
    public int DydelfCount { get; init; } = 1;
    public int SzopCount { get; init; } = 3;
    public int KrokodylCount { get; init; } = 0;

    public static GameSettings Default => new();

    public int TotalCreatures => DydelfCount + SzopCount + KrokodylCount;

    public int TotalCells => BoardWidth * BoardHeight;
}
