﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Exceptions
{
    public class PaginationResponse<T>
    {


        public IEnumerable<T> Datas { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }

        public PaginationResponse(IEnumerable<T> datas, int totalPage, int currentPage, int totalCount)
        {
            Datas = datas;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            TotalCount = totalCount;
        }

        public bool HasNext => CurrentPage < TotalPage;

        public bool HasPrevious => CurrentPage > 1;


    }

}
