using AWBArchiving.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBArchiving.BLL
{
    public class ViewLogic
    {
        private BaseContext _context;
        public DAL.BaseContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new BaseContext("Main");
                }
                return _context;
            }
        }
        public DataSet GetView(int id, int take, int skip)
        {
            DataSet dataSet = new DataSet();
            var view = Context.Views.FirstOrDefault(v => v.Id == id);
            if (view == null)
                return dataSet;


            string queryString = string.Format("SELECT {0} FROM {1} "
                + "ORDER BY Id "
                + "OFFSET {2} ROWS "
                + "FETCH NEXT {3} ROWS ONLY ", view.ColumnsCSV, view.TableName, skip, take);

            SqlConnection conn = new SqlConnection(view.Database.ConnString);
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, conn))
            {
                dataAdapter.Fill(dataSet);
            }

            return dataSet;
        }

        public DataSet SearchView(int id, string search)
        {
            DataSet dataSet = new DataSet();
            var view = Context.Views.FirstOrDefault(v => v.Id == id);
            if (view == null)
                return dataSet;

            string whereClause = string.Empty;
            var scolumns = view.SearchColumnsCSV.Split(',');
            for (int i = 0; i < scolumns.Length; i++)
            {
                var searchColumn = scolumns[i];
                if (whereClause == string.Empty)
                    whereClause = string.Format("{0} Like '%{1}%'", searchColumn, search);
                else
                    whereClause = whereClause + string.Format(" OR {0} Like '%{1}%'", searchColumn, search);

            }
       
            string queryString = string.Format("SELECT {0} FROM {1} "
                + "WHERE {2} "
                + "ORDER BY Id "
                + "OFFSET {3} ROWS "
                + "FETCH NEXT {4} ROWS ONLY ", view.ColumnsCSV, view.TableName,whereClause, 0, 100);

            SqlConnection conn = new SqlConnection(view.Database.ConnString);
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, conn))
            {
                dataAdapter.Fill(dataSet);
            }

            return dataSet;
        }
    }
}
