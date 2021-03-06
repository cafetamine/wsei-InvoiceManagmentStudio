using Npgsql;

namespace Repository.Item.Command
{
    public class InvoiceItemDeleteCommand
    {
        private const string Sql = "DELETE FROM invoice_item WHERE id = @Id;";
        
        private readonly InvoiceItemRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public InvoiceItemDeleteCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoiceItemRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", (long)_id);
            var result = command.ExecuteNonQuery() > 0;
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
