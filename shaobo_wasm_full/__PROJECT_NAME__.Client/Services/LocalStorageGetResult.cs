namespace __PROJECT_NAME__.Client.Services;

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
