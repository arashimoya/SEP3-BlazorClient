﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ABDOTClient.Model
{
    public class Hall
    {
        
    
        public int Id { get; set; }

        [Required]
        public int HallSize { get; set; }

        [Required]
        public Branch Branch { get; set; }
        public List<Play> Programme { get; set; }
        
        
        //generated in the constructor
        public List<Tuple<int, int>> Seats { get; set; }
        
        public Hall(int hallSize)
        {

            HallSize = hallSize;
            //
            Seats = new List<Tuple<int, int>>();
            Programme = new List<Play>();
            //
            // //Hall size small = 6 rows, 8 columns
            // if (HallSize == 1)
            // {
            //     CreateSeats(6, 8);
            // }
            // //Hall size medium = 12 rows = 14 columns
            // else if (HallSize == 2)
            // {
            //     CreateSeats(12, 14);
            // }
            // //Hall size large = 15 rows, 20 columns
            // else if (HallSize == 3)
            // {
            //     CreateSeats(15, 20);
            // }
            // //Invalid hall size
            // else
            // {
            //     throw new Exception("Invalid hall size");
            // }
        }
        
        private void CreateSeats(int rows, int columns)
        {
            for (int i = 1; i <= rows; i++)
            {
                for (int z = 1; z <= columns; z++)
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(i, z);
                    Seats.Add(tuple);
                }
            } 
        }

        public void LoadSeats() {
            
            //Hall size small = 6 rows, 8 columns
            if (HallSize == 1)
            {
                CreateSeats(6, 8);
            }
            //Hall size medium = 12 rows = 14 columns
            else if (HallSize == 2)
            {
                CreateSeats(12, 14);
            }
            //Hall size large = 15 rows, 20 columns
            else if (HallSize == 3)
            {
                CreateSeats(15, 20);
            }
            //Invalid hall size
            else
            {
                throw new Exception("Invalid hall size");
            }
        }
    }
}