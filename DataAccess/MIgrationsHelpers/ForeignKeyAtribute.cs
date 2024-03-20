namespace DataAccess.MIgrationsHelpers;

public class ForeignKeyAttribute : ColumnKeyAttribute
{
    public ForeignKeyAttribute(string referenceTableName, string referenceTableColumnName)
    {
        ReferenceTableName = referenceTableName;
        ReferenceTableColumnName = referenceTableColumnName;
    }

    public string ReferenceTableName { get; set; }
    public string ReferenceTableColumnName { get; set; }
}
