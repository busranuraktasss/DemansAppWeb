﻿namespace DemansAppWeb.Helper.DTO.TracesOfLove
{
    public class shiftMapRequest
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string PlaceName { get; set; } //TraceOfLoveController
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
