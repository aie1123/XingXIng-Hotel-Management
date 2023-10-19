using StudentWeb.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentWeb.Model
{
    public class PagedList<T>
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("total_item_count")]
        public int TotalItemCount { get; set; }
        [JsonProperty("total_order_price_count")]
        public decimal  TotalOrderPriceCount { get; set; }

        [JsonProperty("total_page_count")]
        public int TotalPageCount { get; set; }

        [JsonProperty("has_prev_page")]
        public bool HasPrevPage { get; set; }

        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("list")]
        public List<T> List { get; set; }

        public PagedList(List<T> list, int pageIndex, int pageSize, int totalCount,decimal prices=0)
        {
            if (totalCount > 0)
            {
                CurrentPage = pageIndex + 1;
            }
            else
            {
                CurrentPage = 0;
            }
            PageSize = pageSize;
            TotalItemCount = totalCount;
            TotalOrderPriceCount = prices;
            TotalPageCount = ConvertHelper.ToInt(Math.Ceiling((double)totalCount / pageSize));
            HasPrevPage = CurrentPage > 1;
            HasNextPage = CurrentPage < TotalPageCount;
            List = list;
        }
    }
}
