public interface IStoneReactive
{
    bool CanReactTo(StoneType type);
    void ReactTo(StoneType type);
}