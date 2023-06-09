﻿using System.ComponentModel.DataAnnotations;

namespace EbookStore.Client.ViewModel;

public class SaleCreateViewModel
{
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Sale name must be between 4 and 50 characters!")]
    [Required(ErrorMessage = "Please enter sale name")]
    public string Name { get; set; }

    [Range(1, 100, ErrorMessage = "Sale percent must be between 1 and 100!")]
    [Required(ErrorMessage = "Please enter sale percent")]
    public double SalePercent { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter sale start date")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Please enter sale end date")]
    public DateTime EndDate { get; set; }

    public List<int> BookIds { get; set; }

}