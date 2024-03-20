namespace DataAccess.MigrationsHelpers;

public class ColumnKeyAttribute : Attribute
{
    public ColumnKeyAttribute(bool isUniq = false, bool deleteCascade = true)
    {
        IsUniq = isUniq;
        DeleteCascade = deleteCascade;
    }

    public bool IsUniq { get; set; }
    public bool DeleteCascade { get; set; }
}
