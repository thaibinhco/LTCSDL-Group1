﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using ResortDTO;

namespace ResortDAL
{
    public class ChiTietShoppingDAL
    {
        private DataProvider _dp;

        public ChiTietShoppingDAL()
        {
            _dp = new DataProvider();
        }

        public DataTable GetChiTietShopping(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = _dp.DataAdapter(sql);
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Boolean Add(DataTable dt, ChiTietShopping cts)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["IDShopping"]) == cts.iDShopping && Convert.ToInt32(dr["IDSanPham"]) == cts.iDSanPham)
                {
                    throw new Exception("IDShopping và IDSanPham đã tồn tại!");
                }
            }
            DataRow newRow = dt.NewRow();
            newRow["IDShopping"] = cts.iDShopping;
            newRow["IDSanPham"] = cts.iDSanPham;
            newRow["Soluong"] = cts.soLuong;
            newRow["ThanhTien"] = cts.thanhTien;
            dt.Rows.Add(newRow);
            return true;
        }

        public int SaveData(ref DataTable dt)
        {
            try
            {
                string sql = "SELECT * FROM ChiTietShopping";
                SqlDataAdapter da = _dp.DataAdapter(sql);
                return da.Update(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
