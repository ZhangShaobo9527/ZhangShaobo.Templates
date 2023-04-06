namespace __PROJECT_NAME__.Shared.ClientServices;

public struct LocalStorageGetResult<T>
{
    public bool Exist;
    public T Value;

    public LocalStorageGetResult(bool exists, T value)
    {
        this.Exist = exists;
        this.Value = value;
    }
}
