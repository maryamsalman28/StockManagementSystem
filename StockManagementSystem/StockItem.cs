using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem
{
    internal class StockItem
    {
        private int stockCode { get; set; }
        private string stockName { get; set; }
        private int stockQuantity { get; set;}
        private string date { get; set;}

        public int GetStockCode()
        {
            return stockCode;
        }
        public string GetStockName() 
        { 
            return stockName;
        }
        public int GetStockQuantity()
        {
            return stockQuantity;
        }
        public string GetDate() 
        {
            return date;
        }
        public StockItem(int code, string name, int quantity, string stockDate)
        {
            stockCode = code;
            stockName = name;
            stockQuantity = quantity;
            date = stockDate;
        }
    }
 }

