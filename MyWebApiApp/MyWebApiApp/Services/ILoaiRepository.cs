﻿using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;

namespace MyWebApiApp.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiVM loai);
        void Delete(int id);
        
    }
}
