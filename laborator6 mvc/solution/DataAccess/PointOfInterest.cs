using System;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DataAccess
{
    public class PointOfInterest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Coordinates { get; set; }

        public PointOfInterest()
        {

        }

        public PointOfInterest(Guid id, string coordinates)
        {
            Id = id;
            Coordinates = coordinates;
        }
    }
}
