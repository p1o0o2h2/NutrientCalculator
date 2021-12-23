using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace えいようちゃん
{
    static public class ConnectSQL
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        static readonly string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// 栄養素の名前や単位などを取得する
        /// </summary>
        /// <returns>[0]エラーの場合空の</returns>
        static public DataTable GetCompositionName()
        {
            string SelectSql = "SELECT * FROM FoodComposition.dbo.NameTable";
            try
            {
                using (var connection = new SqlConnection(connectingString))
                using (var command = connection.CreateCommand())
                {
                    // コネクションをオープンします。
                    connection.Open();

                    // 検索SQLを設定します。
                    command.CommandText = SelectSql;

                    // SqlDataAdapterで全行のデータをDataTableに読み込みます。
                    var dataAdapter = new SqlDataAdapter(command);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;                    
                }
            }
            catch 
            {
                throw;
            }            
        }

        /// <summary>
        /// 指定の分類に含まれる食品の食品番号と名前を取得する
        /// </summary>
        /// <param name="genreNum">食品の分類</param>
        /// <returns>(食品番号,名前)</returns>
        public static List<(int,string)> GetFoodCompositionFoods(int genreNum)
        {
            var rtn = new List<(int, string)>();
            string SelectSql = $"SELECT [{(int)NutrientDataColumn.identify}],[{(int)NutrientDataColumn.name}] FROM FoodComposition.dbo.FoodTable WHERE [{(int)NutrientDataColumn.genre}]={genreNum}";
            try 
            {
                using (var connection = new SqlConnection(connectingString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = SelectSql;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            rtn.Add((int.Parse(reader[0].ToString()), reader[1].ToString()));                            
                        }
                    }
                }
                return rtn;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 食品番号からその食品の全てのデータを取得する
        /// </summary>
        /// <param name="identify">食品番号</param>
        /// <returns>食品の全てのデータ</returns>
        public static List<string> GetFoodCompositionValue(int identify)
        {
            List<string> rtn = new List<string>();
            string SelectSql = $"SELECT * FROM FoodComposition.dbo.FoodTable WHERE [{(int)NutrientDataColumn.identify}]={identify}";
            
            try
            {
                using (var connection = new SqlConnection(connectingString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = SelectSql;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rtn.Add(reader[i].ToString());
                            }
                        }
                    }
                }
                return rtn;
            }
            catch
            { 
                throw;
            }
        }
    }
}
