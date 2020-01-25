using System.Linq;
using Npgsql;

namespace Repository.Entity.Supplier.Command
{
    public class SupplierFIndByIdCommand
    {
        private const string Sql = "SELECT * FROM supplier WHERE id = @Id;";

        private readonly SupplierRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _queryParamId;

        public SupplierFIndByIdCommand(DataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new SupplierRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public SupplierEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _queryParamId);
            command.Prepare();
            
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet).FirstOrDefault();
        }
    }
}