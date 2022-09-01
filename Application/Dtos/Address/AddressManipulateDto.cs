﻿namespace Application.Dtos.Address
{
    public abstract class AddressManipulateDto
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }
    }
}