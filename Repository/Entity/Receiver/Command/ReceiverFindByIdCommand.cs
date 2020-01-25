using System.Linq;
using Npgsql;

namespace Repository.Entity.Receiver.Command
{
    public class ReceiverFIndByIdCommand
    {
        private const string Sql = "SELECT * FROM receiver WHERE id = @Id;";

        private readonly ReceiverRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _queryParamId;

        public ReceiverFIndByIdCommand(DataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new ReceiverRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public ReceiverEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _queryParamId);
            command.Prepare();
            
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet).FirstOrDefault();
        }
    }
}