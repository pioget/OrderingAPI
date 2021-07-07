using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static OrderingAPI.Models.DTO.validate;

namespace OrderingAPI.Models.DTO
{
    public class RequestCreateFullOrderDTO
    {
        public CustomerDTO customerDTO { get; set; }
        [Required, ValidateEachItem]
        public List<AddOrderlineDTO> orderlines { get; set; }

    }
}
