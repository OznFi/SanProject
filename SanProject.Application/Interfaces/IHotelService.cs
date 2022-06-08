﻿using SanProject.Shared.HotelModels;
using System.Threading.Tasks;

namespace SanProject.Application.Services.Interfaces
{
    public interface IHotelService
    {
        string tokne { get; set; }

        Task<HotelDetailDTO> GetDetails(string querys);
    }
}