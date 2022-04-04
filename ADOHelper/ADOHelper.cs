using System.Data;
using System.Data.SqlClient;

namespace ADOHelper
{
    public class QueryField
    {
        public string ColumnName { get; set; }
        public int ColumnOrdinal { get; set; }
        public int ColumnSize { get; set; }
        public int NumericPrecision { get; set; }
        public int NumericScale { get; set; }
        public bool IsUnique { get; set; }
        public string BaseColumnName { get; set; }
        public string BaseTableName { get; set; }
        public string DataType { get; set; }
        public bool AllowDBNull { get; set; }
        public string ProviderType { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsAutoIncrement { get; set; }
        public bool IsRowVersion { get; set; }
        public bool IsLong { get; set; }
        public bool IsReadOnly { get; set; }
        public string ProviderSpecificDataType { get; set; }
        public string DataTypeName { get; set; }
        public string UdtAssemblyQualifiedName { get; set; }
        public int NewVersionedProviderType { get; set; }
        public string IsColumnSet { get; set; }
        public string RawProperties { get; set; }
        public string NonVersionedProviderType { get; set; }
    }

    public class ADOHelper
    {
        public List<QueryField> GetFields(string ConnectionString, string Query, ref DataTable SchemaTable)
        {
            DataTable dt = new DataTable();
            if ((Query.Trim().ToLower().StartsWith("select ")))
                SchemaTable = GetQuerySchema(ConnectionString, Query);
            else
                SchemaTable = GetSPSchema(Query, ConnectionString);
            List<QueryField> result = new List<QueryField>();

            for (int i = 0; i <= SchemaTable.Rows.Count - 1; i++)
            {
                var qf = new QueryField();
                string properties = string.Empty;
                for (var j = 0; j <= SchemaTable.Columns.Count - 1; j++)
                {
                    properties += SchemaTable.Columns[j].ColumnName + Environment.NewLine + SchemaTable.Rows[i][j].ToString();
                    if (j < SchemaTable.Columns.Count - 1)
                        properties += (char)255;

                    if (SchemaTable.Rows[i][j] != DBNull.Value)
                    {
                        switch (SchemaTable.Columns[j].ColumnName)
                        {
                            case "ColumnName":
                                {
                                    qf.ColumnName = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "ColumnOrdinal":
                                {
                                    qf.ColumnOrdinal = Convert.ToInt32(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "ColumnSize":
                                {
                                    qf.ColumnSize = Convert.ToInt32(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "NumericPrecision":
                                {
                                    qf.NumericPrecision = Convert.ToInt32(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "NumericScale":
                                {
                                    qf.NumericScale = Convert.ToInt32(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "IsUnique":
                                {
                                    qf.IsUnique = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "BaseColumnName":
                                {
                                    qf.BaseColumnName = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "BaseTableName":
                                {
                                    qf.BaseTableName = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "DataType":
                                {
                                    qf.DataType = ((System.Type)SchemaTable.Rows[i][j]).FullName;
                                    break;
                                }

                            case "AllowDBNull":
                                {
                                    qf.AllowDBNull = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "ProviderType":
                                {
                                    qf.ProviderType = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "IsIdentity":
                                {
                                    qf.IsIdentity = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "IsAutoIncrement":
                                {
                                    qf.IsAutoIncrement = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "IsRowVersion":
                                {
                                    qf.IsRowVersion = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "IsLong":
                                {
                                    qf.IsLong = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "IsReadOnly":
                                {
                                    qf.IsReadOnly = Convert.ToBoolean(SchemaTable.Rows[i][j]);
                                    break;
                                }

                            case "ProviderSpecificDataType":
                                {
                                    qf.ProviderSpecificDataType = ((System.Type)SchemaTable.Rows[i][j]).FullName;
                                    break;
                                }

                            case "DataTypeName":
                                {
                                    qf.DataTypeName = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "UdtAssemblyQualifiedName":
                                {
                                    qf.UdtAssemblyQualifiedName = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "IsColumnSet":
                                {
                                    qf.IsColumnSet = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            case "NonVersionedProviderType":
                                {
                                    qf.NonVersionedProviderType = SchemaTable.Rows[i][j].ToString();
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
                qf.RawProperties = properties;
                result.Add(qf);
            }

            return result;
        }

        public ADOHelper()
        {
        }

        // Perform the query, extract the results
        private DataTable GetQuerySchema(string strconn, string strSQL)
        {
            // Returns a DataTable filled with the results of the query
            // Function returns the count of records in the datatable
            // ----- dt (datatable) needs to be empty & no schema defined

            SqlConnection sconQuery = new SqlConnection();
            SqlCommand scmdQuery = new SqlCommand();
            SqlDataReader srdrQuery = null;
            int intRowsCount = 0;
            System.Data.DataTable dtSchema = new System.Data.DataTable();

            try
            {

                // Open the SQL connnection to the SWO database
                sconQuery.ConnectionString = strconn;
                sconQuery.Open();

                // Execute the SQL command against the database & return a resultset
                scmdQuery.Connection = sconQuery;
                if (strSQL.ToUpper().EndsWith(" FOR BROWSE") == false)//https://github.com/dotnet/runtime/issues/17321#issuecomment-220740549
                    scmdQuery.CommandText = strSQL + " FOR BROWSE"; 
                else
                    scmdQuery.CommandText = strSQL;
                srdrQuery = scmdQuery.ExecuteReader(System.Data.CommandBehavior.SchemaOnly);
                dtSchema = srdrQuery.GetSchemaTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (srdrQuery != null)
                {
                    if (!srdrQuery.IsClosed)
                        srdrQuery.Close();
                }
                scmdQuery.Dispose();
                sconQuery.Close();
                sconQuery.Dispose();
            }

            return dtSchema;
        }

        public string[] GenerateCodeVB(ref List<QueryField> Columns, string ObjectName, string LinePrefix = "    ")
        {
            string[] result = new string[Columns.Count + 2 + 1];
            result[0] = string.Format("Public Class {0}", ObjectName);
            for (int i = 0; i <= Columns.Count - 1; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(Columns[i].ColumnName))
                        Columns[i].ColumnName = "Field" + i.ToString("000");
                    if (char.IsNumber(Columns[i].ColumnName.Substring(0, 1).ToCharArray()[0]))
                        Columns[i].ColumnName = "_" + Columns[i].ColumnName;

                    string AllowNull = ", null";
                    if (Columns[i].AllowDBNull == false)
                        AllowNull = ", not null";

                    switch (Columns[i].DataTypeName)
                    {
                        case "bigint":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Long '(bigint{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "binary":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1}() as Byte '(binary({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "bit":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Boolean '(bit{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "char":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as String '(char({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "date":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as DateTime '(date{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "datetime":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as DateTime '(datetime{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "datetime2":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as DateTime '(datetime2({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].NumericScale, AllowNull);
                                break;
                            }

                        case "datetimeoffset":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as DateTimeOffset '(datetimeoffset{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "decimal":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Decimal '(decimal({2},{3}){4})", LinePrefix, Columns[i].ColumnName, Columns[i].NumericPrecision, Columns[i].NumericScale, AllowNull);
                                break;
                            }

                        case "float":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Double '(float{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "image":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1}() as Byte '(image{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "int":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Integer '(int{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "money":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Decimal '(money{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "nchar":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}Public Property {1} as String '(nchar(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}Public Property {1} as String '(nchar({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "ntext":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as String '(ntext{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "nvarchar":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}Public Property {1} as String '(nvarchar(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}Public Property {1} as String '(nvarchar({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "real":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Single '(real{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "smalldatetime":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as DateTime '(smalldatetime{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "sql_variant":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Object '(sql_variant{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "text":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as String '(text{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "time":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as DateTime '(time({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].NumericScale, AllowNull);
                                break;
                            }

                        case "timestamp":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1}() as Byte '(timestamp{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "tinyint":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1}() as Byte '(tinyint{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "uniqueidentifier":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as Guid '(uniqueidentifier{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "varbinary":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}Public Property {1}() as Byte '(varbinary(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}Public Property {1}() as Byte '(varbinary({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "varchar":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}Public Property {1} as String '(varchar(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}Public Property {1} as String '(varchar({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "xml":
                            {
                                result[i + 1] = string.Format("{0}Public Property {1} as String '(XML(.){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        default:
                            {
                                switch (Columns[i].DataType)
                                {
                                    case "Microsoft.SqlServer.Types.SqlGeography" // geography
                                   :
                                        {
                                            result[i + 1] = string.Format("{0}Public Property {1} as Microsoft.SqlServer.Types.SqlGeography '({2}{3})", LinePrefix, Columns[i].ColumnName, Columns[i].DataTypeName, AllowNull);
                                            break;
                                        }

                                    case "Microsoft.SqlServer.Types.SqlHierarchyId" // heirarchyid
                             :
                                        {
                                            result[i + 1] = string.Format("{0}Public Property {1} as Microsoft.SqlServer.Types.SqlGeography '({2}{3})", LinePrefix, Columns[i].ColumnName, Columns[i].DataTypeName, AllowNull);
                                            break;
                                        }

                                    case "Microsoft.SqlServer.Types.SqlGeometry" // geometry
                             :
                                        {
                                            result[i + 1] = string.Format("{0}Public Property {1} as Microsoft.SqlServer.Types.SqlGeography '({2}{3})", LinePrefix, Columns[i].ColumnName, Columns[i].DataTypeName, AllowNull);
                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            result[Columns.Count + 1] = "End Class";
            return result;
        }

        public string[] GenerateCodeCS(ref List<QueryField> Columns, string ObjectName, string LinePrefix = "    ")
        {
            string[] result = new string[Columns.Count + 2 + 1];
            result[0] = string.Format("public class {0} {{", ObjectName);
            for (int i = 0; i <= Columns.Count - 1; i++)
            {
                try
                {
                    if (char.IsNumber(Columns[i].ColumnName.Substring(0, 1).ToCharArray()[0]))
                        Columns[i].ColumnName = "_" + Columns[i].ColumnName;

                    string AllowNull = ", null";
                    if (Columns[i].AllowDBNull == false)
                        AllowNull = ", not null";

                    switch (Columns[i].DataTypeName)
                    {
                        case "bigint":
                            {
                                result[i + 1] = string.Format("{0}public long {1} {{ get; set; }} //(bigint{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "binary":
                            {
                                result[i + 1] = string.Format("{0}public byte[] {1} {{ get; set; }} //(binary({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "bit":
                            {
                                result[i + 1] = string.Format("{0}public bool {1} {{ get; set; }} //(bit{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "char":
                            {
                                result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(char({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "date":
                            {
                                result[i + 1] = string.Format("{0}public DateTime {1} {{ get; set; }} //(date{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "datetime":
                            {
                                result[i + 1] = string.Format("{0}public DateTime {1} {{ get; set; }} //(datetime{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "datetime2":
                            {
                                result[i + 1] = string.Format("{0}public DateTime {1} {{ get; set; }} //(datetime2({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].NumericScale, AllowNull);
                                break;
                            }

                        case "datetimeoffset":
                            {
                                result[i + 1] = string.Format("{0}public DateTimeOffset {1} {{ get; set; }} //(datetimeoffset{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "decimal":
                            {
                                result[i + 1] = string.Format("{0}public decimal {1} {{ get; set; }} //(decimal({2},{3}){4})", LinePrefix, Columns[i].ColumnName, Columns[i].NumericPrecision, Columns[i].NumericScale, AllowNull);
                                break;
                            }

                        case "float":
                            {
                                result[i + 1] = string.Format("{0}public double {1} {{ get; set; }} //(float{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "image":
                            {
                                result[i + 1] = string.Format("{0}public byte[] {1} {{ get; set; }} //(image{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "int":
                            {
                                result[i + 1] = string.Format("{0}public int {1} {{ get; set; }} //(int{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "money":
                            {
                                result[i + 1] = string.Format("{0}public decimal {1} {{ get; set; }} //(money{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "nchar":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(nchar(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(nchar({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "ntext":
                            {
                                result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(ntext{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "nvarchar":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(nvarchar(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(nvarchar({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "real":
                            {
                                result[i + 1] = string.Format("{0}public Single {1} {{ get; set; }} //(real({2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "smalldatetime":
                            {
                                result[i + 1] = string.Format("{0}public DateTime {1} {{ get; set; }} //(smalldatetime{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "sql_variant":
                            {
                                result[i + 1] = string.Format("{0}public object {1} {{ get; set; }} //(sql_variant{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "text":
                            {
                                result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(text{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "time":
                            {
                                result[i + 1] = string.Format("{0}public DateTime {1} {{ get; set; }} //(time({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].NumericScale, AllowNull);
                                break;
                            }

                        case "timestamp":
                            {
                                result[i + 1] = string.Format("{0}public byte[] {1} {{ get; set; }} //(timestamp{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "tinyint":
                            {
                                result[i + 1] = string.Format("{0}public byte {1} {{ get; set; }} //(tinyint{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "uniqueidentifier":
                            {
                                result[i + 1] = string.Format("{0}public Guid {1} {{ get; set; }} //(uniqueidentifier{2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        case "varbinary":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}public byte[] {1} {{ get; set; }} //(varbinary(max){2})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}public byte[] {1} {{ get; set; }} //(varbinary({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "varchar":
                            {
                                if (Columns[i].IsLong)
                                    result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(varchar(max){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                else
                                    result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(varchar({2}){3})", LinePrefix, Columns[i].ColumnName, Columns[i].ColumnSize, AllowNull);
                                break;
                            }

                        case "xml":
                            {
                                result[i + 1] = string.Format("{0}public string {1} {{ get; set; }} //(XML(.){2})", LinePrefix, Columns[i].ColumnName, AllowNull);
                                break;
                            }

                        default:
                            {
                                switch (Columns[i].DataType)
                                {
                                    case "Microsoft.SqlServer.Types.SqlGeography" // geography
                                   :
                                        {
                                            result[i + 1] = string.Format("{0}public Microsoft.SqlServer.Types.SqlGeography {1} {{ get; set; }} //({2}{3})", LinePrefix, Columns[i].ColumnName, Columns[i].DataTypeName, AllowNull);
                                            break;
                                        }

                                    case "Microsoft.SqlServer.Types.SqlHierarchyId" // heirarchyid
                             :
                                        {
                                            result[i + 1] = string.Format("{0}public Microsoft.SqlServer.Types.SqlGeography {1} {{ get; set; }} //({2}{3})", LinePrefix, Columns[i].ColumnName, Columns[i].DataTypeName, AllowNull);
                                            break;
                                        }

                                    case "Microsoft.SqlServer.Types.SqlGeometry" // geometry
                             :
                                        {
                                            result[i + 1] = string.Format("{0}public Microsoft.SqlServer.Types.SqlGeography {1} {{ get; set; }} //({2}{3})", LinePrefix, Columns[i].ColumnName, Columns[i].DataTypeName, AllowNull);
                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            result[Columns.Count + 1] = "}";
            return result;
        }

        public string StringArrayToText(string[] lines, string LineDelimiter)
        {
            // Determine number of characters needed in result string
            var charCount = 0;
            LineDelimiter = Environment.NewLine;
            foreach (var s in lines)
            {
                if (!string.IsNullOrEmpty(s))
                    charCount += s.Length + LineDelimiter.Length;
            }

            // Preallocate needed string space plus a little extra
            var sb = new System.Text.StringBuilder(charCount + lines.Count());
            for (int i = 0; i <= lines.Count() - 1; i++)
            {
                if (!string.IsNullOrEmpty(lines[i]))
                    sb.Append(lines[i] + LineDelimiter);
            }
            return sb.ToString();
        }

        // Run a stored procedure with optional parameters and return as datatable of results
        public DataTable GetSPSchema(string spName, string strConn)
        {

            // Dim the dataset to hold the result table
            DataTable dtSchema = new DataTable();

            // Return if missing important information (SP Name)
            if (spName.Trim().Length == 0)
                return dtSchema;

            // Default the connection string to the public class variable if not specified
            if (strConn.Length == 0)
                return dtSchema;

            // Create the connection to the database
            System.Data.SqlClient.SqlConnection sconSP = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlCommand scmdSP = new System.Data.SqlClient.SqlCommand();
            SqlDataReader srdrSP = null;

            try
            {
                // Set the connection string on the connection object
                sconSP.ConnectionString = strConn;
                sconSP.Open();

                // Set up the SqlCommand object
                scmdSP.CommandText = spName;
                scmdSP.Connection = sconSP;
                scmdSP.CommandType = CommandType.StoredProcedure;

                if (spName.Contains("|"))
                {
                    var spParms = spName.Split("|");
                    scmdSP.CommandText = spParms[0].Trim();
                    for (var i = 1; i <= spParms.Count() - 1; i++)
                    {
                        var spFields = spParms[i].Replace("`,", "\t").Replace("`", "").Split("\t");
                        scmdSP.Parameters.Add(new System.Data.SqlClient.SqlParameter(spFields[0].Trim(), spFields[1].Trim()));
                    }
                }

                srdrSP = scmdSP.ExecuteReader(CommandBehavior.SingleResult);
                dtSchema = srdrSP.GetSchemaTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (srdrSP != null)
                {
                    if (!srdrSP.IsClosed)
                        srdrSP.Close();
                }
                scmdSP.Dispose();
                sconSP.Close();
                sconSP.Dispose();
            }

            return dtSchema;
        }
    }

}